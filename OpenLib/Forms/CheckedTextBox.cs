using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenLib.Forms
{
    public partial class CheckedTextBox : UserControl
    {
        public CheckedTextBox()
        {
            InitializeComponent();
        }

        public bool Checked
        {
            get
            {
                return this.checkBox1.Checked;
            }
            set
            {
                this.checkBox1.Checked = value;
            }
        }

        public string Label
        {
            get
            {
                return this.label1.Text;
            }
            set
            {
                this.label1.Text = value;
            }
        }

        public string Content
        {
            get
            {
                return this.textBox1.Text;
            }
            set
            {
                this.textBox1.Text = value;
            }
        }

        public Color TextBackColor
        {
            get
            {
                return this.textBox1.BackColor;
            }
            set
            {
                this.textBox1.BackColor = value;
            }
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Length > 0)
                this.checkBox1.Checked = true;
            else
                this.checkBox1.Checked = false;
        }
    }
}
