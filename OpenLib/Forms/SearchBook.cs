using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpenLib.Forms
{
    public partial class SearchBook : OpenLib.Forms.AddBook
    {
        public SearchBook()
        {
            InitializeComponent();
        }

        private void Remarks_TextChanged(object sender, EventArgs e)
        {
            this.checkRem.Checked = true;
        }

        private void Title_TextChanged(object sender, EventArgs e)
        {
            this.checkTitle.Checked = true;
        }

        private void Authors_TextChanged(object sender, EventArgs e)
        {
            this.checkAuthors.Checked = true;
        }

        private void Isbn_TextChanged(object sender, EventArgs e)
        {
            this.checkISBN.Checked = true;
        }

        private void Quantity_ValueChanged(object sender, EventArgs e)
        {
            this.checkQuant.Checked = true;
        }

        private void Quantity_to_ValueChanged(object sender, EventArgs e)
        {
            this.checkQuant.Checked = true;
        }

        private void Desc_TextChanged(object sender, EventArgs e)
        {
            this.checkDesc.Checked = true;
        }
    }
}
