using elp87.TagReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests
{
    [TestClass]
    public class TagTest
    {
        string filename0 = @"D:\TestAudio\sample.MP3";
        string filename1 = @"D:\TestAudio\UFID.MP3";

        [TestMethod]
        public void TestGetTagArray()
        {            
            Mp3Tag testFile = new Mp3Tag(filename0);

            int expLength = 25;
            byte[] expArray = new byte[] {
                0x49, 0x44, 0x33, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0F, 0x54, 0x43, 0x4F, 0x4E, 0x00, 0x00,
                0x00, 0x05, 0x00, 0x00, 0x00, 0x28, 0x31, 0x32, 0x29
            };

            Assert.AreEqual(expLength, testFile.Id3v2.GetTagArray().Length);
            CollectionAssert.AreEqual(expArray, testFile.Id3v2.GetTagArray());
        }

        [TestMethod]
        public void TestFileSize()
        {
            int[] expValue = new int[] {16743, 28524731, 0};
            
            Mp3Tag[] testFile = new Mp3Tag[]
                {
                    new Mp3Tag(filename0),
                    new Mp3Tag(filename1),
                    new Mp3Tag()

                };
            Assert.AreEqual(expValue.Length, testFile.Length);
            for (int i = 0; i < expValue.Length; i++)
            {
                Assert.AreEqual(expValue[i], testFile[i].Size);
            }
        }

        [TestMethod]
        public void TestFilenameNull()
        {
            string expValue = "";

            Mp3Tag test = new Mp3Tag();

            Assert.AreEqual(expValue, test.Filename);
        }
    }
}
