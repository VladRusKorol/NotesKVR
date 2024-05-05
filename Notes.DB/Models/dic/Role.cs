using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Notes.DAL.Models.dic
{
    [Table("Roles", Schema = "dic")]
    public class Role
    { 
        public int Id { get; set; }
        public string RoleName { get; set; } = string.Empty;
    }
}
