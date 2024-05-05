using Notes.APL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.APL.Common
{
    static public class Mapper
    {
        public static CheckAuthorizedAccount_Model MapFrom_AuthorizedAccountBLL_To_AuthorizedAccountAPL(int userId, string firstName, string lastName, string emailAdress, string password, int roleid)
        {
            return new CheckAuthorizedAccount_Model(userId, firstName, lastName, emailAdress, password, roleid);
        }

        public static UsersInfo MapFrom_UsersInfoBLL_To_UsersInfoAPL(int userId, string firstName, string lastName, string email, string password, string role, string phoneNumber)
        {
            return new UsersInfo(userId, firstName, lastName, email, password, role, phoneNumber);
        }

        public static NotesEmpty MapFrom_NotesEmptyBLL_To_NotesEmptyAPL(BLL.Models.custome.NoteEmpty noteEmpty)
        {
            return new NotesEmpty(noteEmpty.Id, noteEmpty.Title, noteEmpty.PersonId, noteEmpty.CreatedAt, noteEmpty.UpdatedAt);
        }

        public static APL.Model.Image MapFrom_ImageBLL_To_ImageAPL(BLL.Models.rec.Image i)
        {
            return new APL.Model.Image(i.ImageId, i.ImageFile, i.ImageTitle);
        }

        public static APL.Model.Definition MapFrom_DefinitionsBLL_To_DefinitionsAPL(BLL.Models.rec.Definition d)
        {
            List<Image>? imgs = null;
            if (d.DefinitionImages != null)
            {
                imgs = d.DefinitionImages.Select(i => MapFrom_ImageBLL_To_ImageAPL(i)).ToList();
            }

            return new APL.Model.Definition((int)d.DefinitionId, d.DefinitionTitle, d.DefinitionText, imgs);
        }
    }
}
