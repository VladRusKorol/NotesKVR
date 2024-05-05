using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.DAL.Models.rec
{
    [Table("Images", Schema = "rec")]
    public class Image
    {
        public int Id { get; set; }

        [Column("Image_File", Order = 1, TypeName = "varbinary(max)")]
        public byte[] ImageFile { get; set; }

        public string Title { get; set; } 

        public int DefinitionId { get; set; }
        public Definition Definition { get; set; } 
    }
}
