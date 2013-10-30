using elp87.TagReader.id3v2.Abstract;
using System;
using System.Text;

namespace elp87.TagReader.id3v2.Frames
{
    /// <summary>
    /// Provides functionality for user defined URL link frames.
    /// </summary>
    /// <remarks>This class allows to read WXXX frames. For details read "ID3 tag version 2.4.0 - Native Frames"</remarks>
    /// <seealso cref="elp87.TagReader.id3v2.Frames.UrlFrameSet.WXXX"/>
    public class UserDefinedUrlFrame
        : UserDefinedFrame
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.UserDefinedUrlFrame"/> that is empty.
        /// </summary>
        protected UserDefinedUrlFrame()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.UserDefinedUrlFrame"/> and read frame data
        /// </summary>
        /// <param name="flags">Flag fields of current frame.</param>
        /// <param name="frameData">Byte array that contains frame data excluding frame header and header extra data.</param>
        public UserDefinedUrlFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        { }
        #endregion

        #region Methods
        /// <summary>
        /// Parse frame data and returns actual URL link.
        /// </summary>
        /// <param name="frameData">Byte array.</param>
        /// <returns>Actual URL link.</returns>
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
