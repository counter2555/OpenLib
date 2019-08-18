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
            if (this.remarks.Text.Length > 0)
                this.checkRem.Checked = true;
            else
                this.checkRem.Checked = false;
        }

        private void Title_TextChanged(object sender, EventArgs e)
        {
            if (this.title.Text.Length > 0)
                this.checkTitle.Checked = true;
            else
                this.checkTitle.Checked = false;
        }

        private void Authors_TextChanged(object sender, EventArgs e)
        {
            if (this.authors.Text.Length > 0)
                this.checkAuthors.Checked = true;
            else
                this.checkAuthors.Checked = false;
        }

        private void Isbn_TextChanged(object sender, EventArgs e)
        {
            if (this.isbn.Text.Length > 0)
                this.checkISBN.Checked = true;
            else
                this.checkISBN.Checked = false;
        }

        private void Quantity_ValueChanged(object sender, EventArgs e)
        {
            if (this.quantity.Value > 0)
                this.checkQuant.Checked = true;
            else
                this.checkQuant.Checked = false;
        }

        private void Quantity_to_ValueChanged(object sender, EventArgs e)
        {
            this.checkQuant.Checked = true;
        }

        private void Desc_TextChanged(object sender, EventArgs e)
        {
            if (this.desc.Text.Length > 0)
                this.checkDesc.Checked = true;
            else
                this.checkDesc.Checked = false;
        }
    }
}
