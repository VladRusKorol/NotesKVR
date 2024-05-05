using Notes.DAL.Models.rec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.BLL.Models.rec
{
    public class Definition
    {
        public int? DefinitionId { get; set; } = null;

        public string DefinitionTitle { get; set; } = string.Empty;

        public string DefinitionText { get; set; } = string.Empty;

        public ICollection<Image>? DefinitionImages { get; set; }

        public Definition(int prmId, string prmTitle, string prmText, List<Image> prmImages)
        {
            this.DefinitionId = prmId;
            this.DefinitionTitle = prmTitle;  
            this.DefinitionText = prmText;    
            this.DefinitionImages = prmImages;    
        }

    }
}
