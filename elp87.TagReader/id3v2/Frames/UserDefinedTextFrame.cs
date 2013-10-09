using elp87.TagReader.id3v2.Abstract;
using System;

namespace elp87.TagReader.id3v2.Frames
{
    public class UserDefinedTextFrame
        : UserDefinedFrame
    {
        #region Constructors
        protected UserDefinedTextFrame()
            : base()
        { }

        public UserDefinedTextFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        { }
        #endregion

        #region Methods
        protected override string ParseValue(byte[] frameData)
        {
            byte[] valueData = new byte[this._frameData.Length - this._terminatorPos - 1];
            Array.Copy(this._frameData, _terminatorPos + 1, valueData, 0, valueData.Length);
            string value = this.GetString(valueData);
            return value;
        } 
        #endregion
    }
}
