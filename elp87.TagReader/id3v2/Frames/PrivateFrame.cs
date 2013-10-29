using elp87.TagReader.id3v2.Abstract;
using System;

namespace elp87.TagReader.id3v2.Frames
{
    /// <summary>
    /// Provides functionality for private frames.
    /// </summary>
    /// <remarks>This class allows to read PRIV frames. For details read "ID3 tag version 2.4.0 - Native Frames"</remarks>
    /// <seealso cref="elp87.TagReader.id3v2.ID3V2.PRIV"/>
    public class PrivateFrame
        : OwnerIDFrame
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.PrivateFrame"/> that is empty.
        /// </summary>
        protected PrivateFrame()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.PrivateFrame"/> and read frame data
        /// </summary>
        /// <param name="flags">Flag fields of current frame.</param>
        /// <param name="frameData">Byte array that contains frame data excluding frame header and header extra data.</param>
        public PrivateFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        {
            this._data = this.ReadData(frameData, _terminatorPos);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Reads actual byte data from frame byta array 
        /// </summary>
        /// <param name="frameData">Frame byte array</param>
        /// <param name="position">Position of string terminator</param>
        /// <returns></returns>
        protected override byte[] ReadData(byte[] frameData, int position)
        {
            byte[] dataArray = new byte[frameData.Length - position - 1];
            Array.Copy(frameData, position + 1, dataArray, 0, dataArray.Length);
            return dataArray;
        }
        #endregion
    }
}
