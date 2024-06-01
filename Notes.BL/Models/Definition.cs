using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.BLL.Models
{
    public class Definition
    {
        public int DefinitionId { get; set; }

        public string DefinitionTitle { get; set; }

        public string DefinitionText { get; set; } 

        public int DefinitionOrderBy { get; set; }

        public DateTime DefinitionDateCreatedAt { get; set; }

        public DateTime DefinitionDateUpdateAt { get; set; }

        public ICollection<Image>? DefinitionImages { get; set; }

        public Definition(int prmId, string prmTitle,  string prmText, int prmOrderBy, DateTime prmCreatedAt, DateTime prmUpdatedAt)
        {
            this.DefinitionId = prmId;
            this.DefinitionTitle = prmTitle;
            this.DefinitionText = prmText;
            this.DefinitionOrderBy = prmOrderBy;
            this.DefinitionDateCreatedAt = prmCreatedAt;
            this.DefinitionDateUpdateAt = prmUpdatedAt;
            this.DefinitionImages = null;
        }

        public Definition(int prmId, string prmTitle, string prmText, int prmOrderBy, DateTime prmCreatedAt, DateTime prmUpdatedAt, List<Image> prmImages)
        {
            this.DefinitionId = prmId;
            this.DefinitionTitle = prmTitle;
            this.DefinitionText = prmText;
            this.DefinitionOrderBy = prmOrderBy;
            this.DefinitionDateCreatedAt = prmCreatedAt;
            this.DefinitionDateUpdateAt = prmUpdatedAt;
            this.DefinitionImages = prmImages;
        }
    }
}
