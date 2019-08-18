using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenLib.Forms
{
    public partial class SearchBooks : Form
    {
        public SearchBooks()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string isbn = this.isbn.Content;
            isbn = ISBNApi.CleanISBN(isbn);

            
        }
    }
}
