using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public ReadOnlyCollection<Author> Authors { get; set; }
        public ReadOnlyCollection<Genre> Genres { get; set; }
        public string Description { get; set; }
    }

    public enum Genre
    {
        Action,
        Adventure,
        Comedy,
        Crime,
        Mystery,
        Fantasy,
        Historical,
        Horror,
        Romance,
        Satire,
        ScienceFiction,
        Cyberpunk,
        Thriller,
        Western,
        Fairytale
    }
}
