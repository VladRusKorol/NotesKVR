using Notes.APL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.APL.Model
{
    public class EmptyNote: BaseINPC
    {
        private int _noteId;
        public int NoteId
        {
            get => _noteId;
            set => SetField(ref _noteId, value);
        }

        private string _noteTitle;
        public string NoteTitle
        {
            get => _noteTitle;
            set => SetField(ref _noteTitle, value);
        }

        private int _noteOrderBy;
        public int NoteOrderBy
        {
            get => _noteOrderBy;
            set => SetField(ref _noteOrderBy, value);
        }

        private readonly DateTime _noteCreatedAt;
        public DateTime NoteCreatedAt
        {
            get => _noteCreatedAt;
        }

        private DateTime _noteUpdatedAt;
        public DateTime NoteUpdatedAt
        {
            get => _noteUpdatedAt;
            set => SetField(ref _noteUpdatedAt, value);
        }

        public EmptyNote() { }

        public EmptyNote(int prmId, string prmTitle, int prmNoteOrderBy, DateTime prmCreatedAt, DateTime prmUpdatedAt)
        {
            this._noteId = prmId;
            this._noteTitle = prmTitle;
            this._noteOrderBy = prmNoteOrderBy;
            this._noteCreatedAt = prmCreatedAt;
            this._noteUpdatedAt = prmUpdatedAt;
        }
    }
}
