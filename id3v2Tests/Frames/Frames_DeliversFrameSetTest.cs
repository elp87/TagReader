using elp87.TagReader;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.Frames
{
    [TestClass]
    public class Frames_DeliversFrameSetTest
    {
        private const string _fileNameTBPM = @"D:\TestAudio\TBPM.mp3";
        private const string _fileNameTOAL = @"D:\TestAudio\TOAL.mp3";
        private const string _fileNameTKEY = @"D:\TestAudio\TKEY.mp3";
        private const string _fileNameTLAN = @"D:\TestAudio\TLAN.mp3";

        [TestMethod]
        public void TestTBPM()
        {
            int expValue = 35;

            MP3File test = new MP3File(_fileNameTBPM);

            Assert.AreEqual(expValue, test.id3v2.deliveredFrames.TBPM.number);
        }

        [TestMethod]
        public void TestTLEN()
        {
            int expValue = 335908;

            MP3File test = new MP3File(_fileNameTOAL);

            Assert.AreEqual(expValue, test.id3v2.deliveredFrames.TLEN.number);
        }

        [TestMethod]
        public void TestTKEY()
        {
            string expValue = "Dbm";

            MP3File test = new MP3File(_fileNameTKEY);

            Assert.AreEqual(expValue, test.id3v2.deliveredFrames.TKEY.ToString());
        }

        [TestMethod]
        public void TestTLAN()
        {
            string expValue = "eng";

            MP3File test = new MP3File(_fileNameTLAN);

            Assert.AreEqual(expValue, test.id3v2.deliveredFrames.TLAN.ToString());
        }
    }
}
