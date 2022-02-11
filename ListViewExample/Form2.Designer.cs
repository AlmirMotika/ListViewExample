
namespace ListViewExample
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.Button_Populate = new System.Windows.Forms.Button();
            this.Button_print = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1392, 638);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Button_Populate
            // 
            this.Button_Populate.Location = new System.Drawing.Point(12, 656);
            this.Button_Populate.Name = "Button_Populate";
            this.Button_Populate.Size = new System.Drawing.Size(75, 23);
            this.Button_Populate.TabIndex = 1;
            this.Button_Populate.Text = "Populate";
            this.Button_Populate.UseVisualStyleBackColor = true;
            this.Button_Populate.Click += new System.EventHandler(this.Button_Populate_Click_1);
            // 
            // Button_print
            // 
            this.Button_print.Location = new System.Drawing.Point(93, 656);
            this.Button_print.Name = "Button_print";
            this.Button_print.Size = new System.Drawing.Size(75, 23);
            this.Button_print.TabIndex = 2;
            this.Button_print.Text = "Print";
            this.Button_print.UseVisualStyleBackColor = true;
            this.Button_print.Click += new System.EventHandler(this.Button_print_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument1_PrintPage);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 682);
            this.Controls.Add(this.Button_print);
            this.Controls.Add(this.Button_Populate);
            this.Controls.Add(this.listView1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button Button_Populate;
        private System.Windows.Forms.Button Button_print;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}