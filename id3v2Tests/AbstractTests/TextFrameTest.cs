using elp87.TagReader.id3v2;
using elp87.TagReader.id3v2.Abstract;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.AbstractTests
{
    [TestClass]
    public class Abstract_TextFrameTest
    {
        private class TextFrame_TestClass
            : TextFrame
        {
            public TextFrame_TestClass(FrameFlagSet flags, byte[] frameData)
                : base(flags, frameData)
            { }

            public string GetString_Test(byte[] data)
            {
                return this.GetString(data);
            }            
        }

        byte[] testArray;
        FrameFlagSet ffs;
        TextFrame_TestClass test;
        public Abstract_TextFrameTest()
        {
            testArray = new byte[] {0x03, 0x74, 0x69, 0x74, 0x6C, 0x65};
            ffs = new FrameFlagSet(new byte[] { 0x00, 0x00 });
            test = new TextFrame_TestClass(ffs, testArray);
        }

        [TestMethod]
        public void TestTextFrame()
        {
            string expValue = "title";

            string actValue = test.GetString_Test(testArray);

            Assert.AreEqual(expValue, actValue);
        }
    }
}
