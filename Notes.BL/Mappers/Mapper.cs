using Notes.BLL.Models;
using Notes.DAL_SQLite.Models;

namespace Notes.BLL.Mappers
{
    public static class Mapper
    {

        public static Notes.BLL.Models.Image DAL_to_BLL_Images(DAL_SQLite.Models.Image i)
        {
            if (i.Title != null)
            {
                return new Notes.BLL.Models.Image(
                    i.Id, 
                    i.ImageFile, 
                    i.Title
                );
            } 
            else
            {
                return new Notes.BLL.Models.Image(
                    i.Id, 
                    i.ImageFile
                );
            }
            
        }

        public static Notes.BLL.Models.Definition DAL_to_BLL_Definitions(DAL_SQLite.Models.Definition d)
        {
            if (d.Images != null)
            {
                return new Notes.BLL.Models.Definition(
                    d.Id, 
                    d.Title, 
                    d.Text, 
                    d.OrderBy,
                    d.CreatedAt, 
                    d.UpdatedAt,
                    d.Images.Select(DAL_to_BLL_Images).ToList()
                    
                );
            }
            else
            {
                return new Notes.BLL.Models.Definition(
                    d.Id,
                    d.Title,
                    d.Text,
                    d.OrderBy,
                    d.CreatedAt,
                    d.UpdatedAt
                );
            }
            
        }

        public static Notes.BLL.Models.Note DAL_to_BL_EmptyNotes(DAL_SQLite.Models.Note n)
        {
            return new Notes.BLL.Models.Note(n.Id, n.Title, n.OrderBy, n.CreatedAt, n.UpdatedAt);
        }

        

    }
}
