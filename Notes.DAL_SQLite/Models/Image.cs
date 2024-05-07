using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.DAL_SQLite.Models
{
    public class Image
    {
        public int Id { get; set; }

        public byte[] ImageFile { get; set; }

        public string Title { get; set; }

        public int DefinitionId { get; set; }

        public Definition Definition { get; set; }
    }
}
