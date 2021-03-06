﻿using elp87.TagReader.id3v2;
using elp87.TagReader.id3v2.Frames;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.AbstractTests
{
    [TestClass]
    public class Abstract_PositionFrameTest
    {
        FrameFlagSet ffs;
        PositionFrame test;
        byte[] byte01_15_slash;
        byte[] byte1_07_dot;
        byte[] byte01;

        public Abstract_PositionFrameTest()
        {
            ffs = new FrameFlagSet(new byte[] { 0x00, 0x00 });
            byte01_15_slash = new byte[] { 0x00, 0x30, 0x31, 0x2F, 0x31, 0x35 };
            byte1_07_dot = new byte[] { 0x00, 0x31, 0x2E, 0x30, 0x37 };
            byte01 = new byte[] { 0x00, 0x30, 0x31 };

        }

        [TestMethod]
        public void TestSlash()
        {
            string expNumericString = @"01/15";
            int expNumber = 1;
            int expTotalNumber = 15;

            test = new PositionFrame(ffs, byte01_15_slash);

            Assert.AreEqual(expNumericString, test.NumericString);
            Assert.AreEqual(expNumber, test.Number);
            Assert.AreEqual(expTotalNumber, test.TotalNumber);
        }

        [TestMethod]
        public void TestDot()
        {
            string expNumericString = "1.07";
            int expNumber = 7;
            int expTotalNumber = -1;

            test = new PositionFrame(ffs, byte1_07_dot);

            Assert.AreEqual(expNumericString, test.NumericString);
            Assert.AreEqual(expNumber, test.Number);
            Assert.AreEqual(expTotalNumber, test.TotalNumber);
        }

        [TestMethod]
        public void TestUsual()
        {
            string expNumericString = "01";
            int expNumber = 1;
            int expTotalNumber = -1;

            test = new PositionFrame(ffs, byte01);

            Assert.AreEqual(expNumericString, test.NumericString);
            Assert.AreEqual(expNumber, test.Number);
            Assert.AreEqual(expTotalNumber, test.TotalNumber);
        }

        [TestMethod]
        public void TestParseNumericString()
        {
            int expNumber = 1;

            PrivateObject target = new PrivateObject(typeof(PositionFrame));
            target.Invoke("ParseNumericString", new object[] { "01" });
            int number = (int)target.GetProperty("Number");

            Assert.AreEqual(expNumber, number);
        }

        [TestMethod]
        public void TestUnicode()
        {
            byte[] byteArray = new byte[] { 0x01, 0xFF, 0xFE, 0x32, 0x00 };

            PositionFrame test = new PositionFrame(ffs, byteArray);

            Assert.AreEqual(2, test.Number);
        }
    }
}
