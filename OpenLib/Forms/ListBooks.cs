﻿using System;
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
    public partial class ListBooks : Form
    {
        private DBHandler db_handler;
        public ListBooks(DBHandler handler)
        {
            db_handler = handler;
            InitializeComponent();
        }

        public void PopulateListView(List<Book> books)
        {
            this.listView1.Items.Clear();
            foreach(Book b in books)
            {
                string[] items =
                {
                    b.Id.ToString(),
                    b.ISBN,
                    b.Quantity.ToString(),
                    b.Title,
                    b.Author,
                    b.Description,
                    b.Remarks
                };

                ListViewItem itm = new ListViewItem(items);
                this.listView1.Items.Add(itm);
            }
        }

        public void PopulateListView()
        {
            PopulateListView(db_handler.GetAllBooks());
        }

        public void AddBook()
        {
            Forms.AddBook dlg = new Forms.AddBook();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string isbn = dlg.CleanISBN(dlg.isbn.Text);
                string title = dlg.title.Text;
                string author = dlg.authors.Text;
                string desc = dlg.desc.Text;
                string rem = dlg.remarks.Text;
                int quant = (int)dlg.quantity.Value;

                Book b = new Book(-1, title, author, isbn, desc, rem, quant);

                if (!db_handler.AddBook(b))
                    MessageBox.Show("An error occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PopulateListView();
            }
        }

        public void EditBook()
        {
            if(this.listView1.SelectedItems.Count > 0)
            {
                Book b = Book.FromListView(this.listView1.SelectedItems[0]);
                Forms.EditBook dlg = new EditBook();

                dlg.title.Text = b.Title;
                dlg.authors.Text = b.Author;
                dlg.isbn.Text = b.ISBN;
                dlg.quantity.Value = b.Quantity;
                dlg.desc.Text = b.Description;
                dlg.remarks.Text = b.Remarks;

                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    b.Title = dlg.title.Text;
                    b.Author = dlg.authors.Text;
                    b.ISBN = dlg.isbn.Text;
                    b.Quantity = (int)dlg.quantity.Value;
                    b.Description = dlg.desc.Text;
                    b.Remarks = dlg.remarks.Text;

                    if (!db_handler.UpdateBook(b))
                        MessageBox.Show("An error occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PopulateListView();
                }
            }
        }

        public void DeleteSelectedBooks()
        {
            int count = this.listView1.SelectedItems.Count;
            if(count > 0)
            {
                if(MessageBox.Show("Are you sure to delete "+count.ToString()+" entries?\nIt cannot be undone.",
                    "Deleting Books", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    List<Book> todel = new List<Book>();
                    foreach(ListViewItem lvi in this.listView1.SelectedItems)
                    {
                        Book b = Book.FromListView(lvi);
                        todel.Add(b);
                    }

                    if(db_handler.DeleteBooks(todel))
                    {
                        MessageBox.Show(count.ToString() + " entries deleted successfully.", "Deleting Books",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("An error occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    PopulateListView();
                }
            }
        }

        public void SearchBook()
        {
            Forms.SearchBook dlg = new SearchBook();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                List<Book> finds = db_handler.SearchBooks(dlg.title.Text,
                    dlg.authors.Text,
                    dlg.isbn.Text,
                    (int)dlg.quantity.Value, (int)dlg.quantity_to.Value,
                    dlg.desc.Text,
                    dlg.remarks.Text,
                    dlg.checkTitle.Checked,
                    dlg.checkAuthors.Checked,
                    dlg.checkISBN.Checked,
                    dlg.checkQuant.Checked,
                    dlg.checkDesc.Checked,
                    dlg.checkRem.Checked);

                if (finds != null)
                {
                    PopulateListView(finds);
                }
                else
                    this.listView1.Items.Clear();
            }
        }

        private void ListBooks_Load(object sender, EventArgs e)
        {
            PopulateListView();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            AddBook();
        }

        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditBook();
        }

        private void AddBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBook();
        }

        private void EditBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditBook();
        }

        private void DeleteBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedBooks();
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            SearchBook();
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            PopulateListView();
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            EditBook();
        }
    }
}
