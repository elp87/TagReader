using elp87.TagReader.id3v2.Abstract;
using System;

namespace elp87.TagReader.id3v2.Frames
{
    public class UnsunchTextFrame
        : LanguageTextFrame
    {
        #region Fields
        private string _description;
        private string _textValue;
        private byte[] _frameBody;                
        #endregion

        #region Constructors
        protected UnsunchTextFrame()
            : base()
        { }

        public UnsunchTextFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        {
            this._frameBody = this.ReadFrameBody();
            int terminatorPosition = this.ParseTerminatorPos(this._frameBody);
            byte[] descArray = new byte[terminatorPosition];
            byte[] lyricArray = new byte[this._frameBody.Length - terminatorPosition - 1];
            Array.Copy(this._frameBody, descArray, terminatorPosition);
            Array.Copy(this._frameBody, terminatorPosition + 1, lyricArray, 0, lyricArray.Length);
            this._description = this.GetString(descArray);
            this._textValue = this.GetString(lyricArray);            
        }        
        #endregion

        #region Properties
        public string Description { get { return this._description; } }
        public string Value      { get { return this._textValue; } }
        #endregion

        #region Methods        

        private byte[] ReadFrameBody()
        {
            byte[] frameBody = new byte[this._frameData.Length - 3];
            Array.Copy(this._frameData, 3, frameBody, 0, frameBody.Length);
            return frameBody;
        }
        
        private int ParseTerminatorPos(byte[] frameData)
        {
            int position;

            if (this._encoding == TextEncoding.UTF16 || this._encoding == TextEncoding.UTF16_BE)
            {
                byte[] termByteArray = new byte[] { 0x00, 0x00 };
                position = ByteArray.FindSubArray(frameData, termByteArray);
            }
            else
            {
                byte termByte = 0x00;
                position = Array.IndexOf(frameData, termByte);
            }

            while (frameData[position + 1] == 0x00) { position++; }
            return position;
        } 
        #endregion
    }
}
