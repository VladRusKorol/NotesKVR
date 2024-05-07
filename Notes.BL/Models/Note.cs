using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.BLL.Models
{
    public class Note
    {
        public int NoteId { get; set; }

        public string NoteTitle { get; set; }

        public int NoteOrderBy { get; set; }

        public DateTime NoteCreatedAt { get; set; }

        public DateTime NoteUpdatedAt { get; set; }

        public ICollection<Definition>? NoteDefinitions { get; set; }

        public Note(int prmId, string prmTitle, int prmOrderBy, DateTime prmCreatedAt, DateTime prmUpdatedAt)
        {
            this.NoteId = prmId;
            this.NoteTitle = prmTitle;  
            this.NoteOrderBy = prmOrderBy;
            this.NoteCreatedAt = prmCreatedAt;
            this.NoteUpdatedAt = prmUpdatedAt;
            this.NoteDefinitions = null;
        }

        public Note(int prmId, string prmTitle, int prmOrderBy, DateTime prmCreatedAt, DateTime prmUpdatedAt, ICollection<Definition> prmDefinitions)
        {
            this.NoteId = prmId;
            this.NoteTitle = prmTitle;
            this.NoteOrderBy = prmOrderBy;
            this.NoteCreatedAt = prmCreatedAt;
            this.NoteUpdatedAt = prmUpdatedAt;
            this.NoteDefinitions = prmDefinitions;
        }
    }
}
