using LibraryApp.Models.BuisnesLogic.Abstractions;
using LibraryApp.Models.Entities;
using LibraryApp.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApp.Models.BuisnesLogic.DataManagment
{
    public class ReaderRepository: BaseRepository<Reader>
    {
        public IEnumerable<Reader> FindReaderByName(string name) => FindInRecords(r => r.Name, name);
    }
}
