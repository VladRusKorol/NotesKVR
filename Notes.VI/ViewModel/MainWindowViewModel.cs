using Notes.APL.Common;
using Notes.APL.Common.EmptyNoteToolWindow;
using Notes.APL.Common.FilterableObservableCollectionGeneric;
using Notes.APL.Model;
using Notes.BL;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Notes.APL.ViewModel
{
    public class MainWindowViewModel : BaseINPC
    {

        /*========================    КОНТЕКСТ    ======================*/
        private NotesContextBL _context = new NotesContextBL();


        /*========================    НОВАЯ НАБЛЮДАЕМАЯ ФИЛЬТРУЕМАЯ КОЛЛЕКЦИЯ КОНСПЕКТОВ    ======================*/
        private FilterableObservableCollectionGeneric<EmptyNote> _filterebleNotesEmpties = new FilterableObservableCollectionGeneric<EmptyNote>();

        /*========================    РАБОТА С КОНСПЕКТАМИ    ======================*/

        //Переменная поисковой строки
        private string _searchValue = String.Empty;
        public string SearchValue
        {
            get => _searchValue;
            set { SetField(ref _searchValue, value); this._filterebleNotesEmpties.OnFilterChanged(value); }
        }

        private int _notesCount; 
        public int NotesCount
        {
            get => _notesCount;
            set => SetField(ref _notesCount, value);
        }


        //Наблюдаемая коллекция которая будет ссылаться на публичную коллекцию в FilterableObservableCollectionGeneric
        public ObservableCollection<EmptyNote> _notesEmpties;
        public ObservableCollection<EmptyNote> NotesEmpties
        {
            get => _notesEmpties;
            set => SetField(ref _notesEmpties, value);
        }

        //Отмеченный конспект в лист боксе
        private EmptyNote _selectedNote;
        public EmptyNote SelectedNote
        {
            get => _selectedNote;
            set => SetField(ref _selectedNote, value);
        }


        /*========================    КОММАНДЫ КЛАССА    ======================*/
        public LambdaCommand CommandCallEmptyNoteToolWindow_NewEmptyNote { get; set; }
        public LambdaCommand CommandCallEmptyNoteToolWindow_EditEmptyNote { get; set; }
        public LambdaCommand CommandDeleteEmptyNote { get; set; }
        public LambdaCommand CommandCollapsedEmptyNote { get; set; }







        public MainWindowViewModel()
        {
            this._filterebleNotesEmpties.FilterFieldName = "NoteTitle"; 
            this._filterebleNotesEmpties.getActualCollectionFromDB = updateObservableCollectionNotesEmpty;
            this._filterebleNotesEmpties.OnInitOrUpdateObservableCollections();
            this._notesEmpties = this._filterebleNotesEmpties._publicCollection;
            updateCount();

            this.CommandCallEmptyNoteToolWindow_NewEmptyNote = new LambdaCommand(
                    canExecute: _ => true,
                    execute: _ => {
                        var emptyNoteToolWindow = new EmptyNoteToolWindow(this._context,  0, "New", "", 0, this._filterebleNotesEmpties, updateCount);
                        emptyNoteToolWindow.DataContext = this;
                        emptyNoteToolWindow.Show();
                        updateCount();
                    }
                   );

            this.CommandCallEmptyNoteToolWindow_EditEmptyNote = new LambdaCommand(
                    canExecute: _ => this.SelectedNote is not null,
                    execute: _ => {
                        var emptyNoteToolWindow = new EmptyNoteToolWindow(this._context,  this.SelectedNote.NoteId, "Edit", this.SelectedNote.NoteTitle, this.SelectedNote.NoteOrderBy, this._filterebleNotesEmpties, updateCount);
                        emptyNoteToolWindow.DataContext = this;
                        emptyNoteToolWindow.Show();
                        updateCount();
                    }
                   );
            this.CommandDeleteEmptyNote = new LambdaCommand(
                    canExecute: _ => this.SelectedNote is not null,
                    execute: _ => {
                        this._context.DeleteNote(SelectedNote.NoteId);
                        this._filterebleNotesEmpties.OnInitOrUpdateObservableCollections();
                        updateCount();
                    }
                   );

            //this.CommandCollapsedEmptyNote = new LambdaCommand(
            //        canExecute: _ => true,
            //        execute: _ => {
            //            this.StakcPanel_EmptyNotes_Visibility = Visibility.Collapsed;
            //            var w = new Page();
            //            w.Title = "Тук Тук";
            //            w.Visibility = Visibility.Visible;

            //        }
            //       );

        }







        /*========================    ФУНКЦИИ КЛАССА    ======================*/
        private ObservableCollection<EmptyNote> updateObservableCollectionNotesEmpty()
        {
            var notes = this._context.GetNotes().Select(a => Mapper.BLL_to_APL_EmptyNotes(a)).ToList(); 
            return new ObservableCollection<EmptyNote>(notes);
        }

        private void updateCount()
        {
            NotesCount = this._context.getCountNote(); 
        }


        //private ObservableCollection<Definition> updateObservableCollectionDefinition()
        //{
        //    int noteId = SelectedNote.Id;
        //    List<Definition> defList = _context.GetDefinitionsByIdNote(noteId).Select(Mapper.MapFrom_DefinitionsBLL_To_DefinitionsAPL).ToList();
        //    return new ObservableCollection<Definition>(defList);
        //}





    }
}