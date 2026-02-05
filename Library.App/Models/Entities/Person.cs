using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.App.Models.Entities
{
    public abstract class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public virtual string FullName => $"{LastName} {Name} {Patronymic}".Trim();
    }
}
