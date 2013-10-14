using System;

namespace elp87.TagReader.id3v2.Exceptions
{
    [Serializable]
    public class InvalidUfidDataException : Exception
    {
        public InvalidUfidDataException() { }
        public InvalidUfidDataException(string message) : base(message) { }
        public InvalidUfidDataException(string message, Exception inner) : base(message, inner) { }
        protected InvalidUfidDataException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
