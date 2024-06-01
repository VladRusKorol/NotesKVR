using Notes.APL.Common;
using Notes.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Notes.APL.ViewModel
{
    public class NoteViewViewModel: BaseINPC
    {
        private NotesContextBL _context = new NotesContextBL();


        private string _noteName;
        public string NoteName
        {
            get => _noteName;
            set => SetField(ref _noteName, value);
        }



        public NoteViewViewModel() 
        {
            NoteName = _context.GetNoteName((int)Application.Current.Resources["SelectedNoteId"]);

        }
    }
}
