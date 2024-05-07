using Notes.BLL.Models;
using Notes.DAL_SQLite.Models;

namespace Notes.BLL.Mappers
{
    public static class Mapper
    {
        public static Notes.BLL.Models.Image DAL_to_BLL_Images(DAL_SQLite.Models.Image image)
        {
            if (image.Title != null) return new Notes.BLL.Models.Image( image.Id ,image.ImageFile ,image.Title);
            return new Notes.BLL.Models.Image(image.Id, image.ImageFile);
        }

        public static Notes.BLL.Models.Definition DAL_to_BLL_Definitions(DAL_SQLite.Models.Definition definition)
        {

            if (definition.Images != null) return new Notes.BLL.Models.Definition(definition.Id, definition.Title, definition.Text, definition.Images.Select(DAL_to_BLL_Images).ToList());
            return new Notes.BLL.Models.Definition(definition.Id, definition.Title, definition.Text);
        }

        public static Notes.BLL.Models.Note DAL_to_BL_Notes(DAL_SQLite.Models.Note note)
        {
            return new Notes.BLL.Models.Note(note.Id, note.Title, note.OrderBy, note.CreatedAt, note.UpdatedAt);
        }
    }
}
