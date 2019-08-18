using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenLib
{
    public class Lease
    {
        public int Id, Quantity, BookId, UserId;
        public DateTime LeaseDate, ReturnDate;
        public bool Returned;
        public string Remarks;

        public string ISBN, Title, FirstName, LastName;

        public Lease(int id, int bookid, int userid, int quantity,
            DateTime from, DateTime to, bool returned, string rem,
            string isbn, string title, string fname, string lname)
        {
            this.Id = id;
            this.BookId = bookid;
            this.Quantity = quantity;
            this.UserId = userid;
            this.LeaseDate = from;
            this.ReturnDate = to;
            this.Returned = returned;
            this.Remarks = rem;

            this.ISBN = isbn;
            this.Title = title;
            this.FirstName = fname;
            this.LastName = lname;
        }

        public static Lease FromListView(ListViewItem lvi, DBHandler handler)
        {
            
            int id = Convert.ToInt32(lvi.SubItems[0].Text);

            string query = "SELECT * FROM dbo.Leases WHERE dbo.Leases.Id = @id";

            DBHandler.SQLParameter par = new DBHandler.SQLParameter();
            par.name = "@id";
            par.value = id;

            List<Lease> ls = handler.LeaseQuery(query, new DBHandler.SQLParameter[] { par });

            if (ls.Count > 0)
                return ls[0];
            else
                return null;
        }
    }
}
