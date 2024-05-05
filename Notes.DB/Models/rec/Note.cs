using Microsoft.EntityFrameworkCore.Diagnostics;
using Notes.DAL.Models.dic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Notes.DAL.Models.rec
{
    [Table("Notes", Schema = "rec")]
    public class Note
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public int PersonId { get; set; }
        public Person Person { get; set; }      

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set;}

        public ICollection<Definition> Definitions { get; set; }

    }
}
