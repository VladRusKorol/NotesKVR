using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Notes.APL.Common.FilterableObservableCollectionGeneric
{
    /*  делегат инциализации коллекции через БД */
    public delegate ObservableCollection<T> GetActualCollectionFromDB<T>();

    /*  Опредение класса */
    public class FilterableObservableCollectionGeneric<T> : ObservableCollection<T> where T : INotifyPropertyChanged, new()
    {

        private ObservableCollection<T>? _originCollection = null;
        public  ObservableCollection<T>? _publicCollection = null;

        private string _filterFieldName = "";
        public string FilterFieldName { get => _filterFieldName; set => this._filterFieldName = value; } 

        public GetActualCollectionFromDB<T>? getActualCollectionFromDB;


        /*  Default CTOR*/
        public FilterableObservableCollectionGeneric() { }


        /*  Инициализация коллекция из БД */
        public void OnInitOrUpdateObservableCollections()
        {
            /*  Работаем с оригинальной коллекцией */
            if (this._originCollection == null)
            {
                this._originCollection = getActualCollectionFromDB();
            }
            else
            {
                this._originCollection.Clear();
                this._originCollection = getActualCollectionFromDB();
            }


            
            
            if (this._publicCollection == null)
            {
                this._publicCollection = new ObservableCollection<T>();
                foreach (var item in this._originCollection)
                {
                    this._publicCollection.Add(item);
                }

                //this._publicCollection = getActualCollectionFromDB();
            }
            else
            {
                this._publicCollection.Clear();
                foreach (var item in this._originCollection)
                {
                    this._publicCollection.Add(item);
                }
            }
            
        }


        /*  Функция, которая проверяет, содержит ли подаваемый класс необходимое поле */ 
        /* +++ */
        private bool IsClassContainsProperty()
        {
            bool result = false;
            foreach (var prop in typeof(T).GetProperties())
            {
                if (prop.Name == FilterFieldName) 
                {
                    result = true; 
                    break;
                }          
            }
            return result;
        }


        /*  функция проверяет подходит ли элемент   */ 
        /* +++ */
        private bool isMatchingItem(T item, string searchValue)
        {
            bool result = false;
            if (IsClassContainsProperty())
            {
                foreach (var prop in item.GetType().GetProperties())
                {
                    if (prop.Name == FilterFieldName)
                    {
                        var a = prop.GetValue(item, null);
                        if (a.ToString().ToLower().Contains(searchValue.ToLower(), StringComparison.OrdinalIgnoreCase))
                        {
                            result = true; break;
                        }
                    }  
                }
            }
            return result;
        }


        /* функция которая постоянно модифицирует публичную коллекцию  */
        public void OnFilterChanged(string searchValue)
        {
            if(String.IsNullOrWhiteSpace(searchValue) || searchValue == "")
            {
               if(this._publicCollection is not null)
               {
                    this._publicCollection.Clear();
                    foreach (var item in this._originCollection)
                    {
                        this._publicCollection.Add(item);
                    }
               }
            }
            else
            {
                IEnumerable<T> collection = this._originCollection.Where(item => isMatchingItem(item, searchValue));
                if (collection is not null && this._publicCollection is not null)
                {
                    this._publicCollection.Clear();
                    foreach (var item in collection)
                    {
                        this._publicCollection.Add(item);
                    }
                }
            }
        }




    }


    

    

}
