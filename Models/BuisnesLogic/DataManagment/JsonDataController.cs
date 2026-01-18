using LibraryApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models.BuisnesLogic.DataManagment
{
    public class JsonDataController: IDataController
    {

        public void AddUser(Reader user)
        {

        }

        public Reader UpdateUser(Reader user)
        {
            return null;
        }

        public void DeleteUser(Reader user) { }

        public void AddBook(Book book) { }

        public Book UpdateBook(Book book)
        {
            return null;
        }

        public void DeleteBook(Book book) { }

        public void AddAuthor(Author author) { }
        public Author UpdateAuthor(Author author)
        { 
            return null;
        }
        public void DeleteAuthor(Author author) { }
    }
}
