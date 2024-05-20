using Notes.BLL.Mappers;
using Notes.DAL_SQLite;
using System.Security.Cryptography.X509Certificates;

namespace Notes.BL
{
    public class NotesContextBL
    {
        private readonly NotesContext _notesDB;

        public NotesContextBL()
        {
            this._notesDB = new NotesContext();
        }

        public List<Notes.BLL.Models.Note> GetNotes()
        {
           return this._notesDB.Notes.OrderBy(o => o.OrderBy).Select(note => Mapper.DAL_to_BL_EmptyNotes(note)).ToList();
        }

        public void AddNote(string noteTitle)
        {
            int orderBy = this._notesDB.Notes.Count() != 0 ? this._notesDB.Notes.Max(note => note.OrderBy)  + 1 : 1;
            DAL_SQLite.Models.Note newNote = new DAL_SQLite.Models.Note
            {
                Title = noteTitle,
                OrderBy = orderBy,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            this._notesDB.Notes.Add(newNote);
            this._notesDB.SaveChanges();
        }

        public void DeleteNote(int NoteId)
        {
            List<DAL_SQLite.Models.Note> deleteNote = this._notesDB.Notes.Where(note => note.Id == NoteId).ToList();
            this._notesDB.Notes.Remove(deleteNote[0]);
            this._notesDB.SaveChanges();
        }

        public void EditNoteTitle(int NoteId, string newNoteTitle)
        {
            List<DAL_SQLite.Models.Note>? editNote = this._notesDB.Notes.Where(_ => _.Id == NoteId).ToList();
            if (editNote is not null) { 
                editNote[0].Title = newNoteTitle;
                editNote[0].UpdatedAt = DateTime.Now;
            }
            
            this._notesDB.SaveChanges();
        }

        public void EditNoteOrderBy(int NoteId, int newOrderBy)
        {

            /*  TODO доделать изменение сортировки указанием индекса    */



            /*  Проверяем что бы новый сортировочный индекс не равнялся текущему    */
            if(this._notesDB.Notes.Where(note => note.Id == NoteId).ToList()[0].OrderBy != newOrderBy)
            {
                var tmp = this._notesDB.Notes.Where(note => note.Id == NoteId).ToList();
                int oldOrderBy = 4; 
                List<DAL_SQLite.Models.Note> notes = this._notesDB.Notes.OrderBy(note => note.OrderBy).ToList();
                notes[NoteId].OrderBy = newOrderBy;
                /*   Если смещение сортировки идет ниже по списку   */
                if(oldOrderBy < newOrderBy)
                {
                    for(int i = 0; i < notes.Count; i++)
                    {
                        if (notes[i].OrderBy < oldOrderBy && notes[i].OrderBy > newOrderBy && notes[i].Id != NoteId) notes[i].OrderBy = notes[i].OrderBy - 1;
                        else if (notes[i].OrderBy > newOrderBy && notes[i].Id != NoteId) notes[i].OrderBy = notes[i].OrderBy + 1;
                    }
                }
                /*   Если смещение сортировки идет выше по списку   */
                else if (oldOrderBy > newOrderBy)
                {
                    for (int i = 0; i < notes.Count; i++)
                    {
                        if (notes[i].OrderBy < oldOrderBy && notes[i].OrderBy > newOrderBy && notes[i].Id != NoteId) notes[i].OrderBy = notes[i].OrderBy - 1;
                        else if (notes[i].OrderBy > newOrderBy && notes[i].Id != NoteId) notes[i].OrderBy = notes[i].OrderBy + 1;
                    }
                }

                this._notesDB.SaveChanges();
            }            
        }

        public void EditNoteOrderBy2(int NoteId, int newOrderBy)
        {
            List<DAL_SQLite.Models.Note>? editNote = this._notesDB.Notes.Where(_ => _.Id == NoteId).ToList();
        }

    }

}
