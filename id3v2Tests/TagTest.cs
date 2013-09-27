using elp87.TagReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests
{
    [TestClass]
    public class TagTest
    {
        [TestMethod]
        public void TestGetTagArray()
        {
            string filename = @"D:\TestAudio\sample.MP3";
            MP3File testFile = new MP3File(filename);

            int expLength = 25;
            byte[] expArray = new byte[] {
                0x49, 0x44, 0x33, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0F, 0x54, 0x43, 0x4F, 0x4E, 0x00, 0x00,
                0x00, 0x05, 0x00, 0x00, 0x00, 0x28, 0x31, 0x32, 0x29
            };

            Assert.AreEqual(expLength, testFile.id3v2.GetTagArray().Length);
            CollectionAssert.AreEqual(expArray, testFile.id3v2.GetTagArray());
        }
    }
}
