using Notes.APL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.APL.Model
{
    public class Image: BaseINPC
    {
        private int _imageId;
        public int ImageId 
        { 
            get => _imageId; 
            set => SetField(ref _imageId, value);  
        }

        private byte[] _imageFile;
        public byte[] ImageFile
        {
            get => _imageFile;
            set => SetField(ref _imageFile, value);
        }

        private string _imageTitle;
        public string ImageTitle
        {
            get => _imageTitle;
            set => SetField(ref _imageTitle, value);
        }

        public Image(int prmId, byte[] prmImageFile, string prmTitle)
        {
            this._imageId = prmId;
            this._imageFile = prmImageFile;
            this._imageTitle = prmTitle;
        }
    }
}
