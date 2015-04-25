using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ReVerser2015.WebAPI.MyMail;

namespace ReVerser2015.WebAPI.MyMail_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mymc = new MyMailClient();
            textBox1.Text = mymc.SearchPeople(txtQuery.Text)[0].FirstName;
        }
    }
}
