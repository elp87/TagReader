using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace elp87.TagReader
{
    class InvalidSynchSafeInt32Exception : Exception
    {
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }
        public InvalidSynchSafeInt32Exception() { }
        public InvalidSynchSafeInt32Exception(string message, string cause, DateTime time)
            : base(message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        } 
    }
}
