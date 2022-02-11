using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListViewExample
{
    public partial class Form2 : Form
    {
        readonly SqlConnection Con = new SqlConnection("Server=DESKTOP-81OUCEP\\INSIDE;Initial Catalog=LagerVerwaltung;User Id=sa;Password=83228322");
        SqlCommand command;
        DataTable datatable;
        SqlDataAdapter dataAdapter;
        DataSet dataSet;
        public Form2()
        {
            InitializeComponent();
        }        
        private DataSet GetData(string query)
        {
            Con.Open();
            command = new SqlCommand(query, Con);
            dataAdapter = new SqlDataAdapter(command);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "ListView");

            Con.Close();
            return dataSet;
        }

        private void Button_Populate_Click_1(object sender, EventArgs e)
        {
            listView1.Columns.Add("ArtikleID", 70);
            listView1.Columns.Add("WerkzeungNr", 70, HorizontalAlignment.Center);
            listView1.Columns.Add("Lieferant", 90, HorizontalAlignment.Center);
            listView1.Columns.Add("Bezeichnung", 90, HorizontalAlignment.Center);
            listView1.Columns.Add("Lagerort", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("Verbrauch", 150, HorizontalAlignment.Center);
            listView1.View = View.Details;

            string query = "select a.id,werkzeugnr,(select kundenkuerzel from kunde where kunde.kundenid IN(select Top 1 lieferantid from artikellieferanten where artikellieferanten.artikelid = a.id order by posnr)) as kundenname,bezeichnung,dbo.GetFullLagerort(CAST(a.lagerortid as int)) as FullLagerort,dbo.GET_DV(a.id,a.lagerortid)  from artikel as a inner join artikellieferanten as af on a.id = af.artikelid";
            datatable = GetData(query).Tables["ListView"];
            int i;
            for (i = 0; i < datatable.Rows.Count; i++)
            {
                listView1.Items.Add(datatable.Rows[i].ItemArray[0].ToString());
                listView1.Items[i].SubItems.Add(datatable.Rows[i].ItemArray[1].ToString());
                listView1.Items[i].SubItems.Add(datatable.Rows[i].ItemArray[2].ToString());
                listView1.Items[i].SubItems.Add(datatable.Rows[i].ItemArray[3].ToString());
                listView1.Items[i].SubItems.Add(datatable.Rows[i].ItemArray[4].ToString());
                listView1.Items[i].SubItems.Add(datatable.Rows[i].ItemArray[5].ToString());
            }
        }

        private void Button_print_Click(object sender, EventArgs e)
        {

            string query = @"select a.id,werkzeugnr,(select kundenkuerzel from kunde where kunde.kundenid IN(select Top 1 lieferantid from artikellieferanten where artikellieferanten.artikelid = a.id order by posnr)) as kundenname,bezeichnung, dbo.GetFullLagerort(CAST(a.lagerortid as int)) as FullLagerort, dbo.GET_DV(a.id,a.lagerortid) AS Verbrauch  from artikel as a inner join artikellieferanten as af on a.id = af.artikelid";
            SqlCommand command = new SqlCommand(query, Con);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dataTable);
            PrintDocument printDocument = new PrintDocument();
            printDocument.DefaultPageSettings.Landscape = true;
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument1_PrintPage);
            PrintPreviewDialog ppDialog = new PrintPreviewDialog();
            ppDialog.Document = printDocument;
            printDocument.Print();
        }

        DataTable dataTable = new DataTable();
        private int[] GetColumnsWidth(DataTable dataTable)
        {
            int[] widthcolumn = new int[dataTable.Columns.Count];
            Font font = new Font("Arial", 8);
            for(int a = 0; a < dataTable.Columns.Count; a++)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    var width = TextRenderer.MeasureText(row[a].ToString(), font).Width;
                    if (widthcolumn[a] < width)
                    {
                        widthcolumn[a] = width;
                    }
                }
                
            }
            return widthcolumn;
        }
        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            PrintDocument document = (PrintDocument)sender;
            Graphics g = e.Graphics;

            Brush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(brush);          
            Font font = new Font("Arial", 8);

            int x = 0, y = 0, width = 188, height = 30;
            var columnWidths = GetColumnsWidth(dataTable);

            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                var column = dataTable.Columns[i];
                g.DrawRectangle(pen, x, y, columnWidths[i]+ 15, height);
                SizeF size = g.MeasureString(column.ColumnName, font);
                

                g.DrawString(column.ColumnName, font, brush, x, y + 5);
                x += columnWidths[i] + 15;
            }
            int columnCount = dataTable.Columns.Count;
            x = 0;
            y += 30;
            
            foreach (DataRow row in dataTable.Rows)
            {
                for (int i = 0; i < columnCount; i++)
                {
                    g.DrawRectangle(pen, x, y, columnWidths[i] + 15, height);
                    SizeF size = g.MeasureString(row[i].ToString(), font);
                    

                    g.DrawString(row[i].ToString(), font, brush, x, y + 5);
                    x += columnWidths[i] + 15;
                }
                x = 0;
                y += 30;
            }
            

        }
    }
}