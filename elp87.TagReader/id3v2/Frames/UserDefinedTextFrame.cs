using elp87.TagReader.id3v2.Abstract;
using System;

namespace elp87.TagReader.id3v2.Frames
{
    /// <summary>
    /// Provides functionality for user defined text frames.
    /// </summary>
    /// <remarks>This class allows to read TXXX frames. For details read "ID3 tag version 2.4.0 - Native Frames"</remarks>
    /// <seealso cref="elp87.TagReader.id3v2.Frames.OtherFrameSet.TXXX"/>
    public class UserDefinedTextFrame
        : UserDefinedFrame
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.UserDefinedTextFrame"/> that is empty.
        /// </summary>
        protected UserDefinedTextFrame()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.UserDefinedTextFrame"/> and read frame data
        /// </summary>
        /// <param name="flags">Flag fields of current frame.</param>
        /// <param name="frameData">Byte array that contains frame data excluding frame header and header extra data.</param>
        public UserDefinedTextFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        { }
        #endregion

        #region Methods
        /// <summary>
        /// Parse frame data and returns actual text info value.
        /// </summary>
        /// <param name="frameData">Byte array.</param>
        /// <returns>Actual text info value</returns>
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
