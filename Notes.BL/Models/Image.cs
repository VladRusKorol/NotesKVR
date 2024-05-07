using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.BLL.Models
{
    public class Image
    {
        public int ImageId { get; set; }

        public byte[] ImageFile { get; set; }

        public string? ImageTitle { get; set; } = string.Empty;

        public Image(int prmId, byte[] prmImageFile, string prmTitle)
        {
            this.ImageId = prmId;
            this.ImageFile = prmImageFile;
            this.ImageTitle = prmTitle;
        }

        public Image(int prmId, byte[] prmImageFile)
        {
            this.ImageId = prmId;
            this.ImageFile = prmImageFile;
            this.ImageTitle = null;
        }

    }
}
