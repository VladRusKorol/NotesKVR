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

namespace Notes.APL.ViewModel
{
    public class NotesPagesViewModel : BaseINPC
    {
        private NotesContextBL _context = new NotesContextBL();

        /*  =======================================================Секция переменных работающих с Конспектами=======================================================================*/
        private NotesEmpty _selectedNote;
        public NotesEmpty SelectedNote
        {
            get => _selectedNote;
            set => SetField(ref _selectedNote, value);
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }

        private string _inputText;
        public string InputText
        {
            get => _inputText;
            set => SetField(ref _inputText, value);
        }

        private string _inputEditText;
        public string InputEditText
        {
            get => _inputEditText;
            set => SetField(ref _inputEditText, value);
        }

        //Search panel



        private ObservableCollection<NotesEmpty> _notesEmpties;
        public ObservableCollection<NotesEmpty> NotesEmpties
        {
            get => _notesEmpties;
            set => SetField(ref _notesEmpties, value);
        }


        private FilterableObservableCollectionGeneric<NotesEmpty> _filterebleNotesEmpties = new FilterableObservableCollectionGeneric<NotesEmpty>();
        public FilterableObservableCollectionGeneric<NotesEmpty> FilterebleNotesEmpties
        {
            get => _filterebleNotesEmpties;
            set => SetField(ref _filterebleNotesEmpties, value);
        }

        private string _searchPanelValue;
        public string SearchPanelValue
        {
            get => _searchPanelValue;
            set
            {
                SetField(ref _searchPanelValue, value);
            }
        }



        /*  ========================================================================Секция переменных работающих с Терминами=======================================================*/
        private ObservableCollection<Definition> _definitions;
        public ObservableCollection<Definition> Definitions
        {
            get => _definitions;
            set => SetField(ref _definitions, value);
        }

        private Definition _selectedDefinition;
        public Definition SelectedDefinition
        {
            get => _selectedDefinition;
            set {

                SetField(ref _selectedDefinition, value);
                if(value != null)
                {
                    DefinitionTitle = _selectedDefinition.DefinitionTitle;
                    DefinitionText = _selectedDefinition.DefinitionText;
                }
                else
                {
                    DefinitionTitle = "";
                    DefinitionText = "";
                }
            }
        }

        private string _definitionTitle;
        public string DefinitionTitle
        {
            get => _definitionTitle;
            set => SetField(ref _definitionTitle, value);
        }

        private string _definitionText;
        public string DefinitionText
        {
            get => _definitionText;
            set => SetField(ref _definitionText, value);
        }

        private ObservableCollection<APL.Model.Image> _definitionImages;
        public ObservableCollection<APL.Model.Image> DefinitionImages
        {
            get => _definitionImages;
            set => SetField(ref _definitionImages, value);
        }


        //  Секция настройка видимости элементов 

        private Visibility _grid_ToolBar_ManagNotes_Visibility = Visibility.Collapsed;
        public Visibility Grid_ToolBar_ManagNotes_Visibility
        {
            get => _grid_ToolBar_ManagNotes_Visibility;
            set => SetField(ref _grid_ToolBar_ManagNotes_Visibility, value);
        }

        private Visibility _grid_ToolBar_EditNotes_Visibility = Visibility.Collapsed;
        public Visibility Grid_ToolBar_EditNotes_Visibility
        {
            get => _grid_ToolBar_ManagNotes_Visibility;
            set => SetField(ref _grid_ToolBar_ManagNotes_Visibility, value);
        }


        private Visibility _stackPanel_ListNotes_Visibility = Visibility.Visible;
        public Visibility StackPanel_ListNotes_Visibility
        {
            get => _stackPanel_ListNotes_Visibility;
            set => SetField(ref _stackPanel_ListNotes_Visibility, value);
        }

        private Visibility _stackPanel_ListDefinitions_Visibility = Visibility.Collapsed;
        public Visibility StackPanel_ListDefinitions_Visibility
        {
            get => _stackPanel_ListDefinitions_Visibility;
            set => SetField(ref _stackPanel_ListDefinitions_Visibility, value);
        }







        /* ============================================================================================Секция Комманд =========================================================*/
        public LambdaCommand CommandVisibleAddNoteTextBox { get; set; }
        public LambdaCommand CommandNotVisibleAddNoteTextBox { get; set; }
        public LambdaCommand CommandAddNote { get; set; }
        public LambdaCommand CommandDeleteSelectedNote { get; set; }
        public LambdaCommand CommandVisibleEditTextBox { get; set; }
        public LambdaCommand CommandNotVisibleEditTextBox { get; set; }
        public LambdaCommand CommandEditSelectedNote { get; set; }

        public LambdaCommand Command_Visible_List_Definitions { get; set; }
        public LambdaCommand Command_UnVisible_List_Definitions { get; set; }
        public LambdaCommand Command_Edit_Definition { get; set; }
        public LambdaCommand Command_Add_New_Definition { get; set; }
        public LambdaCommand Command_Delete_Definition { get; set; }




