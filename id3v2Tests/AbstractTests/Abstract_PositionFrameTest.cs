using elp87.TagReader.id3v2;
using elp87.TagReader.id3v2.Frames;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.AbstractTests
{
    [TestClass]
    public class Abstract_PositionFrameTest
    {
        FrameFlagSet ffs;
        PositionFrame test;
        byte[] byte01_15_slash;

        public Abstract_PositionFrameTest()
        {
            ffs = new FrameFlagSet(new byte[] { 0x00, 0x00 });
            byte01_15_slash = new byte[] { 0x00, 0x30, 0x31, 0x2F, 0x31, 0x35 };
            test = new PositionFrame(ffs, byte01_15_slash);
        }

        [TestMethod]
        public void TestSlash()
        {
            string expNumericString = @"01/15";
            int expNumber = 1;
            int expTotalNumber = 15;

            Assert.AreEqual(expNumericString, test.numericString);
            Assert.AreEqual(expNumber, test.number);
            Assert.AreEqual(expTotalNumber, test.totalNumber);
        }
    }
}
