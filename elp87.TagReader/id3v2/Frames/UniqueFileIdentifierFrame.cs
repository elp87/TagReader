using elp87.TagReader.id3v2.Abstract;
using System;

namespace elp87.TagReader.id3v2.Frames
{
    /// <summary>
    /// Provides functionality for unique file identifier frames.
    /// </summary>
    /// <remarks>This class allows to read UFID frames. For details read "ID3 tag version 2.4.0 - Native Frames"</remarks>
    /// <seealso cref="elp87.TagReader.id3v2.ID3V2.UFID"/>
    public class UniqueFileIdentifierFrame
        : OwnerIDFrame
    {
        #region Constructors
        private UniqueFileIdentifierFrame()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.UniqueFileIdentifierFrame"/> and read frame data
        /// </summary>
        /// <param name="flags">Flag fields of current frame.</param>
        /// <param name="frameData">Byte array that contains frame data excluding frame header and header extra data.</param>
        public UniqueFileIdentifierFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        {
            this._data = ReadData(frameData, _terminatorPos);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Reads actual byte data from frame byta array
        /// </summary>
        /// <param name="frameData">Frame  byte array</param>
        /// <param name="position">Position of string terminator</param>
        /// <returns>Actual data</returns>
        protected override byte[] ReadData(byte[] frameData, int position)
        {
            byte[] ufidData = new byte[frameData.Length - position - 1];
            Array.Copy(frameData, position + 1, ufidData, 0, ufidData.Length);
            if (ufidData.Length > 64) throw new elp87.TagReader.id3v2.Exceptions.InvalidUfidDataException("Invalid Ufid data for - " + this._ownerID);
            return ufidData;
        }
        #endregion
        
    }
}
