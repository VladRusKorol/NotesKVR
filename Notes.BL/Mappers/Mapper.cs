using Microsoft.EntityFrameworkCore;
using Notes.BLL.Models.custome;
using Notes.BLL.Models.dic;
using Notes.BLL.Models.rec;
using Notes.DAL;
using Notes.DAL.Models.dic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Notes.BLL.Mappers
{
    public static class Mapper
    {
        public static AuthorizedAccount MapFrom_PersonDAL_To_AuthorizedAccountBLL(DAL.Models.dic.Person account)
        {
            return new AuthorizedAccount(account.Id ,account.FirstName, account.LastName, account.Email, account.Password, account.RoleId);
        }

        public static UsersInfo MapFrom_PersonDAL_To_UsersInfo(DAL.Models.dic.Person p)
        {
            return new UsersInfo(p.Id, p.FirstName, p.LastName, p.Email,  p.Password, p.Role.RoleName, p.PhoneNumber);
        }

        public static BLL.Models.custome.NoteEmpty MapFor_PersonNoteDefinitionImageDAL_To_NoteBLL(DAL.Models.rec.Note note)
        {
            return new NoteEmpty(note.Id, note.PersonId, note.Title, note.CreatedAt, note.UpdatedAt);
        }

        public static BLL.Models.rec.Image MapFrom_ImageDAL_To_ImageBLL(DAL.Models.rec.Image i)
        {
            return new BLL.Models.rec.Image(i.Id,i.ImageFile,i.Title);
        }

        public static BLL.Models.rec.Definition MapFrom_DefinitionDAL_To_DefinitionBLL(DAL.Models.rec.Definition d)
        {
            List<BLL.Models.rec.Image>? ListImage = null; 
            if (d.Images != null)
            {
                ListImage = d.Images.Select(MapFrom_ImageDAL_To_ImageBLL).ToList();
            }
           
            return new Definition(d.Id, d.Title, d.Text, ListImage);
        }
    }
}
