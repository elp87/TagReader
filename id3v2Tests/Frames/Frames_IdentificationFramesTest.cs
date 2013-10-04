using elp87.TagReader;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.Frames
{
    [TestClass]
    public class Frames_IdentificationFramesTest
    {
        private const string _fileNameOpening = @"D:\TestAudio\01 Opening.mp3";
        private const string _fileNameIntro = @"D:\TestAudio\01. Интро.mp3";
        private const string _fileNameTIT1 = @"D:\TestAudio\TIT1.mp3";
        private const string _fileNameTOAL = @"D:\TestAudio\TOAL.mp3";
        private const string _fileNameTSRC = @"D:\TestAudio\TSRC.mp3";
        private const string _fileNameSvetSneg = @"D:\TestAudio\Свет-Снег.mp3";

        [TestMethod]
        public void TestTIT1()
        {
            string expTIT1 = "Post Rock";

            MP3File testTIT1 = new MP3File(_fileNameTIT1);

            Assert.AreEqual(expTIT1, testTIT1.id3v2.identificationFrames.TIT1.ToString());
        }

        [TestMethod]
        public void TestTIT2()
        {
            string[] expValues = new string[] 
            { 
                "Opening", "Интро", "Angel Tears (James Plotkin Remix)"	
            };

            MP3File[] testFiles = new MP3File[]
            {
                new MP3File(_fileNameOpening),
                new MP3File(_fileNameIntro),
                new MP3File(_fileNameTIT1)
            };

            Assert.AreEqual(expValues.Length, testFiles.Length);
            for (int i = 0; i < testFiles.Length; i++)
            {
                Assert.AreEqual(expValues[i], testFiles[i].id3v2.identificationFrames.TIT2.ToString());
            }
        }

        [TestMethod]
        public void TestTIT3()
        {
            string expTIT3 = "MOLECUL";

            MP3File testTIT3 = new MP3File(_fileNameSvetSneg);

            Assert.AreEqual(expTIT3, testTIT3.id3v2.identificationFrames.TIT3.ToString());
        }

        [TestMethod]
        public void TestTALB()
        {
            string[] expValues = new string[] 
            { 
                "I Was Here For A Moment, Then I Was Gone", "Саундтрек Моей Жизни", "Mono / Pelican"
            };

            MP3File[] testFiles = new MP3File[] {
                new MP3File(_fileNameOpening),
                new MP3File(_fileNameIntro),
                new MP3File(_fileNameTIT1)
            };

            Assert.AreEqual(expValues.Length, testFiles.Length);
            for (int i = 0; i < testFiles.Length; i++)
            {
                Assert.AreEqual(expValues[i], testFiles[i].id3v2.identificationFrames.TALB.ToString());
            }
        }

        [TestMethod]
        public void TestTOAL()
        {
            string expValue = "AN ENDLESS TOMORROW";

            MP3File test = new MP3File(_fileNameTOAL);

            Assert.AreEqual(expValue, test.id3v2.identificationFrames.TOAL.ToString());
        }

        [TestMethod]
        public void TestTRCK()
        {
            int[] expNumber = new int[] { 1, 1, 2 };
            int[] expTotalNumber = new int[] { 1, 10, -1};

            MP3File[] testFiles = new MP3File[]
            {
                new MP3File(_fileNameOpening),
                new MP3File(_fileNameIntro),
                new MP3File(_fileNameTIT1)
            };

            Assert.AreEqual(expNumber.Length, testFiles.Length);
            for (int i = 0; i < testFiles.Length; i++)
            {
                Assert.AreEqual(expNumber[i], testFiles[i].id3v2.identificationFrames.TRCK.number);
                Assert.AreEqual(expTotalNumber[i], testFiles[i].id3v2.identificationFrames.TRCK.totalNumber);
            }
        }

        [TestMethod]
        public void TestTPOS()
        {
            int expNumber = 6;
            int expTotalNumber = 12;
            string expStringValue = @"06/12";

            MP3File test = new MP3File(_fileNameTOAL);

            Assert.AreEqual(expNumber, test.id3v2.identificationFrames.TPOS.number);
            Assert.AreEqual(expTotalNumber, test.id3v2.identificationFrames.TPOS.totalNumber);
            Assert.AreEqual(expStringValue, test.id3v2.identificationFrames.TPOS.numericString);
        }

        [TestMethod]
        public void TestTSRC()
        {
            string expTSRC = "GBUM70812435";

            MP3File test = new MP3File(_fileNameTSRC);

            Assert.AreEqual(expTSRC, test.id3v2.identificationFrames.TSRC.ToString());
        }
    }
}
