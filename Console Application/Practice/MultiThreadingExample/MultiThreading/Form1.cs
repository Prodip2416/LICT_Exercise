using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThreading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        private void btnTimeComsumingWorks_Click(object sender, EventArgs e)
        {
            btnTimeComsumingWorks.Enabled = false;
            btnPrint.Enabled = false;

            //  DoTimeConsumingWork();

            Thread worker = new Thread(DoTimeConsumingWork);
            worker.Start();

            btnTimeComsumingWorks.Enabled = true;
            btnPrint.Enabled = true;
        }

        private void DoTimeConsumingWork()
        {
            Thread.Sleep(5000);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 10; i++)
            {
                lbPrintNumbers.Items.Add(i);
            }
        }
    }
}
