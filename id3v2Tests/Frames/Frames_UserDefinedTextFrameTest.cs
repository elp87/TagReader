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

            Assert.AreEqual(expDescription, test.Description);
            Assert.AreEqual(expValue, test.Value);
        }

        [TestMethod]
        public void TestFrameWithBOM()
        {
            string expDescription = "catalog";
            string expValue = "0602517737280";

            FrameFlagSet ffs = new FrameFlagSet(new byte[] { 0x00, 0x00 });
            byte[] testArray = new byte[] { 0x01, 0xFF, 0xFE, 0x63, 0x00, 0x61, 0x00, 0x74, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x6F, 0x00, 0x67, 0x00, 0x00, 0x00, 0xFF, 0xFE, 0x30, 0x00, 0x36, 0x00, 0x30, 0x00, 0x32, 0x00, 0x35, 0x00, 0x31, 0x00, 0x37, 0x00, 0x37, 0x00, 0x33, 0x00, 0x37, 0x00, 0x32, 0x00, 0x38, 0x00, 0x30, 0x00};
            UserDefinedTextFrame test = new UserDefinedTextFrame(ffs, testArray);

            Assert.AreEqual(expDescription, test.Description);
            Assert.AreEqual(expValue, test.Value);
        }
    }
}
