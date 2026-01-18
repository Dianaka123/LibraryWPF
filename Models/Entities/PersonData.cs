using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models.Entities
{
    public abstract class PersonData
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public virtual string GetFullName => $"{LastName} {Name} {Patronymic}".Trim();

    }
}
