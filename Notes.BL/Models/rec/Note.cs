using Notes.BLL.Models.dic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Notes.BLL.Models.rec
{
    public class Note
    {
        public int Id { get; set; } 
        
        public int PersonId { get; set; } 

        public string Title { get; set; } 

        public DateTime CreatedAt { get; set; } 

        public DateTime UpdatedAt { get; set; } 

        public ICollection<Definition> Definitions { get; set; } 


        public Note()
        {

        }

        public Note(int prmId)
        {
            this.Id = prmId;
        }

        public Note(int prmId, int prmPersonId)
        {
            this.Id = prmId;
            this.PersonId = prmPersonId;
        }

        public Note(int prmId, int prmPersonId, string prmTitle)
        {
            this.Id = prmId;
            this.PersonId = prmPersonId;
            this.Title = prmTitle;
        }

        public Note(int prmId, int prmPersonId, string prmTitle, DateTime prmCreatedAt)
        {
            this.Id = prmId;
            this.PersonId = prmPersonId;
            this.Title = prmTitle;
            this.CreatedAt = prmCreatedAt;
        }

        public Note(int prmId, int prmPersonId, string prmTitle, DateTime prmCreatedAt, DateTime prmUpdateAt)
        {
            this.Id = prmId;
            this.PersonId = prmPersonId;
            this.Title = prmTitle;
            this.CreatedAt = prmCreatedAt;
            this.UpdatedAt = prmUpdateAt;
        }

        public Note(int prmId, int prmPersonId, string prmTitle, DateTime prmCreatedAt, DateTime prmUpdateAt, List<Definition> prmDefinitions)
        {
            this.Id = prmId;
            this.PersonId = prmPersonId;
            this.Title = prmTitle;
            this.CreatedAt = prmCreatedAt;
            this.UpdatedAt = prmUpdateAt;
            this.Definitions = prmDefinitions;
        }



    }
}
