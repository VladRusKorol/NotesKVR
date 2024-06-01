using Notes.APL.Common;
using Notes.APL.Common.EmptyDefToolWindow;
using Notes.APL.Common.EmptyNoteToolWindow;
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

        

        /*========================    НОВАЯ НАБЛЮДАЕМАЯ ФИЛЬТРУЕМАЯ КОЛЛЕКЦИЯ КОНСПЕКТОВ    ======================*/
        private FilterableObservableCollectionGeneric<EmptyDef> _filterebleDefEmpties = new FilterableObservableCollectionGeneric<EmptyDef>();
        public ObservableCollection<EmptyDef> _emptiesDef;
        public ObservableCollection<EmptyDef> EmptiesDef
        {
            get => _emptiesDef;
            set => SetField(ref _emptiesDef, value);
        }

        //Переменная поисковой строки
        private string _searchField;
        public string SearchField
        {
            get => _searchValue;
            set 
                { 
                    SetField(ref _searchValue, value); 
                    if(value == "НАЗВАНИЮ") this._filterebleDefEmpties.FilterFieldName = "EmptyDefinitionTitle";
                    else if(value == "ОПИСАНИЮ") this._filterebleDefEmpties.FilterFieldName = "EmptyDefinitionText";
            }
        }


        private EmptyDef _selectedEmptyDef;
        public EmptyDef SelectedEmptyDef
        {
            get => _selectedEmptyDef;
            set => SetField(ref _selectedEmptyDef, value);
        }

        //Переменная поисковой строки
        private string _searchValue;
        public string SearchValue
        {
            get => _searchValue;
            set { SetField(ref _searchValue, value); this._filterebleDefEmpties.OnFilterChanged(value); }
        }




        private ObservableCollection<string> _cmbContent = new ObservableCollection<string>() { "НАЗВАНИЮ", "ОПИСАНИЮ" };
        public ObservableCollection<string> CmbContent
        {
            get => _cmbContent;
            set { SetField(ref _cmbContent, value); }
        }

        public LambdaCommand CommandNewDef { get; set; } 


        public NoteViewViewModel() 
        {
            NoteName = _context.GetNoteName((int)Application.Current.Resources["SelectedNoteId"]);

            this._filterebleDefEmpties.FilterFieldName = this._searchField;
            this._filterebleDefEmpties.getActualCollectionFromDB = updateObservableCollectionEmptyDef;
            this._filterebleDefEmpties.OnInitOrUpdateObservableCollections();
            this._emptiesDef = this._filterebleDefEmpties._publicCollection;

            this.CommandNewDef = new LambdaCommand(
                    canExecute: _ => true,
                    execute: _ => {
                        var emptyDefToolWindow = new EmptyDefToolWindow(this._context, (int)Application.Current.Resources["SelectedNoteId"], 0, "New", this._filterebleDefEmpties);
                        //emptyDefToolWindow.DataContext = this;
                        emptyDefToolWindow.Show();
                        //updateCount();
                    }
                   );


        }

        /*========================    ФУНКЦИИ КЛАССА    ======================*/
        private ObservableCollection<EmptyDef> updateObservableCollectionEmptyDef()
        {
            var defs = this._context.GetDefinitions().Select(a => Mapper.BLL_to_APL_EmptDef(a)).ToList();
            return new ObservableCollection<EmptyDef>(defs);
        }


    }
}
