using System;
using System.Collections.Generic;
using System.Text;

namespace elp87.TagReader.id3v2.Abstract
{
    public abstract class LanguageTimeStampTextFrame
        : LanguageTextFrame
    {
        #region Fields
        protected TimeStamp.TimeStampFormat _timeStampFormat; 
        #endregion

        #region Constructors
        public LanguageTimeStampTextFrame()
            : base()
        { }

        public LanguageTimeStampTextFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        { } 
        #endregion

        #region Properties
        TimeStamp.TimeStampFormat timeStampFormat { get { return this._timeStampFormat; } }
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
