using elp87.TagReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.Frames
{
    [TestClass]
    public class Frames_UrlFrameSetTest
    {
        private const string _fileNameTENC = @"D:\TestAudio\TENC.mp3";
        private const string _fileNameTIT1 = @"D:\TestAudio\TIT1.mp3";
        private const string _fileNameTLAN = @"D:\TestAudio\TLAN.mp3";

        [TestMethod]
        public void TestWCOM()
        {
            string[] expValue = new string[] {@"http://www.jamendo.com"};

            MP3File test = new MP3File(_fileNameTENC);

            Assert.AreEqual(expValue.Length, test.Id3v2.UrlFrames.WCOM.Length);
            for (int i = 0; i < expValue.Length; i++)
            {
                Assert.AreEqual(expValue[i], test.Id3v2.UrlFrames.WCOM[i].Link);
            }
        }

        [TestMethod]
        public void TestWCOP()
        {
            string expValue = @"http://creativecommons.org/licenses/by-sa/3.0/";

            MP3File test = new MP3File(_fileNameTENC);

            Assert.AreEqual(expValue, test.Id3v2.UrlFrames.WCOP.Link);
        }

        [TestMethod]
        public void TestWOAF()
        {
            string expValue = @"http://www.jamendo.com/en/track/108579";

            MP3File test = new MP3File(_fileNameTENC);

            Assert.AreEqual(expValue, test.Id3v2.UrlFrames.WOAF.Link);
        }

        [TestMethod]
        public void TestWOAR()
        {
            string[] expValue = new string[] { @"http://www.jamendo.com/en/artist/The_Phase" };

            MP3File test = new MP3File(_fileNameTENC);

            Assert.AreEqual(expValue.Length, test.Id3v2.UrlFrames.WOAR.Length);
            for (int i = 0; i < expValue.Length; i++)
            {
                Assert.AreEqual(expValue[i], test.Id3v2.UrlFrames.WOAR[i].Link);
            }
        }

        [TestMethod]
        public void TestWOAS()
        {
            string expValue = @"http://www.jamendo.com/en/album/13125";

            MP3File test = new MP3File(_fileNameTENC);

            Assert.AreEqual(expValue, test.Id3v2.UrlFrames.WOAS.Link);
        }

        [TestMethod]
        public void TestWPUB()
        {
            string expValue = @"http://www.jamendo.com";

            MP3File test = new MP3File(_fileNameTENC);

            Assert.AreEqual(expValue, test.Id3v2.UrlFrames.WPUB.Link);
        }

        [TestMethod]
        public void TestWXXX()
        {
            string[][] expDescription = new string[][]
            {
                new string[] { "" },
                new string[] { "" }
            };
            string[][] expValue = new string[][]
            {
                new string[] { @"http://www.mono-jpn.com" },
                new string[] { @"http://www.exiliaweb.com/" }
            };

            MP3File[] test = new MP3File[]
            {
                new MP3File(_fileNameTIT1),
                new MP3File(_fileNameTLAN)
            };

            Assert.AreEqual(expDescription.Length, test.Length);
            Assert.AreEqual(expValue.Length, test.Length);
            for (int i = 0; i < test.Length; i++)
            {
                Assert.AreEqual(expDescription[i].Length, test[i].Id3v2.UrlFrames.WXXX.Length);
                Assert.AreEqual(expValue[i].Length, test[i].Id3v2.UrlFrames.WXXX.Length);
                for (int j = 0; j < test[i].Id3v2.UrlFrames.WXXX.Length; j++)
                {
                    Assert.AreEqual(expDescription[i][j], test[i].Id3v2.UrlFrames.WXXX[j].Description);
                    Assert.AreEqual(expValue[i][j], test[i].Id3v2.UrlFrames.WXXX[j].Value);
                }
            }
        }
    }
}
