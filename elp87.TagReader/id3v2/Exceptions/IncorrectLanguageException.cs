using System;

namespace elp87.TagReader.id3v2.Exceptions
{
    /// <summary>
    /// The exception that is thrown when there is set incorrect language value.
    /// </summary>
    public class IncorrectLanguageException : Exception
    {
        /// <summary>
        /// Time of exception
        /// </summary>
        public DateTime ErrorTimeStamp { get; set; }

        /// <summary>
        /// Cause of exception
        /// </summary>
        public string CauseOfError { get; set; }

        /// <summary>
        /// Initialize a new instance of <see cref="elp87.TagReader.id3v2.Exceptions.IncorrectLanguageException"/>
        /// </summary>
        public IncorrectLanguageException() { }

        /// <summary>
        /// Initialize a new instance of <see cref="elp87.TagReader.id3v2.Exceptions.IncorrectLanguageException"/> with a specified error message, cause of error and time of error.
        /// </summary>
        /// <param name="message">A String that describes the error. The content of <c>message</c> is intended to be understood by humans.</param>
        /// <param name="cause">A String that describes the cause of error. The content of <c>cause</c> should be useful for software developers</param>
        /// <param name="time">Time of exception</param>
        public IncorrectLanguageException(string message, string cause, DateTime time)
            : base(message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
    }
}
