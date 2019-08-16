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
    public partial class AddBook : Form
    {
        private ISBNApi isbn_api;
        public AddBook()
        {
            isbn_api = new ISBNApi();
            InitializeComponent();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            this.isbn.BackColor = Color.White;
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        public string CleanISBN(string isbn)
        {
            isbn = isbn.ToLower().Replace("isbn", "").Replace(" ", "").Replace("-", "").Trim();
            return isbn;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string isbn = CleanISBN(this.isbn.Text);
            Book b = isbn_api.GetBookByISBN(isbn);
            if (b != null)
            {
                this.title.Text = b.Title;
                this.authors.Text = b.Author;
                this.desc.Text = b.Description;
                this.isbn.Text = b.ISBN;
            }
            else
            {
                this.isbn.BackColor = Color.Red;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void AddBook_Load(object sender, EventArgs e)
        {

        }

        private void Isbn_Leave(object sender, EventArgs e)
        {
            this.isbn.Text = CleanISBN(this.isbn.Text);
        }
    }
}
