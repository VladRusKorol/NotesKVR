using Notes.APL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.APL.Model
{
    public class EmptyImage: BaseINPC
    {
        private int _emptyImageId;
        public int EmptyImageId
        {
            get => _emptyImageId;
            set => SetField(ref _emptyImageId, value);
        }

        private byte[] _emptyImageFile;
        public byte[] EmptyImageFile
        {
            get => _emptyImageFile;
            set => SetField(ref _emptyImageFile, value);
        }

        private string? _emptyImageTitle;
        public string? EmptyImageTitle
        {
            get => _emptyImageTitle;
            set => SetField(ref _emptyImageTitle, value);
        }

        public EmptyImage(int prmId, byte[] prmImageFile, string prmTitle)
        {
            this.EmptyImageId = prmId;
            this.EmptyImageFile = prmImageFile;
            this.EmptyImageTitle = prmTitle;
        }

        public EmptyImage(int prmId, byte[] prmImageFile)
        {
            this.EmptyImageId = prmId;
            this.EmptyImageFile = prmImageFile;
            this.EmptyImageTitle = null;
        }
    }
}
