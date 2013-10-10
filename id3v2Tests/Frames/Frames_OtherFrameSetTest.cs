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

        [TestMethod]
        public void TestTOFN()
        {
            string expValue = "Original file name";

            MP3File test = new MP3File(_fileNameTOFN);

            Assert.AreEqual(expValue, test.Id3v2.OtherFrames.TOFN.ToString());
        }
    }
}
