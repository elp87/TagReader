using elp87.TagReader.id3v2;
using elp87.TagReader.id3v2.Frames;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.AbstractTests
{
    [TestClass]
    public class Abstract_NumericStringFrameTest
    {
        NumericStringFrame test;
        byte[] byte182560;
        public Abstract_NumericStringFrameTest()
        {
            FrameFlagSet ffs = new FrameFlagSet(new byte[] { 0x00, 0x00 });
            byte182560 = new byte[] { 0x31, 0x38, 0x32, 0x35, 0x36, 0x30 };
            test = new NumericStringFrame(ffs, byte182560);
        }

        [TestMethod]
        public void TestNumber()
        {
            int expValue = 182560;

            Assert.AreEqual(expValue, test.number);
        }

        [TestMethod]
        public void TestStringNumber()
        {
            string expValue = "182560";

            Assert.AreEqual(expValue, test.stringNumber);
        }

        [TestMethod]
        public void TestParseNumericString()
        {
            int expInt = 182560;
            string expString = "182560";

            PrivateObject target = new PrivateObject(typeof(NumericStringFrame));
            target.Invoke("ParseNumericString", (object)byte182560);
            int intValue = (int)target.GetProperty("number", new object[] { });
            string stringValue = (string)target.GetProperty("stringNumber", new object[] { });

            Assert.AreEqual(expInt, intValue);
            Assert.AreEqual(expString, stringValue);
        }
    }
}
