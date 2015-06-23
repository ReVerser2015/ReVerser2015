namespace ReVerser2015.WebAPI.UI.WinForms
{
    partial class AuthBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.passwordBox1 = new ReVerser2015.WebAPI.UI.WinForms.PasswordBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // passwordBox1
            // 
            this.passwordBox1.Location = new System.Drawing.Point(3, 80);
            this.passwordBox1.Name = "passwordBox1";
            this.passwordBox1.ShowHideButtonVisible = true;
            this.passwordBox1.Size = new System.Drawing.Size(187, 20);
            this.passwordBox1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(187, 20);
            this.textBox1.TabIndex = 1;
            // 
            // AuthBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.passwordBox1);
            this.Name = "AuthBox";
            this.Size = new System.Drawing.Size(334, 248);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PasswordBox passwordBox1;
        private System.Windows.Forms.TextBox textBox1;


    }
}
