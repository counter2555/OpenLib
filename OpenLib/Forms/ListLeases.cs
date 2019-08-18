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
    public partial class ListLeases : Form
    {
        private DBHandler db_handler;
        public ListLeases(DBHandler handler)
        {
            db_handler = handler;
            InitializeComponent();
        }

        void PopulateLeaseView(List<Lease> leases)
        {
            this.leaseView.Items.Clear();

            foreach(Lease l in leases)
            {
                string[] items =
                {
                    l.Id.ToString(),
                    l.ISBN,
                    l.Title,
                    l.Quantity.ToString(),
                    l.LeaseDate.ToString().Split(' ')[0],
                    l.ReturnDate.ToString().Split(' ')[0],
                    l.LastName,
                    l.FirstName
                };

                ListViewItem itm = new ListViewItem(items);

                if (l.Returned == false)
                {
                    DateTime now = DateTime.Now;
                    if(DateTime.Compare(now, l.ReturnDate) > 0)
                    {
                        itm.BackColor = Color.Red;
                    }
                    else
                        itm.BackColor = Color.Green;

                    itm.ForeColor = Color.White;
                }
                else
                {
                    itm.BackColor = Color.LightGray;
                }

                this.leaseView.Items.Add(itm);
            }
        }

        public void Search()
        {
            Forms.SearchLeases dlg = new SearchLeases();

            if(dlg.ShowDialog() == DialogResult.OK)
            {
                List<Lease> leases = db_handler.FindLeases(
                    dlg.title.Content, dlg.authors.Content, dlg.isbn.Content, dlg.description.Content,
                    dlg.remarks.Content, dlg.firstname.Content, dlg.lastname.Content,
                    dlg.title.Checked, dlg.authors.Checked, dlg.isbn.Checked,
                    dlg.description.Checked, dlg.remarks.Checked,
                    dlg.firstname.Checked, dlg.lastname.Checked);
                //List<Lease> leases = db_handler.FindLeaseByName(dlg.searchText.Text);
                PopulateLeaseView(leases);
            }
        }

        public void EditLease()
        {
            if(this.leaseView.SelectedItems.Count > 0)
            {
                Lease l = Lease.FromListView(this.leaseView.SelectedItems[0],
                    db_handler);

                Forms.CreateLease dlg = new CreateLease(db_handler);
                dlg.Text = "Edit Lease";

                dlg.bookid.Text = l.BookId.ToString();
                dlg.quantity.Value = l.Quantity;
                dlg.userid.Text = l.UserId.ToString();
                dlg.from.Value = l.LeaseDate;
                dlg.to.Value = l.ReturnDate;
                dlg.remarks.Text = l.Remarks;
                dlg.returned.Checked = l.Returned;

                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    l.BookId = Convert.ToInt32(dlg.bookid.Text);
                    l.Quantity = (int)dlg.quantity.Value;
                    l.UserId = Convert.ToInt32(dlg.userid.Text);
                    l.LeaseDate = dlg.from.Value;
                    l.ReturnDate = dlg.to.Value;
                    l.Remarks = dlg.remarks.Text;
                    l.Returned = dlg.returned.Checked;


                    db_handler.UpdateLease(l);
                    PopulateLeaseView();
                }

            }
        }

        public void DeleteLeases()
        {
            int count = this.leaseView.SelectedItems.Count;
            if (count > 0)
            {
                if (MessageBox.Show("Are you sure to delete " + count.ToString() + " entries?\nIt cannot be undone.",
                    "Deleting Leases", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    List<Lease> todel = new List<Lease>();
                    foreach (ListViewItem lvi in this.leaseView.SelectedItems)
                    {
                        Lease l = Lease.FromListView(lvi, db_handler);
                        todel.Add(l);
                    }

                    if (db_handler.DeleteLeases(todel))
                    {
                        MessageBox.Show(count.ToString() + " entries deleted successfully.", "Deleting Leases",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("An error occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    PopulateLeaseView();
                }
            }
        }

        void PopulateLeaseView()
        {
            List<Lease> leases = db_handler.GetAllLeases();
            PopulateLeaseView(leases);
        }

        private void ListLeases_Load(object sender, EventArgs e)
        {
            PopulateLeaseView();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            PopulateLeaseView();
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListView1_DoubleClick(object sender, EventArgs e)
        {
            EditLease();
        }

        private void EndLeaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EditLeaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditLease();
        }

        private void DeleteLeaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteLeases();
        }
    }
}
