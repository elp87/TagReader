using elp87.TagReader.id3v2;
using elp87.TagReader.id3v2.Frames;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.Frames
{
    [TestClass]
    public class Frames_UserDefinedTextFrameTest
    {
        [TestMethod]
        public void TestFrame()
        {
            string expDescription = "major_brand";
            string expValue = "M4A ";

            FrameFlagSet ffs = new FrameFlagSet(new byte[] { 0x00, 0x00 });
            byte[] testArray = new byte[] { 0x00, 0x6D, 0x61, 0x6A, 0x6F, 0x72, 0x5F, 0x62, 0x72, 0x61, 0x6E, 0x64, 0x00, 0x4D, 0x34, 0x41, 0x20 };
            UserDefinedTextFrame test = new UserDefinedTextFrame(ffs, testArray);

            Assert.AreEqual(expDescription, test.description);
            Assert.AreEqual(expValue, test.value);
        }
    }
}
