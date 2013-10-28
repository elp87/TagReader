using System;

namespace elp87.TagReader.id3v2.Exceptions
{
    /// <summary>
    /// The exception that is thrown when there is set invalid unique file identifier
    /// </summary>
    /// <remarks>Usually this exeption is thrown when unique file identifier length is more then 64 byte.</remarks>
    [Serializable]
    public class InvalidUfidDataException : Exception
    {
        /// <summary>
        /// Initialize a new instance of <see cref="elp87.TagReader.id3v2.Exceptions.InvalidUfidDataException"/>.
        /// </summary>
        public InvalidUfidDataException() { }

        /// <summary>
        /// Initialize a new instance of <see cref="elp87.TagReader.id3v2.Exceptions.InvalidUfidDataException"/> with a specified error message.
        /// </summary>
        /// <param name="message">A <see cref="System.String"/> that describes the error. The content of message is intended to be understood by humans. The caller of this constructor is required to ensure that this string has been localized for the current system culture. </param>
        public InvalidUfidDataException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="elp87.TagReader.id3v2.Exceptions.InvalidUfidDataException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception. If the <c>innerException</c> parameter is not null, the current exception is raised in a catch block that handles the inner exception. </param>
        public InvalidUfidDataException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="elp87.TagReader.id3v2.Exceptions.InvalidUfidDataException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data. </param>
        /// <param name="context">The contextual information about the source or destination. </param>
        protected InvalidUfidDataException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
