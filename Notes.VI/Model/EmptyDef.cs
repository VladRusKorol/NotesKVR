using Notes.APL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.APL.Model
{
    public class EmptyDef: BaseINPC
    {
        private int _emptyDefinitionId;
        public int EmptyDefinitionId
        {
            get => _emptyDefinitionId;
            set => SetField(ref _emptyDefinitionId, value);
        }

        private string _emptyDefinitionTitle;
        public string EmptyDefinitionTitle
        {
            get => _emptyDefinitionTitle;
            set => SetField(ref _emptyDefinitionTitle, value);
        }

        private string _emptyDefinitionText;
        public string EmptyDefinitionText
        {
            get => _emptyDefinitionText;
            set => SetField(ref _emptyDefinitionText, value);
        }

        private int _emptyDefinitionOrderBy;
        public int EmptyDefinitionOrderBy
        {
            get => _emptyDefinitionOrderBy;
            set => SetField(ref _emptyDefinitionOrderBy, value);
        }

        private DateTime _emptyDefinitionCreatedAt;
        public DateTime EmptyDefinitionCreatedAt
        {
            get => _emptyDefinitionCreatedAt;
            set => SetField(ref _emptyDefinitionCreatedAt, value);
        }

        private DateTime _emptyDefinitionUpdateAt;
        public DateTime EmptyDefinitionUpdateAt
        {
            get => _emptyDefinitionCreatedAt;
            set => SetField(ref _emptyDefinitionCreatedAt, value);
        }



        private ICollection<EmptyImage>? _emptyDefinitionImages;
        public ICollection<EmptyImage>? EmptyDefinitionImages
        {
            get => _emptyDefinitionImages;
            set => SetField(ref _emptyDefinitionImages, value);
        }

        public EmptyDef() { }

        public EmptyDef(int prmId, string prmTitle, string prmText, int prmOrderBy, DateTime prmCreatedAt, DateTime prmUpdateAt)
        {
            this.EmptyDefinitionId = prmId;
            this.EmptyDefinitionTitle = prmTitle;
            this.EmptyDefinitionText = prmText;
            this.EmptyDefinitionOrderBy = prmOrderBy;
            this.EmptyDefinitionCreatedAt = prmCreatedAt;
            this.EmptyDefinitionUpdateAt = prmUpdateAt;
            this.EmptyDefinitionImages = null;
        }

        public EmptyDef(int prmId, string prmTitle, string prmText, int prmOrderBy, DateTime prmCreatedAt, DateTime prmUpdateAt, List<EmptyImage> prmImages)
        {
            this.EmptyDefinitionId = prmId;
            this.EmptyDefinitionTitle = prmTitle;
            this.EmptyDefinitionText = prmText;
            this.EmptyDefinitionOrderBy = prmOrderBy;
            this.EmptyDefinitionCreatedAt = prmCreatedAt;
            this.EmptyDefinitionUpdateAt = prmUpdateAt;
            this.EmptyDefinitionImages = prmImages;

        }
    }
}
