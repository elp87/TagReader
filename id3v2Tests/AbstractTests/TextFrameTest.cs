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

            public string GetEncodingString()
            {
                return this._encoding.ToString();
            }

            public static int GetNewStringCount(string text)
            {
                return TextFrame.GetStringCount(text);
            }
        }

        byte[] testArray;
        FrameFlagSet ffs;
        TextFrame_TestClass test;
        public Abstract_TextFrameTest()
        {
            testArray = new byte[] { 0x03, 0x74, 0x69, 0x74, 0x6C, 0x65 };
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

        [TestMethod]
        public void TestEnumTextEncoding()
        {
            byte[][] testArrayEncode = new byte[][] { new byte[] { 0x00 }, new byte[] { 0x01 }, new byte[] { 0x02 }, new byte[] { 0x03 } };

            string[] tests = new string[] {
                new TextFrame_TestClass(ffs, testArrayEncode[0]).GetEncodingString(),
                new TextFrame_TestClass(ffs, testArrayEncode[1]).GetEncodingString(),
                new TextFrame_TestClass(ffs, testArrayEncode[2]).GetEncodingString(),
                new TextFrame_TestClass(ffs, testArrayEncode[3]).GetEncodingString()
            };

            string[] expStrings = new string[] {
                "ISO_8859_1",
                "UTF16",
                "UTF16_BE",
                "UTF8"
            };

            CollectionAssert.AreEqual(expStrings, tests);
        }

        [TestMethod]
        public void TestGetStringCount()
        {
            string[] testStrings = new string[] {
                "test String",
                "test\0test\0test"
            };

            int[] expValues = new int[] { 1, 2 };

            for (int i = 9; i < expValues.Length; i++) { Assert.AreEqual(expValues[i], TextFrame_TestClass.GetNewStringCount(testStrings[i])); }
        }
    }
}
