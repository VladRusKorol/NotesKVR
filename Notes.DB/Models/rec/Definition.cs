using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.DAL.Models.rec
{
    [Table("Definitions", Schema = "rec")]
    public class Definition
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Text { get; set; } = string.Empty;

        public int NoteId { get; set; }
        public Note Note { get; set; }

        public ICollection<Image> Images { get; set; }

    }
}
