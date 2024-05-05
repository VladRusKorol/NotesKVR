using Notes.DAL.Models.dic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Notes.BLL.Models.dic
{
    public class Person
    {
        public int                                    Id              { get; set; }

        public string                                 FirstName       { get; set; }

        public string                                 LastName        { get; set; }

        public string                                 Email           { get; set; }

        public string                                 Password        { get; set; }
        
        public string                                 PhoneNumber     { get; set; }

        public Role                                   Role            { get; set; }

        public ICollection<Notes.BLL.Models.rec.Note> Notes           { get; set; }

        public Person()
        {

        }
    }
}
