using elp87.TagReader.id3v2;
using elp87.TagReader.id3v2.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace elp87.TagReader.id3v2.Frames
{
    public class UniqueFileIdentifierFrame
        : OwnerIDFrame
    {
        #region Constructors
        private UniqueFileIdentifierFrame()
            : base()
        { }

        public UniqueFileIdentifierFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        {
            this._data = ReadData(frameData, _terminatorPos);
        }
        #endregion

        #region Methods
        protected override byte[] ReadData(byte[] frameData, int position)
        {
            byte[] ufidData = new byte[frameData.Length - position - 1];
            Array.Copy(frameData, position + 1, ufidData, 0, ufidData.Length);
            if (ufidData.Length > 64) throw new elp87.TagReader.id3v2.Exceptions.InvalidUfidDataException("Invalid Ufid data for - " + this._ownerID);
            return ufidData;
        }
        #endregion
        
    }
}
