using elp87.TagReader.id3v2.Abstract;

namespace elp87.TagReader.id3v2.Frames
{
    /// <summary>
    /// Provides functionality for position text frames.
    /// </summary>
    /// <remarks>This class allows to read TRCK and TPOS frames. For details read "ID3 tag version 2.4.0 - Native Frames"</remarks>
    public class PositionFrame
        : SlashNumericStringFrame
    {
        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.PositionFrame"/> that is empty.
        /// </summary>
        public PositionFrame()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.PositionFrame"/> and read frame data
        /// </summary>
        /// <param name="flags">Flag fields of current frame.</param>
        /// <param name="frameData">Byte array that contains frame data excluding frame header and header extra data.</param>
        public PositionFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        { }
    }
}
