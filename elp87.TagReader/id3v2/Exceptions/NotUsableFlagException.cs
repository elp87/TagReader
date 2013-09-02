﻿using System;

namespace elp87.TagReader.id3v2.Exceptions
{
    public class NotUsableFlagException: Exception
    {
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }
        public NotUsableFlagException() { }
        public NotUsableFlagException(string message, string cause, DateTime time)
            : base(message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        } 
    }
}
