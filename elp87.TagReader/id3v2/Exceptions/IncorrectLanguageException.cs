using System;

namespace elp87.TagReader.id3v2.Exceptions
{
    public class IncorrectLanguageException : Exception
    {
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }
        public IncorrectLanguageException() { }
        public IncorrectLanguageException(string message, string cause, DateTime time)
            : base(message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
    }
}
