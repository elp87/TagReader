using System;
using System.Collections.Generic;
using System.Text;

namespace elp87.TagReader.id3v2.Abstract
{
    public static class TimeStamp
    {
        public enum TimeStampFormat : byte
        {
            MpegAbsoluteTime = 0x01,
            MsAbsoluteTime = 0x02
        }

        public static TimeStampFormat GetTimeStamp(byte timeStampByte)
        {
            return (TimeStampFormat)timeStampByte;
        }
    }
}
