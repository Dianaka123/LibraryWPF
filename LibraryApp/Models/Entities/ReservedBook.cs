using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models.Entities
{
    public class ReservedBook
    {
        public int Id { get; set; }

        public Book Book { get; set; }
        public Reader Reader { get; set; }

        public DateTime ReservedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }

        public DateTime ShouldBeReturnedDate { get; set; }
    }
}
