using elp87.TagReader.id3v2;
using elp87.TagReader.id3v2.Frames;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.Frames
{
    [TestClass]
    public class Frames_DateInfoFrameTest
    {
        [TestMethod]
        public void TestYYYYMMDD()
        {
            FrameFlagSet ffs = new FrameFlagSet(new byte[] { 0x00, 0x00 });
            byte[] data = new byte[]
            {
                0x00, 0x32, 0x30, 0x31, 0x30, 0x2D, 0x30, 0x31, 0x2D, 0x30, 0x31
            };

            DateInfoFrame test = new DateInfoFrame(ffs, data);
        }

        [TestMethod]
        public void TestParseDate()
        {
            DateTime[] expValue = new DateTime[]
            {
                new DateTime(2013, 1, 1),
                new DateTime(2013, 10, 9),
                new DateTime(2013, 10, 9, 18, 26, 00)
            };
            string[] inValues = new string[]
            {
                "2013", "2013-10-09", "2013-10-09T18:26"
            };
            DateTime[] values = new DateTime[inValues.Length];

            PrivateObject target = new PrivateObject(typeof(DateInfoFrame));

            for (int i = 0; i < inValues.Length; i++)
            {
                values[i] = (DateTime)target.Invoke("ParseDate", new object[] { inValues[i] });

            }

            Assert.AreEqual(expValue.Length, values.Length);
            for (int i = 0; i < expValue.Length; i++)
            {
                Assert.AreEqual(expValue[i], values[i]);
            }
        }
    }
}
