using Notes.APL.Common;
using Notes.APL.Common.FilterableObservableCollectionGeneric;
using Notes.APL.Model;
using Notes.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Notes.APL.View.Windows.EmptyNoteToolWindow
{

    public partial class EmptyNoteToolWindow : Window
    {
        private NotesContextBL notesContextBL;
        private int UserId; 
        private int NoteId;
        private string ActionFlag;
        private FilterableObservableCollectionGeneric<NotesEmpty> localFilterebleNotesEmpties; 

        public EmptyNoteToolWindow(NotesContextBL _context, int userId, int noteId, string newActionFlag, string incomingValue, FilterableObservableCollectionGeneric<NotesEmpty> _filterebleNotesEmpties)
        {
            InitializeComponent();

            this.notesContextBL = _context;
            this.ActionFlag = newActionFlag; 
            this.UserId = userId;
            this.localFilterebleNotesEmpties = _filterebleNotesEmpties;
            this.NoteId = noteId;
            if(newActionFlag == "Edit") Input.Text = incomingValue; 
            
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e) 
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }


        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveEditNote(object sender, RoutedEventArgs e)
        {
            var inputValue = Input.Text;
            if (ActionFlag == "New") notesContextBL.AddNote(UserId, inputValue);
            else notesContextBL.EditNote(NoteId, inputValue);
            localFilterebleNotesEmpties.OnInitOrUpdateObservableCollections();
            this.Close();
        }


    }
}
