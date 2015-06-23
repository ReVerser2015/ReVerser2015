using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//-------------------------------
using ReVerser2015.WebAPI;

namespace ReVerser2015.WebAPI_Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client c = new Client();
            MessageBox.Show(c.Get("http://b-s-b.info/").ToHTML().DocumentNode.GetElementByTagName("img").OuterHTML);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var wc = new System.Net.WebClient();
            wc.DownloadString("http://b-s-b.info/");
        }
    }
}
