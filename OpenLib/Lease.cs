using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
