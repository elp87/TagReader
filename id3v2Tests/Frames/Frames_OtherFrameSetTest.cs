using elp87.TagReader;
using elp87.TagReader.id3v2.Frames;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.Frames
{
    [TestClass]
    public class Frames_OtherFrameSetTest
    {
        private const string _fileNameTOFN = @"D:\TestAudio\TOFN.mp3";
        private const string _fileNameTENC = @"D:\TestAudio\TENC.mp3";
        private const string _fileNameIntro = @"D:\TestAudio\01. Интро.mp3";

        [TestMethod]
        public void TestTOFN()
        {
            string expValue = "Original file name";

            MP3File test = new MP3File(_fileNameTOFN);

            Assert.AreEqual(expValue, test.Id3v2.OtherFrames.TOFN.ToString());
        }

        [TestMethod]
        public void TDRC()
        {
            int expValue = 2009;

            MP3File test = new MP3File(_fileNameIntro);
            
            Assert.AreEqual(expValue, test.Id3v2.OtherFrames.TDRC.Year);
        }

        [TestMethod]
        public void TestTDRL()
        {
            int expValue = 2007;

            MP3File test = new MP3File(_fileNameTENC);

            Assert.AreEqual(expValue, test.Id3v2.OtherFrames.TDRL.Year);
        }

        [TestMethod]
        public void TestTDTG()
        {
            DateTime expDate = new DateTime(2012, 1, 12, 10, 18, 54);
            int expYear = 2012;

            MP3File test = new MP3File(_fileNameTENC);

            Assert.AreEqual(expDate, test.Id3v2.OtherFrames.TDTG.Date);
            Assert.AreEqual(expYear, test.Id3v2.OtherFrames.TDTG.Year);
        }
    }
}
