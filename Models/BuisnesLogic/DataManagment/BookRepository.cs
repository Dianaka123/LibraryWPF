using LibraryApp.Models.BuisnesLogic.Abstractions;
using LibraryApp.Models.Entities;
using LibraryApp.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApp.Models.BuisnesLogic.DataManagment
{
    public class BookRepository: BaseRepository<Book>
    {
        public bool UpdateBook(Book oldBook, Book newBook)
        {
            var bookIndex = _records.IndexOf(oldBook);
            var isReplaced = false;

            if (bookIndex >= 0 && bookIndex < _records.Count)
            {
                _records[bookIndex] = newBook;
                isReplaced = true;
            }

            return isReplaced;
        }

        public IEnumerable<Book> GetBookByTitle(string title) => FindInRecords(b => b.Title, title);
    }
}
