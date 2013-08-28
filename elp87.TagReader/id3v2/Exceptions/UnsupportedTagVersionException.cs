using System;

namespace elp87.TagReader.id3v2
{
    public class UnsupportedTagVersionException : Exception
    {
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }
        public UnsupportedTagVersionException() { }
        public UnsupportedTagVersionException(string message, string cause, DateTime time)
            : base(message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
    }
}
