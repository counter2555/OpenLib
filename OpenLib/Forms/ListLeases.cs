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

        void PopulateListView(List<Lease> leases)
        {
            this.listView1.Items.Clear();

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
                this.listView1.Items.Add(itm);
            }
        }

        public void Search()
        {
            Forms.SearchDialog dlg = new SearchDialog();

            if(dlg.ShowDialog() == DialogResult.OK)
            {
                List<Lease> leases = db_handler.FindLeaseByName(dlg.searchText.Text);
                PopulateListView(leases);
            }
        }

        void PopulateListView()
        {
            List<Lease> leases = db_handler.GetAllActiveLeases();
            PopulateListView(leases);
        }

        private void ListLeases_Load(object sender, EventArgs e)
        {
            PopulateListView();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            PopulateListView();
        }
    }
}
