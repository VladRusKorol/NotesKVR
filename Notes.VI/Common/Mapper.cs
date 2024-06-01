using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.APL.Common
{
    static public class Mapper
    {
        public static Notes.APL.Model.EmptyNote BLL_to_APL_EmptyNotes(BLL.Models.Note n)
        {
            return new Notes.APL.Model.EmptyNote(n.NoteId, n.NoteTitle, n.NoteOrderBy, n.NoteCreatedAt, n.NoteUpdatedAt);
        }

        public static Notes.APL.Model.EmptyImage BLL_to_APL_EmptyImage(BLL.Models.Image i)
        {
            if (i.ImageTitle != null)
            {
                return new Notes.APL.Model.EmptyImage(
                    i.ImageId,
                    i.ImageFile,
                    i.ImageTitle
                );
            }
            else
            {
                return new Notes.APL.Model.EmptyImage(
                    i.ImageId,
                    i.ImageFile
                );
            }
        }

        public static Notes.APL.Model.EmptyDef BLL_to_APL_EmptDef(BLL.Models.Definition d) 
        {
            if (d.DefinitionImages != null)
            {
                return new Notes.APL.Model.EmptyDef(
                    d.DefinitionId,
                    d.DefinitionTitle,
                    d.DefinitionText,
                    d.DefinitionOrderBy,
                    d.DefinitionDateCreatedAt,
                    d.DefinitionDateUpdateAt,
                    d.DefinitionImages.Select(BLL_to_APL_EmptyImage).ToList()

                );
            }
            else
            {
                return new Notes.APL.Model.EmptyDef(
                    d.DefinitionId,
                    d.DefinitionTitle,
                    d.DefinitionText,
                    d.DefinitionOrderBy,
                    d.DefinitionDateCreatedAt,
                    d.DefinitionDateUpdateAt
                );
            }
        }



    }


}
