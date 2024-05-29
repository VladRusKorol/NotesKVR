using Notes.APL.Common;
using Notes.APL.Common.FilterableObservableCollectionGeneric;
using Notes.APL.Model;
using Notes.BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Notes.APL.Common.EmptyNoteToolWindow
{

    public delegate void updateCountNotes();

    public partial class EmptyNoteToolWindow : Window
    {
        private NotesContextBL notesContextBL;
        private int NoteId;
        private string ActionFlag;
        private FilterableObservableCollectionGeneric<EmptyNote> localFilterebleNotesEmpties;
        private int OrderValue;
        private updateCountNotes localUpdateCount; 

        public EmptyNoteToolWindow(
            NotesContextBL _context, 
            int noteId, 
            string newActionFlag, 
            string incomingValue, 
            int incomingOrderValue, 
            FilterableObservableCollectionGeneric<EmptyNote> _filterebleNotesEmpties, 
            updateCountNotes updateCount
        )
        {
            InitializeComponent();

            this.notesContextBL = _context;
            this.ActionFlag = newActionFlag;
            this.localFilterebleNotesEmpties = _filterebleNotesEmpties;
            this.NoteId = noteId;
            this.OrderValue = incomingOrderValue;
            this.localUpdateCount = updateCount;

            if (newActionFlag == "Edit") {
                Input.Text = incomingValue;
                InputOrder.Text = Convert.ToString(incomingOrderValue);
                StackOrderBy.Visibility = Visibility.Visible;
            }
            else {
                StackOrderBy.Visibility = Visibility.Collapsed;
                EmptyNoteToolWindowName.Height = 145;
            }
            

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
            if (ActionFlag == "New") notesContextBL.AddNote(inputValue);
            else {
                notesContextBL.EditNoteTitle(NoteId, inputValue);
                notesContextBL.EditNoteOrderBy(NoteId, Convert.ToInt32(InputOrder.Text));
            }
            localFilterebleNotesEmpties.OnInitOrUpdateObservableCollections();
            this.localUpdateCount();
            this.Close();
        }


    }
}