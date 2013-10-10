namespace elp87.TagReader.id3v2.Abstract
{
    public abstract class TimeStampTextFrame
        : TextFrame
    {
        #region Fields
        protected TimeStamp.TimeStampFormat _timeStampFormat; 
        #endregion

        #region Constructors
        public TimeStampTextFrame()
            : base()
        { }

        public TimeStampTextFrame(FrameFlagSet flags, byte[] frameData)
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