        public NotesPagesViewModel()
        {

            NotesEmpties = updateObservableCollectionNotesEmpty();
            FilterebleNotesEmpties.FilterFieldName = "Title";
            FilterebleNotesEmpties.getActualCollectionFromDB = updateObservableCollectionNotesEmpty;
            FilterebleNotesEmpties.OnInitOrUpdateObservableCollections(); 


            //--------------Инициализация Комманд-----------------------------------------

            this.CommandVisibleAddNoteTextBox = new LambdaCommand( canExecute: _ => true, execute: _ => Grid_ToolBar_ManagNotes_Visibility = Visibility.Visible);

            this.CommandNotVisibleAddNoteTextBox = new LambdaCommand(canExecute: _ => true, execute: _ => Grid_ToolBar_ManagNotes_Visibility = Visibility.Collapsed);

            this.CommandAddNote = new LambdaCommand(
                    canExecute: _ => this._inputText != null || this._inputText != "",
                    execute: _ => 
                    {
                        this._context.AddNote((int)Application.Current.Resources["UserId"], InputText);
                        InputText = "";
                        Grid_ToolBar_ManagNotes_Visibility = Visibility.Collapsed;
                        NotesEmpties = updateObservableCollectionNotesEmpty();
                    }
                );

            this.CommandDeleteSelectedNote = new LambdaCommand(
                    canExecute: _ => SelectedNote is not null,
                    execute: _ =>
                    {
                        this._context.DeleteNote(SelectedNote.Id);
                        NotesEmpties = updateObservableCollectionNotesEmpty();
                    }
                );

            this.CommandVisibleEditTextBox = new LambdaCommand(
                    canExecute: _ => SelectedNote is not null,
                    execute: _ =>
                    {
                        Grid_ToolBar_EditNotes_Visibility = Visibility.Visible;
                        InputEditText = SelectedNote.Title;
                    }
                );

            this.CommandNotVisibleEditTextBox = new LambdaCommand(
                    canExecute: _ => true,
                    execute: _ =>
                    {
                        Grid_ToolBar_EditNotes_Visibility = Visibility.Collapsed;
                        InputEditText = "";
                    }
                );

            this.CommandEditSelectedNote = new LambdaCommand(
                    canExecute: _ => InputEditText is not null && InputEditText != "",
                    execute: _ =>
                    {
                        this._context.EditNote(SelectedNote.Id, InputEditText);
                        Grid_ToolBar_EditNotes_Visibility = Visibility.Collapsed;
                        InputEditText = "";
                        NotesEmpties = updateObservableCollectionNotesEmpty();
                    }
                );

            this.Command_Visible_List_Definitions = new LambdaCommand(
                    canExecute: _ => SelectedNote is not null,
                    execute: _ =>
                    {
                        Definitions = updateObservableCollectionDefinition();
                        SearchPanelValue = "";
                        StackPanel_ListNotes_Visibility = Visibility.Collapsed;
                        StackPanel_ListDefinitions_Visibility = Visibility.Visible;
                    }
                );

            this.Command_UnVisible_List_Definitions = new LambdaCommand(
                    canExecute: _ => SelectedNote is not null,
                    execute: _ =>
                    {
                        StackPanel_ListNotes_Visibility = Visibility.Visible;
                        StackPanel_ListDefinitions_Visibility = Visibility.Collapsed;
                    }
                );

            this.Command_Edit_Definition = new LambdaCommand(
                    canExecute: _ => SelectedDefinition is not null,
                    execute: _ =>
                    {
                        this._context.EditDefinition(SelectedDefinition.IdDefinition, SelectedDefinition.DefinitionTitle, SelectedDefinition.DefinitionText);
                    }
                );

            this.Command_Add_New_Definition = new LambdaCommand(
                    canExecute: _ => true,
                    execute: _ =>
                    {
                        if( SelectedDefinition is null )
                        {
                            this._context.AddDefinition(SelectedNote.Id, "Задайте термин", "Задайте описание");
                            Definitions = updateObservableCollectionDefinition();
                        }
                        else
                        {
                            this._context.AddDefinition(SelectedNote.Id, SelectedDefinition.DefinitionTitle, SelectedDefinition.DefinitionText);
                            Definitions = updateObservableCollectionDefinition();
                        }
                        
                    }
                );

            this.Command_Delete_Definition = new LambdaCommand(
                    canExecute: _ => SelectedDefinition is not null,
                    execute: _ =>
                    {
                        this._context.DelDefinition(SelectedDefinition.IdDefinition);
                        Definitions = updateObservableCollectionDefinition();
                    }
                );

        }

        

        private ObservableCollection<NotesEmpty>  updateObservableCollectionNotesEmpty()
        {
            int userId = (int)Application.Current.Resources["UserId"];

            var notes = _context.FindByIdPerson_return_PersonNotes(userId)
                .Select(a => Mapper.MapFrom_NotesEmptyBLL_To_NotesEmptyAPL(a))
                .ToList();

            return new ObservableCollection<NotesEmpty>(notes);
        }

        private List<NotesEmpty> updateListNotesEmpty()
        {
            int userId = (int)Application.Current.Resources["UserId"];

            var notes = _context.FindByIdPerson_return_PersonNotes(userId)
                .Select(a => Mapper.MapFrom_NotesEmptyBLL_To_NotesEmptyAPL(a))
                .ToList();

            return notes;
        }


        private ObservableCollection<Definition> updateObservableCollectionDefinition()
        {
            int noteId = SelectedNote.Id;

            List<Definition> defList = _context.GetDefinitionsByIdNote(noteId)
                                .Select(Mapper.MapFrom_DefinitionsBLL_To_DefinitionsAPL)
                                .ToList();

            return new ObservableCollection<Definition>(defList);
        }



    }



}
