using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elp87.TagReader.id3v2.Exceptions
{
    public class UnknownEncodingException : Exception
    {
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }
        public UnknownEncodingException() { }
        public UnknownEncodingException(string message, string cause, DateTime time)
            : base(message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        } 
    }
}
