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

        public int  getCountNote()
        {
            return this._notesDB.Notes.Count();
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

            //Запрашиваем запись в которой хотим изменить индекс сортировки
            int? currentOrderBy = this._notesDB.Notes.Where(n => n.Id == NoteId).FirstOrDefault().OrderBy;
            //Получем максимальный индекс сортировки что бы не выйти за пределы индекса сортировки
            int maxOrderBy = this._notesDB.Notes.Count();
            

            //Если мы получили запись, и при этом индекс отличется и не выход за пределы массива то изменяем
            if (currentOrderBy is not null && currentOrderBy != newOrderBy && newOrderBy >= 1 && newOrderBy <= maxOrderBy)
            {
                string vector = currentOrderBy < newOrderBy ? "up" : "down";
                List<DAL_SQLite.Models.Note> currentNoteList = this._notesDB.Notes.OrderBy(n => n.OrderBy).ToList();

                if (vector == "up")
                {
                    for (int i = 0; i < currentNoteList.Count; i++)
                    {
                        if (currentNoteList[i].OrderBy < currentOrderBy) { }

                        else if (currentNoteList[i].OrderBy > newOrderBy) { }

                        else if (currentNoteList[i].OrderBy == currentOrderBy) currentNoteList[i].OrderBy = newOrderBy;

                        else if (currentNoteList[i].OrderBy > currentOrderBy && currentNoteList[i].OrderBy <= newOrderBy) currentNoteList[i].OrderBy = currentNoteList[i].OrderBy - 1;

                    }
                }
                else
                {
                    for (int i = 0; i < currentNoteList.Count; i++)
                    {
                        if (currentNoteList[i].OrderBy < newOrderBy) { }

                        else if (currentNoteList[i].OrderBy > currentOrderBy) { }

                        else if (currentNoteList[i].OrderBy == currentOrderBy) currentNoteList[i].OrderBy = newOrderBy;

                        else if (currentNoteList[i].OrderBy < currentOrderBy && currentNoteList[i].OrderBy >= newOrderBy) currentNoteList[i].OrderBy = currentNoteList[i].OrderBy + 1;
                    }

                }
            }
            else
            {
              
            }
            this._notesDB.SaveChanges();
        }


    }

}
