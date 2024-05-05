using Notes.APL.Common;
using Notes.APL.Common.FilterableObservableCollectionGeneric;
using Notes.APL.Model;
using Notes.APL.View.Windows.EmptyNoteToolWindow;
using Notes.APL.View.Windows.RegistrationWindow;
using Notes.BL;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Notes.APL.ViewModel
{
    public class NewNotesPage_ViewModel:BaseINPC
    {

        /*========================    КОНТЕКСТ    ======================*/
        private NotesContextBL _context = new NotesContextBL();


        private Visibility _stakcPanel_EmptyNotes_Visibility = Visibility.Visible;
        public Visibility StakcPanel_EmptyNotes_Visibility
        {
            get => _stakcPanel_EmptyNotes_Visibility;
            set => SetField(ref _stakcPanel_EmptyNotes_Visibility, value);
        }


        /*========================    НОВАЯ НАБЛЮДАЕМАЯ ФИЛЬТРУЕМАЯ КОЛЛЕКЦИЯ КОНСПЕКТОВ    ======================*/
        private FilterableObservableCollectionGeneric<NotesEmpty> _filterebleNotesEmpties = new FilterableObservableCollectionGeneric<NotesEmpty>();

        /*========================    РАБОТА С КОНСПЕКТАМИ    ======================*/
       
        //Переменная оглавления
        private string _title = String.Empty;
        public string Title { get => _title; set => SetField(ref _title, value); }
        
        //Переменная поисковой строки
        private string _searchValue = String.Empty;
        public string SearchValue 
        {
            get => _searchValue;
            set { SetField(ref _searchValue, value); this._filterebleNotesEmpties.OnFilterChanged(value);} 
        }
        
        //Наблюдаемая коллекция которая будет ссылаться на публичную коллекцию в FilterableObservableCollectionGeneric
        public ObservableCollection<NotesEmpty> _notesEmpties;
        public ObservableCollection<NotesEmpty> NotesEmpties
        {
            get => _notesEmpties;
            set => SetField(ref _notesEmpties, value);
        }

        //Отмеченный конспект в лист боксе
        private NotesEmpty _selectedNote;
        public NotesEmpty SelectedNote
        {
            get => _selectedNote;
            set => SetField(ref _selectedNote, value);
        }


       




        /*========================    КОММАНДЫ КЛАССА    ======================*/
        public LambdaCommand CommandCallEmptyNoteToolWindow_NewEmptyNote { get; set; }
        public LambdaCommand CommandCallEmptyNoteToolWindow_EditEmptyNote { get; set; }
        public LambdaCommand CommandDeleteEmptyNote { get; set; }
        public LambdaCommand CommandCollapsedEmptyNote { get; set; }







        public NewNotesPage_ViewModel()
        {
            this._filterebleNotesEmpties.FilterFieldName = "Title";
            this._filterebleNotesEmpties.getActualCollectionFromDB = updateObservableCollectionNotesEmpty;
            this._filterebleNotesEmpties.OnInitOrUpdateObservableCollections();
            this._notesEmpties = this._filterebleNotesEmpties._publicCollection;

            this.CommandCallEmptyNoteToolWindow_NewEmptyNote = new LambdaCommand(
                    canExecute: _ => true,
                    execute: _ => {
                        var emptyNoteToolWindow = new EmptyNoteToolWindow(this._context, (int)Application.Current.Resources["UserId"], 0, "New", "", this._filterebleNotesEmpties);
                        emptyNoteToolWindow.DataContext = this;
                        emptyNoteToolWindow.Show();
                    }
                   );

            this.CommandCallEmptyNoteToolWindow_EditEmptyNote = new LambdaCommand(
                    canExecute: _ => this.SelectedNote is not null,
                    execute: _ => {
                        var emptyNoteToolWindow = new EmptyNoteToolWindow(this._context, (int)Application.Current.Resources["UserId"], this.SelectedNote.Id, "Edit", this.SelectedNote.Title, this._filterebleNotesEmpties);
                        emptyNoteToolWindow.DataContext = this;
                        emptyNoteToolWindow.Show();
                    }
                   );
            this.CommandDeleteEmptyNote = new LambdaCommand(
                    canExecute: _ => this.SelectedNote is not null,
                    execute: _ => {
                        this._context.DeleteNote(SelectedNote.Id);
                        this._filterebleNotesEmpties.OnInitOrUpdateObservableCollections();
                    }
                   );
            this.CommandCollapsedEmptyNote = new LambdaCommand(
                    canExecute: _ => true,
                    execute: _ => {
                        this.StakcPanel_EmptyNotes_Visibility = Visibility.Collapsed;
                        var w = new Page();
                        w.Title = "Тук Тук";
                        w.Visibility = Visibility.Visible;
                        
                    }
                   );

        }



      



        /*========================    ФУНКЦИИ КЛАССА    ======================*/
        private ObservableCollection<NotesEmpty> updateObservableCollectionNotesEmpty()
        {
            int userId = (int)Application.Current.Resources["UserId"];
            var notes = _context.FindByIdPerson_return_PersonNotes(userId).Select(a => Mapper.MapFrom_NotesEmptyBLL_To_NotesEmptyAPL(a)).ToList();
            return new ObservableCollection<NotesEmpty>(notes);
        }

        private ObservableCollection<Definition> updateObservableCollectionDefinition()
        {
            int noteId = SelectedNote.Id;
            List<Definition> defList = _context.GetDefinitionsByIdNote(noteId).Select(Mapper.MapFrom_DefinitionsBLL_To_DefinitionsAPL).ToList();
            return new ObservableCollection<Definition>(defList);
        }





    }
}
