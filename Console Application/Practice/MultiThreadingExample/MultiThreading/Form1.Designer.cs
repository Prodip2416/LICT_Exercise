namespace MultiThreading
{
    partial class Form1
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
            this.btnTimeComsumingWorks = new System.Windows.Forms.Button();
            this.lbPrintNumbers = new System.Windows.Forms.ListBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTimeComsumingWorks
            // 
            this.btnTimeComsumingWorks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimeComsumingWorks.Location = new System.Drawing.Point(110, 54);
            this.btnTimeComsumingWorks.Name = "btnTimeComsumingWorks";
            this.btnTimeComsumingWorks.Size = new System.Drawing.Size(311, 32);
            this.btnTimeComsumingWorks.TabIndex = 0;
            this.btnTimeComsumingWorks.Text = "Do Time Consuming Work";
            this.btnTimeComsumingWorks.UseVisualStyleBackColor = true;
            this.btnTimeComsumingWorks.Click += new System.EventHandler(this.btnTimeComsumingWorks_Click);
            // 
            // lbPrintNumbers
            // 
            this.lbPrintNumbers.FormattingEnabled = true;
            this.lbPrintNumbers.Location = new System.Drawing.Point(110, 156);
            this.lbPrintNumbers.Name = "lbPrintNumbers";
            this.lbPrintNumbers.Size = new System.Drawing.Size(311, 238);
            this.lbPrintNumbers.TabIndex = 1;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(110, 101);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(311, 32);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print Numbers";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 430);
            this.Controls.Add(this.lbPrintNumbers);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnTimeComsumingWorks);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multi-Threading";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTimeComsumingWorks;
        private System.Windows.Forms.ListBox lbPrintNumbers;
        private System.Windows.Forms.Button btnPrint;
    }
}

