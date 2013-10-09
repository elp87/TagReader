using System;

namespace elp87.TagReader.id3v2.Abstract
{
    public abstract class UserDefinedFrame
        : TextFrame
    {
        #region Fields
        protected string _description;
        protected string _value;
        protected int _terminatorPos;
        #endregion

        #region Consructors
        public UserDefinedFrame()
            : base()
        { }

        public UserDefinedFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        {
            this.ParseFrame(this._frameData);
        }        
        #endregion

        #region Properies
        public string description   { get { return this._description; } }
        public string value         { get { return this._value; } }
        #endregion

        #region Methods
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

        protected void ParseFrame(byte[] frameData)
        {
            this._terminatorPos = ParseTerminatorPos(frameData);
            this._description = ParseDescription(frameData);
            this._value = ParseValue(frameData);
        }              

        protected string ParseDescription(byte[] frameData)
        {
            char _UTF16NullChar = System.Text.Encoding.Unicode.GetString(new byte[] { 0x00 }).ToCharArray()[0];
            byte[] descData = new byte[this._terminatorPos];
            Array.Copy(frameData, descData, descData.Length);
            string desc = this.GetString(descData);
            if (desc[desc.Length - 1] == _UTF16NullChar)
                { desc = desc.Substring(0, desc.Length - 1); }
            return desc;
        }

        protected abstract string ParseValue(byte[] frameData);
        #endregion
    }
}
