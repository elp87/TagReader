using elp87.TagReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.Frames
{
    [TestClass]
    public class Frames_PersonsFrameSetTest
    {
        private const string _fileNameOpening = @"D:\TestAudio\01 Opening.mp3";
        private const string _fileNameIntro = @"D:\TestAudio\01. Интро.mp3";
        private const string _fileNameTIT1 = @"D:\TestAudio\TIT1.mp3";
        private const string _fileNameTOAL = @"D:\TestAudio\TOAL.mp3";
        private const string _fileNameTSRC = @"D:\TestAudio\TSRC.mp3";
        private const string _fileNameSvetSneg = @"D:\TestAudio\Свет-Снег.mp3";

        [TestMethod]
        public void TestTPE1()
        {
            string[] expValue = new string[]
            {
                "Maybeshewill", "ТонкаяКраснаяНить", "Pelican", "Enuma Elish", "Metallica"
            };


            MP3File[] testFiles = new MP3File[]
                {
                    new MP3File(_fileNameOpening),
                    new MP3File(_fileNameIntro),
                    new MP3File(_fileNameTIT1),
                    new MP3File(_fileNameTOAL),
                    new MP3File(_fileNameTSRC)
                };
            Assert.AreEqual(expValue.Length, testFiles.Length);
            for (int i = 0; i < testFiles.Length; i++)
            {
                Assert.AreEqual(expValue[i], testFiles[i].id3v2.personsFrames.TPE1.ToString());
            }
        }

        [TestMethod]
        public void TestTPE2()
        {
            string expValue = "MOLECUL";

            MP3File test = new MP3File(_fileNameSvetSneg);

            Assert.AreEqual(expValue, test.id3v2.personsFrames.TPE2.ToString());
        }

        [TestMethod]
        public void TestTPE3()
        {
            string expValue =  "MOLECUL";

            MP3File test = new MP3File(_fileNameSvetSneg);

            Assert.AreEqual(expValue, test.id3v2.personsFrames.TPE3.ToString());
        }

        [TestMethod]
        public void TestTPE4()
        {
            string expValue = "FEDE AGUDO";

            MP3File test = new MP3File(_fileNameTOAL);

            Assert.AreEqual(expValue, test.id3v2.personsFrames.TPE4.ToString());
        }
    }
}
