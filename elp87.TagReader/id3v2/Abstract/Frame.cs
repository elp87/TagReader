namespace elp87.TagReader.id3v2.Abstract
{
    /// <summary>
    /// An abstract base class that provides general functionality for all frames
    /// </summary>
    public abstract class Frame
    {
        /// <summary>
        /// Flag fields of current frame.
        /// </summary>
        protected FrameFlagSet _flags;

        /// <summary>
        /// Byte array that contains frame data excluding drame header and header extra data.
        /// </summary>
        /// <remarks>
        /// Note! This array doesn't contain text encoding byte in all text frames.
        /// </remarks>
        protected byte[] _frameData;

        /// <summary>
        /// Inheritable constructor for <see cref="elp87.TagReader.id3v2.Abstract.Frame"/> class
        /// </summary>
        public Frame() { }

        /// <summary>
        /// Main inheritable constructor for <see cref="elp87.TagReader.id3v2.Abstract.Frame"/> class.
        /// </summary>
        /// <param name="flags">Flag fields of current frame.</param>
        /// <param name="frameData">Byte array that contains frame data excluding frame header and header extra data.</param>
        public Frame(FrameFlagSet flags, byte[] frameData)
        {
            this._flags = flags;
            this._frameData = frameData;
        }

        /// <summary>
        /// Gets flag fields of current frame.
        /// </summary>
        public FrameFlagSet flags
        {
            get
            {
                return _flags;
            }
        }
    }
}
