using elp87.TagReader.id3v2.Abstract;
using System;
using System.Text;

namespace elp87.TagReader.id3v2.Frames
{
    public class UserDefinedUrlFrame
        : UserDefinedFrame
    {
        #region Constructors
        protected UserDefinedUrlFrame()
            : base()
        { }

        public UserDefinedUrlFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        { }
        #endregion

        #region Methods
        protected override string ParseValue(byte[] frameData)
        {
            byte[] valueData = new byte[this._frameData.Length - this._terminatorPos - 1];
            Array.Copy(this._frameData, _terminatorPos + 1, valueData, 0, valueData.Length);
            string value = Encoding.ASCII.GetString(valueData);
            return value;
        } 
        #endregion
    }
}
