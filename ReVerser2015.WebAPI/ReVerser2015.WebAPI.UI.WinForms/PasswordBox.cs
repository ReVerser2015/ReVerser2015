using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReVerser2015.WebAPI.UI.WinForms
{
    public partial class PasswordBox : UserControl
    {
        char _passwordCharBuf;

        public PasswordBox()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_Resize(object sender, EventArgs e)
        {
            this.Height = maskedTextBox1.Height;
        }

        public MaskedTextBox GetMaskedTextBox()
        {
            return maskedTextBox1;
        }

        public Button GetShowHideButton()
        {
            return button1;
        }

        public bool ShowHideButtonVisible
        {
            get
            {
                return button1.Visible;
            }
            set
            {
                button1.Visible = value;
            }
        }

        public string Text
        {
            get
            {
                return maskedTextBox1.Text;
            }
            set
            {
                maskedTextBox1.Text = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.PasswordChar != '\0')
            {
                _passwordCharBuf = maskedTextBox1.PasswordChar;
                maskedTextBox1.PasswordChar = '\0';
            }
            else
            {
                maskedTextBox1.PasswordChar = _passwordCharBuf;
            }
        }
    }
}
