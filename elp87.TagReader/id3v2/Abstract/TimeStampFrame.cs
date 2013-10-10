namespace elp87.TagReader.id3v2.Abstract
{
    public abstract class TimeStampFrame
        : Frame
    {
        #region Fields
        protected TimeStamp.TimeStampFormat _timeStampFormat; 
        #endregion

        #region Constructors
        public TimeStampFrame()
            : base()
        { }

        public TimeStampFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        { } 
        #endregion

        #region Properties
        TimeStamp.TimeStampFormat TimeStampFormat { get { return this._timeStampFormat; } }
        #endregion

        #region Methods
        #region Protected
        protected TimeStamp.TimeStampFormat GetTimeStamp(byte timeStampByte)
        {
            return TimeStamp.GetTimeStamp(timeStampByte);
        }
        #endregion
        #endregion
    }
}
