using elp87.TagReader.id3v2.Abstract;
using System;

namespace elp87.TagReader.id3v2.Frames
{
    public class PrivateFrame
        : OwnerIDFrame
    {
        #region Constructors
        protected PrivateFrame()
            : base()
        { }

        public PrivateFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        {
            this._data = this.ReadData(frameData, _terminatorPos);
        }
        #endregion

        #region Methods
        protected override byte[] ReadData(byte[] frameData, int position)
        {
            byte[] dataArray = new byte[frameData.Length - position - 1];
            Array.Copy(frameData, position + 1, dataArray, 0, dataArray.Length);
            return dataArray;
        }
        #endregion
    }
}
