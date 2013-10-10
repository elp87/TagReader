using elp87.TagReader.id3v2;
using elp87.TagReader.id3v2.Frames;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.AbstractTests
{
    [TestClass]
    public class Abstract_NumericStringFrameTest
    {
        FrameFlagSet ffs;
        NumericStringFrame test;
        byte[] byte182560;
        public Abstract_NumericStringFrameTest()
        {
            ffs = new FrameFlagSet(new byte[] { 0x00, 0x00 });
            byte182560 = new byte[] { 0x00, 0x31, 0x38, 0x32, 0x35, 0x36, 0x30 };
            test = new NumericStringFrame(ffs, byte182560);
        }

        [TestMethod]
        public void TestNumber()
        {
            int expValue = 182560;

            Assert.AreEqual(expValue, test.Number);
        }

        [TestMethod]
        public void TestStringNumber()
        {
            string expValue = "182560";

            Assert.AreEqual(expValue, test.NumericString);
        }

        [TestMethod]
        public void TestParseNumericString()
        {
            int expInt = 182560;
            string expString = "182560";

            PrivateObject target = new PrivateObject(typeof(NumericStringFrame), new object[] {new FrameFlagSet(new byte[] {0x00, 0x00}), byte182560});
            target.Invoke("ParseNumericString");
            int intValue = (int)target.GetProperty("Number", new object[] { });
            string stringValue = (string)target.GetProperty("NumericString", new object[] { });

            Assert.AreEqual(expInt, intValue);
            Assert.AreEqual(expString, stringValue);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestFormatException()
        {
            byte[] testArray = new byte[] { 0x03, 0x74, 0x69, 0x74, 0x6C, 0x65 };

            NumericStringFrame test1 = new NumericStringFrame(ffs, testArray);
        }
    }
}
