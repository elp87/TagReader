using elp87.TagReader.id3v2;
using elp87.TagReader.id3v2.Frames;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.AbstractTests
{
    [TestClass]
    public class Abstract_TextInfoFrameTest
    {
        TextInfoFrame[] frames;
        public Abstract_TextInfoFrameTest()
        {
            FrameFlagSet ffs = new FrameFlagSet(new byte[] { 0x00, 0x00 });
            frames = new TextInfoFrame[] {
                new TextInfoFrame(ffs, new byte[] {0x00, 0x5A, 0x61, 0x7A}),
                new TextInfoFrame(ffs, new byte[] {0x03, 0x73, 0x54, 0x6F, 0x61}),
                new TextInfoFrame(ffs, new byte[] {0x03, 0xD0, 0x98, 0xD0, 0xBD, 0xD1, 0x82, 0xD1, 0x80, 0xD0, 0xBE})
            };            
        }

        [TestMethod]
        public void TestToString()
        {
            string[] expValues = new string[] {
                "Zaz",
                "sToa",
                "Интро"
            };
            for (int i = 0; i < expValues.Length; i++)
            {
                Assert.AreEqual(expValues[i], frames[i].ToString());
            }
        }

        [TestMethod]
        public void TestGetValues()
        {
            string[][] expValues = new string[][] {
                new string[] {"Zaz"},
                new string[] {"sToa"},
                new string[] {"Интро"}
            };
            for (int i = 0; i < frames.Length; i++)
            {
                CollectionAssert.AreEqual(expValues[i], frames[i].GetValues());
            }
        }

        [TestMethod]
        public void TestMultiStringGetValues()
        {
            TextInfoFrame testFrame = new TextInfoFrame(
                new FrameFlagSet(new byte[] { 0x00, 0x00 }),
                new byte[] { 0x03, 0xD0, 0x98, 0xD0, 0xBD, 0xD1, 0x82, 0xD1, 0x80, 
                    0xD0, 0xBE, 0x00, 0xD0, 0x9A, 0xD1, 0x80, 0xD0, 0xB8, 0xD0, 0xBA, 0xD0, 0xB8}
                );

            string[] expValues = new string[] {
                "Интро",
                "Крики"
            };

            CollectionAssert.AreEqual(expValues, testFrame.GetValues());
        }

        [TestMethod]
        public void TestMultiStringIndexer()
        {
            TextInfoFrame testFrame = new TextInfoFrame(
                new FrameFlagSet(new byte[] { 0x00, 0x00 }),
                new byte[] { 0x03, 0xD0, 0x98, 0xD0, 0xBD, 0xD1, 0x82, 0xD1, 0x80, 
                    0xD0, 0xBE, 0x00, 0xD0, 0x9A, 0xD1, 0x80, 0xD0, 0xB8, 0xD0, 0xBA, 0xD0, 0xB8}
                );

            string[] expValues = new string[] {
                "Интро",
                "Крики"
            };

            for (int i = 0; i < testFrame.GetValues().Length; i++)
            {
                Assert.AreEqual(expValues[i], testFrame[i]);
            }
        }
    }
}
