using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//-------------------------------------
using ReVerser2015.WebAPI.YandexSearch;

namespace ReVerser2015.WebAPI.YandexSearch_Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YaSearchClient ysc = new YaSearchClient();
            var res = ysc.Search("bike", 0);
            for (int i = 0; i < res.Items.Length; i++)
            {
                listView1.Items.Add(res.Items[i].Title);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            YaSearchClient ysc = new YaSearchClient();
            ysc.SearchCompleted += (s, e2) => { };
            ysc.SearchAsync("bike", 0);
        }
    }
}
