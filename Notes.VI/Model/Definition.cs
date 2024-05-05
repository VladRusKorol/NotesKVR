using Microsoft.Identity.Client;
using Notes.APL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.APL.Model
{
    public class Definition: BaseINPC 
    {
        private int _definitionId;
        public int IdDefinition
        {
            get => _definitionId;
            set => SetField(ref _definitionId, value);
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

        private List<Image>? _definitionImages;
        public List<Image>? DefinitionImages
        {
            get => _definitionImages;
            set => SetField(ref _definitionImages, value);
        }

        public Definition(int prmId, string prmTitle, string prmText, List<Image> prmImages)
        {
            this._definitionId = prmId;
            this._definitionTitle = prmTitle;
            this._definitionText = prmText;
            this._definitionImages = prmImages;
        }
    }
}
