using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySweetCRUDApplication.Presentation;

namespace MySweetCRUDApplication
{
    public partial class Main : Form
    {
        frmStudent student= new frmStudent();
        frmTeacher teacher= new frmTeacher();
        public Main()
        {
            InitializeComponent();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(student.IsDisposed)
                student= new frmStudent();
            student.MdiParent = this;
            student.Show();
            student.BringToFront();
        }

        private void teacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (teacher.IsDisposed)
                teacher = new frmTeacher();
            teacher.MdiParent = this;
            teacher.Show();
            teacher.BringToFront();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
