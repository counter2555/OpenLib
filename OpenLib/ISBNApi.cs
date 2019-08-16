using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace OpenLib
{
    class ISBNApi
    {
        private WebClient wclient;

        public ISBNApi()
        {
            this.wclient = new WebClient();
        }

        public Book GetBookByISBN(string isbn)
        {
            try
            {
                string json = this.wclient.DownloadString("https://openlibrary.org/api/books?bibkeys=ISBN:" + isbn + "&jscmd=details&format=json");

                Newtonsoft.Json.Linq.JObject o = Newtonsoft.Json.Linq.JObject.Parse(json);
                var ob = o["ISBN:" + isbn]["details"];
                string title = (string)ob["title"];
                var authors = ob["authors"];
                string sauthor = string.Empty;

                if (authors != null)
                {
                    foreach (var a in authors)
                    {
                        sauthor += (string)a["name"] + ", ";
                    }
                }
                sauthor = sauthor.TrimEnd(' ').TrimEnd(',');

                string desc = (string)ob["description"];

                Book b = new Book(-1, title, sauthor, isbn, desc, string.Empty, 1);
                return b;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Failed to fetch book online.");
                return null;//new Book(string.Empty, string.Empty, string.Empty, string.Empty);
            }

        }

        public static string CleanISBN(string isbn)
        {
            isbn = isbn.ToLower().Replace("isbn", "").Replace(" ", "").Replace("-", "").Trim();
            return isbn;
        }
    }
}
