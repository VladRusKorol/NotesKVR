using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.APL.Common
{
    static public class Mapper
    {
        public static Notes.APL.Model.EmptyNote BLL_to_APL_EmptyNotes(BLL.Models.Note note)
        {
            return new Notes.APL.Model.EmptyNote(note.NoteId, note.NoteTitle, note.NoteOrderBy, note.NoteCreatedAt, note.NoteUpdatedAt);
        }
    }
}
