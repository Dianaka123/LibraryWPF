using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models.Entities
{
    public class Reader: PersonData
    {
        public int Id { get; set; }

        public DateTime Birthday { get; set; }
        public string Address { get; set; }
    }
}
