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
            const byte termByte = 0x00;
            position = Array.IndexOf(frameData, termByte);
            if (frameData[position + 1] == termByte) { position++; }
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
            byte[] descData = new byte[this._terminatorPos];
            Array.Copy(frameData, descData, descData.Length);
            string desc = this.GetString(descData);
            return desc;
        }

        protected abstract string ParseValue(byte[] frameData);
        #endregion
    }
}
