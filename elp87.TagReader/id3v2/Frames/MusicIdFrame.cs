using elp87.TagReader.id3v2.Abstract;

namespace elp87.TagReader.id3v2.Frames
{
    /// <summary>
    /// Provides functionality for Music CD identifier frames.
    /// </summary>
    /// <remarks>This class allows to read MCDI frames. For details read "ID3 tag version 2.4.0 - Native Frames"</remarks>
    /// <seealso cref="elp87.TagReader.id3v2.ID3V2.MCDI"/>
    public class MusicIdFrame
        : Frame
    {
        #region Fields
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.MusicIdFrame"/> that is empty.
        /// </summary>
        protected MusicIdFrame()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.MusicIdFrame"/> and read frame data
        /// </summary>
        /// <param name="flags">Flag fields of current frame.</param>
        /// <param name="frameData">Byte array that contains frame data excluding frame header and header extra data.</param>
        public MusicIdFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        { }
        #endregion

        #region Methods
        /// <summary>
        /// Returns binary dump of the CD Table Of Contents.
        /// </summary>
        /// <returns>Binary dump of the CD Table Of Contents.</returns>
        public byte[] GetData()
        {
            return (byte[])this._frameData.Clone();
        }
        #endregion
    }
}
