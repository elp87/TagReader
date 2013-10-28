using System;

namespace elp87.TagReader.id3v2.Exceptions
{
    /// <summary>
    /// The exception that is thrown when there is unsupported id3v2 tag version in mp3 file
    /// </summary>
    /// <remarks>This library support id3v2.4 tag version. 
    /// Id3v2.3 tag version is partly supported, bit it doesn't cause this exception.
    /// Id3v2.2 and lower are unsupported and will be cause exception. 
    /// Id3v2.5 and upper are doesn't exist and will be cause this exception too.</remarks>
    public class UnsupportedTagVersionException : Exception
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
        /// Initialize a new instance of <see cref="elp87.TagReader.id3v2.Exceptions.UnsupportedTagVersionException"/>
        /// </summary>
        public UnsupportedTagVersionException() { }

        /// <summary>
        /// Initialize a new instance of <see cref="elp87.TagReader.id3v2.Exceptions.UnsupportedTagVersionException"/> with a specified error message, cause of error and time of error.
        /// </summary>
        /// <param name="message">A String that describes the error. The content of <c>message</c> is intended to be understood by humans.</param>
        /// <param name="cause">A String that describes the cause of error. The content of <c>cause</c> should be useful for software developers</param>
        /// <param name="time">Time of exception</param>
        public UnsupportedTagVersionException(string message, string cause, DateTime time)
            : base(message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
    }
}
