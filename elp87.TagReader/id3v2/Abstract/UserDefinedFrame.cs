using System;

namespace elp87.TagReader.id3v2.Abstract
{
    /// <summary>
    /// This abstract base class provides general functionality for frames with user defined information
    /// </summary>
    public abstract class UserDefinedFrame
        : TextFrame
    {
        #region Fields
        /// <summary>
        /// Frame description
        /// </summary>
        protected string _description;

        /// <summary>
        /// User defined information value
        /// </summary>
        protected string _value;

        /// <summary>
        /// Position of string terminator
        /// </summary>
        protected int _terminatorPos;
        #endregion

        #region Consructors
        /// <summary>
        /// Inheritable constructor for <see cref="elp87.TagReader.id3v2.Abstract.UserDefinedFrame"/> class
        /// </summary>
        public UserDefinedFrame()
            : base()
        { }

        /// <summary>
        /// Main inheritable constructor for <see cref="elp87.TagReader.id3v2.Abstract.UserDefinedFrame"/> class.
        /// </summary>
        /// <param name="flags">Flag fields of current frame.</param>
        /// <param name="frameData">Byte array that contains frame data excluding frame header and header extra data.</param>
        public UserDefinedFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        {
            this.ParseFrame(this._frameData);
        }        
        #endregion

        #region Properies
        /// <summary>
        /// Gets frame description.
        /// </summary>
        public string Description   { get { return this._description; } }

        /// <summary>
        /// Gets user defined information value.
        /// </summary>
        public string Value         { get { return this._value; } }
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

        /// <summary>
        /// Parse frame data to compliant fields.
        /// </summary>
        /// <param name="frameData">Frame data.</param>
        protected void ParseFrame(byte[] frameData)
        {
            this._terminatorPos = ParseTerminatorPos(frameData);
            this._description = ParseDescription(frameData);
            this._value = ParseValue(frameData);
        }              

        /// <summary>
        /// Parse description from byte array.
        /// </summary>
        /// <param name="frameData">Byte array.</param>
        /// <returns>Description.</returns>
        protected string ParseDescription(byte[] frameData)
        {
            char _UTF16NullChar = System.Text.Encoding.Unicode.GetString(new byte[] { 0x00 }).ToCharArray()[0];
            byte[] descData = new byte[this._terminatorPos];
            Array.Copy(frameData, descData, descData.Length);
            string desc = this.GetString(descData);
            if (desc == "") return "";
            if (desc[desc.Length - 1] == _UTF16NullChar)
                { desc = desc.Substring(0, desc.Length - 1); }
            return desc;
        }

        /// <summary>
        /// Abstract method that should return user defined information value from byte array.
        /// </summary>
        /// <param name="frameData">Byte array.</param>
        /// <returns>User defined information value.</returns>
        protected abstract string ParseValue(byte[] frameData);
        #endregion
    }
}
