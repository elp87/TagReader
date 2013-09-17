using System;
using System.Collections.Generic;
using System.Text;

namespace elp87.TagReader.id3v2.Exceptions
{
    public class FlagUnsetException : Exception
    {
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }
        public FlagUnsetException() { }
        public FlagUnsetException(string message, string cause, DateTime time)
            : base(message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        } 
    }
}
