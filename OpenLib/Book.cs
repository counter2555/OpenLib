using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenLib
{
    public class Book
    {
        public string Title, Author;
        public string ISBN;
        public string Description;
        public int Quantity;
        public string Remarks;
        public int Id;
        public int Borrowed;

        public Book(int id, string title, string author, string isbn, string desc, string remarks, int quantity)
        {
            this.Title = title;
            this.Author = author;
            this.ISBN = isbn;
            this.Description = desc;
            this.Quantity = quantity;
            this.Remarks = remarks;
            this.Id = id;
            this.Borrowed = 0;
        }

        public Book(int id, string title, string author, string isbn, string desc, string remarks, int quantity,
            int borrowed)
        {
            this.Title = title;
            this.Author = author;
            this.ISBN = isbn;
            this.Description = desc;
            this.Quantity = quantity;
            this.Remarks = remarks;
            this.Id = id;
            this.Borrowed = borrowed;

        }


        public static Book FromListView(ListViewItem lvi)
        {
            int id = Convert.ToInt32(lvi.SubItems[0].Text);
            string isbn = lvi.SubItems[1].Text;
            int quant = Convert.ToInt32(lvi.SubItems[2].Text);
            int borrowed = Convert.ToInt32(lvi.SubItems[3].Text);
            string title = lvi.SubItems[4].Text;
            string author = lvi.SubItems[5].Text;

            string desc = lvi.SubItems[6].Text;
            string rem = lvi.SubItems[7].Text;

            Book b = new Book(id, title, author, isbn,
                desc, rem, quant, borrowed);
            return b;
        }
    }
}
