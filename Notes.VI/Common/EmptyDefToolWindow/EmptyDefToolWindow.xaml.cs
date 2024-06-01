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

namespace Notes.APL.Common.EmptyDefToolWindow
{

    public partial class EmptyDefToolWindow : Window
    {
        private NotesContextBL notesContextBL;
        private int NoteId;
        private int DefId;
        private string ActionFlag;
        private FilterableObservableCollectionGeneric<EmptyDef> LocalFilterebleEmptiesDefs;

        public EmptyDefToolWindow(
                NotesContextBL prmContext
                ,int prmNoteId
                ,int prmDefId
                ,string prmActionFlag
                ,FilterableObservableCollectionGeneric<EmptyDef> prmFilterebleEmptiesDefs
            )
        {
            InitializeComponent();

            this.notesContextBL = prmContext;
            this.DefId = prmDefId;
            this.ActionFlag = prmActionFlag;
            this.LocalFilterebleEmptiesDefs = prmFilterebleEmptiesDefs;
            this.NoteId = prmNoteId;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            //WindowsOpenController.ChangeCountCloseThisWindow("EmptyNoteToolWindow");
            this.Close();
        }

        private void SaveEditDef(object sender, RoutedEventArgs e)
        {
            var newTitleValue = InputTitleDef.Text;
            var newDescValue = InputDescDef.Text;
            if (ActionFlag == "New") notesContextBL.AddDef(NoteId, newTitleValue, newDescValue);
            //else
            //{
            //    notesContextBL.EditNoteTitle(NoteId, inputValue);
            //    notesContextBL.EditNoteOrderBy(NoteId, Convert.ToInt32(InputOrder.Text));
            //}
            LocalFilterebleEmptiesDefs.OnInitOrUpdateObservableCollections();
            //this.localUpdateCount();
            //WindowsOpenController.ChangeCountCloseThisWindow("EmptyNoteToolWindow");
            this.Close();
        }

    }
}
