using elp87.TagReader.id3v2.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.AbstractTests
{
    [TestClass]
    public class Abstract_TimeStampFrameTest
    {
        private class TimeStampFrame_TestClass : TimeStampFrame
        {
            public TimeStampFrame_TestClass()
                : base()
            { }
        }
            
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
                PrivateObject target = new PrivateObject(typeof(TimeStampFrame_TestClass));
                test[i] = (TimeStamp.TimeStampFormat)target.Invoke("GetTimeStamp", testBytes[i]);
            }

            CollectionAssert.AreEqual(expFormats, test);
        }
    }
}
