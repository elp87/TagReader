using elp87.TagReader.id3v2;
using elp87.TagReader.id3v2.Frames;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.Frames
{
    [TestClass]
    public class Frames_UrlFrameTest
    {
        [TestMethod]
        public void TestUrlFrame()
        {
            string expValue = @"http://www.jamendo.com";

            FrameFlagSet ffs = new FrameFlagSet(new byte[] { 0x00, 0x00 });
            byte[] data = new byte[]
            {
                0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x77, 0x77, 0x77, 0x2E, 0x6A, 0x61, 0x6D, 0x65, 0x6E, 0x64, 0x6F, 0x2E, 0x63, 0x6F, 0x6D
            };

            UrlFrame test = new UrlFrame(ffs, data);

            Assert.AreEqual(expValue, test.Link);
        }

        [TestMethod]
        public void TestUserDefinedUrlFrame()
        {
            string expDescription = "";
            string expValue = @"http://www.mono-jpn.com";

            FrameFlagSet ffs = new FrameFlagSet(new byte[] { 0x00, 0x00 });
            byte[] data = new byte[]
            {
                0x00, 0x00, 0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x77, 0x77, 0x77, 0x2E, 0x6D, 0x6F, 0x6E, 0x6F, 0x2D, 0x6A, 0x70, 0x6E, 0x2E, 0x63, 0x6F, 0x6D
            };

            UserDefinedUrlFrame test = new UserDefinedUrlFrame(ffs, data);

            Assert.AreEqual(expDescription, test.Description);
            Assert.AreEqual(expValue, test.Value);
        }
    }
}
