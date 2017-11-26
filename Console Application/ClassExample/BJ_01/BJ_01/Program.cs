using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BJ_01
{
    class Program
    {
      static System.Windows.Forms.TextBox txt = new TextBox();
        static void Main(string[] args)
        {
            Console.WriteLine("My name is khan");
            Console.WriteLine("I am a cultural terrorist.");

            System.Windows.Forms.Form frm= new System.Windows.Forms.Form();

            frm.Size= new Size(400,500);
            frm.Text = "My Sweet Software";
            
            //System.Windows.Forms.TextBox txt= new TextBox();
            txt.Location = new Point(20, 20);
            frm.Controls.Add(txt);

            System.Windows.Forms.Button btn = new Button();
            btn.Location = new Point(20, 50);
            btn.Text = "&Click me";
            btn.Click += Btn_Click;
            frm.Controls.Add(btn);

            frm.ShowDialog();

            Console.ReadKey();
        }

        private static void Btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txt.Text);
        }
    }
}
