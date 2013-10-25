namespace elp87.TagReader.id3v2.Abstract
{
    /// <summary>
    /// This abstract base class provides general functionality for frames with time stamps
    /// </summary>
    public abstract class TimeStampFrame
        : Frame
    {
        #region Fields
        /// <summary>
        /// Time stamps format
        /// </summary>
        protected TimeStamp.TimeStampFormat _timeStampFormat; 
        #endregion

        #region Constructors
        /// <summary>
        /// Inheritable constructor for <see cref="elp87.TagReader.id3v2.Abstract.TimeStampFrame"/> class
        /// </summary>
        public TimeStampFrame()
            : base()
        { }

        /// <summary>
        /// Main inheritable constructor for <see cref="elp87.TagReader.id3v2.Abstract.TimeStampFrame"/> class.
        /// </summary>
        /// <param name="flags">Flag fields of current frame.</param>
        /// <param name="frameData">Byte array that contains frame data excluding frame header and header extra data.</param>
        public TimeStampFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        { } 
        #endregion

        #region Properties
        /// <summary>
        /// Gets time stamps format
        /// </summary>
        TimeStamp.TimeStampFormat TimeStampFormat { get { return this._timeStampFormat; } }
        #endregion

        #region Methods
        #region Protected
        /// <summary>
        /// Returns time stamps format from time stamp byte
        /// </summary>
        /// <param name="timeStampByte">Time stamp format byte</param>
        /// <returns>Time stamp format</returns>
        protected TimeStamp.TimeStampFormat GetTimeStamp(byte timeStampByte)
        {
            return TimeStamp.GetTimeStamp(timeStampByte);
        }
        #endregion
        #endregion
    }
}
