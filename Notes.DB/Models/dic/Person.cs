using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.DAL.Models.dic
{

    [Table("Persons", Schema = "dic")]
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; } 

        public string LastName { get; set; } 

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; } 

        public ICollection<Notes.DAL.Models.rec.Note> Notes { get; set; }
    }
}


/*
      [Table("Persons", Schema = "dic")] - Объявляем аннотацию, в которой  указываем название таблицы и принадженость к определенной схеме в БД
      [Key] - Указываем что это поле - первичный ключ
      [Column("Id_Person",Order = 0, TypeName = 'nvarchar(150)')] - Объявлем название колонки и порядок
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)] - Указываем свойство, которое дублирует атрибут поля как в бд IDENTY(1,1) 
      [Required] - это NOT NULL
      [ForeignKey("dic.Email")] - объявление внешнего ключа на первичный ключ указываемой таблицы
*/