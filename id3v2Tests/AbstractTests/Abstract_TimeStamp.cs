﻿using elp87.TagReader.id3v2.Abstract;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.AbstractTests
{
    [TestClass]
    public class Abstract_TimeStamp
    {
        [TestMethod]
        public void TestGetTimeStamp()
        {
            TimeStamp.TimeStampFormat[] expFormats = new TimeStamp.TimeStampFormat[] 
            {
                TimeStamp.TimeStampFormat.MpegAbsoluteTime, 
                TimeStamp.TimeStampFormat.MsAbsoluteTime
            };

            byte[] testBytes = new byte[] { 0x01, 0x02 };

            TimeStamp.TimeStampFormat[] test = new TimeStamp.TimeStampFormat[testBytes.Length];
            for (int i = 0; i < testBytes.Length; i++)
            {
                test[i] = TimeStamp.GetTimeStamp(testBytes[i]);
            }

            CollectionAssert.AreEqual(expFormats, test);
        }
    }
}
