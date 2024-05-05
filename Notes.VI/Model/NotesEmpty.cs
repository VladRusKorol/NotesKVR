using Notes.APL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Notes.APL.Model
{
    public class NotesEmpty: BaseINPC
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => SetField(ref _id, value);
        }

        private string? _title;
        public string? Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }

        private int _personId;
        public int PersonId
        {
            get => _personId;
            set => SetField(ref _personId, value);
        }

        private readonly DateTime _createdAt;
        public DateTime CreatedAt
        {
            get => _createdAt;
        }

        private DateTime _updatedAt;
        public DateTime UpdatedAt
        {
            get => _updatedAt;
            set => SetField(ref _updatedAt, value);
        }
        
        private Visibility _visibility;
        public Visibility Visibility
        {
            get => _visibility;
            set => SetField(ref _visibility, value);
        }

        public NotesEmpty() 
        { 
            
        }

        public NotesEmpty(int prmId, string prmTitle, int prmPersonId, DateTime prmCreatedAt, DateTime prmUpdatedAt)
        {
            this._id = prmId;
            this._title = prmTitle;
            this._personId = prmPersonId;
            this._createdAt = prmCreatedAt;
            this._updatedAt = prmUpdatedAt;
            this._visibility = Visibility.Visible;
        }
    }
}
