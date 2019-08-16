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
    public partial class ScanISBN : Form
    {
        private DBHandler db_handler;
        public int BookId=-1;
        public ScanISBN(DBHandler handler)
        {
            db_handler = handler;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //9780980200447
            string isbn = ISBNApi.CleanISBN(this.textBox1.Text);
            this.textBox1.Text = isbn;
            string query = "SELECT * FROM dbo.Books WHERE ISBN=@isbn";

            DBHandler.SQLParameter par = new DBHandler.SQLParameter();
            par.name = "@isbn";
            par.value = isbn;

            List<Book> books = db_handler.BookQuery(query, new DBHandler.SQLParameter[] { par });

            if(books.Count > 0)
            {
                this.BookId = books[0].Id;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("No book found with that ISBN",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
