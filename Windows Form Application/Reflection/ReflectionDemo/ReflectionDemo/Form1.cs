using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReflectionDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lbMethod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbPropertices_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void liConstructors_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userType = txtTypeName.Text;
            Type T= Type.GetType(userType);

            lbPropertices.Items.Clear();
            lbMethod.Items.Clear();
            liConstructors.Items.Clear();
            lbEvent.Items.Clear();

            MethodInfo[] methods = T.GetMethods();
            foreach (MethodInfo method in methods)
            {
                lbMethod.Items.Add(method.MemberType + " - " + method.Name);
            }

            PropertyInfo[] propertys = T.GetProperties();
            foreach (PropertyInfo property in propertys)
            {
                lbPropertices.Items.Add(property.PropertyType.Name + " - " + property.Name);
            }

            ConstructorInfo[] constructors = T.GetConstructors();
            foreach (ConstructorInfo constructor in constructors)
            {
                liConstructors.Items.Add(constructor.ToString());
                
            }
           
            EventInfo[] eventInfos = T.GetEvents();
            foreach (EventInfo eventInfo in eventInfos)
            {
                lbEvent.Items.Add(eventInfo.Name+" "+eventInfo.MemberType);
            }


        }
    }
}
