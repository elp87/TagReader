namespace elp87.TagReader.id3v2.Abstract
{
    /// <summary>
    /// Provides enums and static methods for time stamps
    /// </summary>
    public static class TimeStamp
    {
        /// <summary>
        /// Specifies time stamp formats
        /// </summary>
        public enum TimeStampFormat : byte
        {
            /// <summary> Absolute time, 32 bit sized, using MPEG frames as unit </summary>
            MpegAbsoluteTime = 0x01,
            /// <summary> Absolute time, 32 bit sized, using milliseconds as unit </summary>
            MsAbsoluteTime = 0x02
        }

        /// <summary>
        /// Returns time stamps format from time stamp byte
        /// </summary>
        /// <param name="timeStampByte">Time stamp format byte</param>
        /// <returns>Time stamp format</returns>
        /// <seealso cref="elp87.TagReader.id3v2.Abstract.TimeStamp.TimeStampFormat"/>
        public static TimeStampFormat GetTimeStamp(byte timeStampByte)
        {
            return (TimeStampFormat)timeStampByte;
        }
    }
}
