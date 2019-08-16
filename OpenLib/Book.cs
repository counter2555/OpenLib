using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLib
{
    class Book
    {
        public string Title, Author;
        public string ISBN;
        public string Description;

        public Book(string title, string author, string isbn, string desc)
        {
            this.Title = title;
            this.Author = author;
            this.ISBN = isbn;
            this.Description = desc;
        }
    }
}
