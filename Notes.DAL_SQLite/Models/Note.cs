using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.DAL_SQLite.Models
{
    public class Note
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; }

        public int OrderBy { get; set; }

        public ICollection<Definition> Definitions { get; set; }
    }
}
