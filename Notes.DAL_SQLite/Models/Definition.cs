using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.DAL_SQLite.Models
{
    public class Definition
    {
        public int Id { get; set; }

        public string Title { get; set; } 

        public string Text { get; set; }

        public int OrderBy { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; }

        public int NoteId { get; set; }

        public Note Note { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
