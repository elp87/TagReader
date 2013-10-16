using elp87.TagReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.Frames
{
    [TestClass]
    public class Frames_CommentsTest
    {
        private const string _fileNameTENC = @"D:\TestAudio\TENC.mp3";

        [TestMethod]
        public void TestCOMM()
        {
            string[] expDescription = new string[]
            {
                "ID3 v1 Comment", ""
            };
            string[] expValue = new string[]
            {
                "Attribution-Share Alike 3.0", "http://www.jamendo.com Attribution-Share Alike 3.0"
            };

            MP3File test = new MP3File(_fileNameTENC);

            Assert.AreEqual(expDescription.Length, test.Id3v2.COMM.Length);

            for (int i = 0; i < expDescription.Length; i++)
            {
                Assert.AreEqual(expDescription[i], test.Id3v2.COMM[i].Description);
                Assert.AreEqual(expValue[i], test.Id3v2.COMM[i].Value);
            }
        }
    }
}
