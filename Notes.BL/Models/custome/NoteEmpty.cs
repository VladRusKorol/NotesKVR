using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.BLL.Models.custome
{
    public class NoteEmpty
    {
        public int Id { get; set; } 

        public int PersonId { get; set; } 

        public string Title { get; set; } 

        public DateTime CreatedAt { get; set; } 

        public DateTime UpdatedAt { get; set; } 

        public NoteEmpty()
        {

        }

        public NoteEmpty(int prmId)
        {
            this.Id = prmId;
        }

        public NoteEmpty(int prmId, int prmPersonId)
        {
            this.Id = prmId;
            this.PersonId = prmPersonId;
        }

        public NoteEmpty(int prmId, int prmPersonId, string prmTitle)
        {
            this.Id = prmId;
            this.PersonId = prmPersonId;
            this.Title = prmTitle;
        }

        public NoteEmpty(int prmId, int prmPersonId, string prmTitle, DateTime prmCreatedAt)
        {
            this.Id = prmId;
            this.PersonId = prmPersonId;
            this.Title = prmTitle;
            this.CreatedAt = prmCreatedAt;
        }

        public NoteEmpty(int prmId, int prmPersonId, string prmTitle, DateTime prmCreatedAt, DateTime prmUpdateAt)
        {
            this.Id = prmId;
            this.PersonId = prmPersonId;
            this.Title = prmTitle;
            this.CreatedAt = prmCreatedAt;
            this.UpdatedAt = prmUpdateAt;
        }

    }
}
