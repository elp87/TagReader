﻿using elp87.TagReader;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.Frames
{
    [TestClass]
    public class Frames_IdentificationFrameSetTest
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

            Assert.AreEqual(expTIT1, testTIT1.Id3v2.IdentificationFrames.TIT1.ToString());
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
                Assert.AreEqual(expValues[i], testFiles[i].Id3v2.IdentificationFrames.TIT2.ToString());
            }
        }

        [TestMethod]
        public void TestTIT3()
        {
            string expTIT3 = "MOLECUL";

            MP3File testTIT3 = new MP3File(_fileNameSvetSneg);

            Assert.AreEqual(expTIT3, testTIT3.Id3v2.IdentificationFrames.TIT3.ToString());
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
                Assert.AreEqual(expValues[i], testFiles[i].Id3v2.IdentificationFrames.TALB.ToString());
            }
        }

        [TestMethod]
        public void TestTOAL()
        {
            string expValue = "AN ENDLESS TOMORROW";

            MP3File test = new MP3File(_fileNameTOAL);

            Assert.AreEqual(expValue, test.Id3v2.IdentificationFrames.TOAL.ToString());
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
                Assert.AreEqual(expNumber[i], testFiles[i].Id3v2.IdentificationFrames.TRCK.Number);
                Assert.AreEqual(expTotalNumber[i], testFiles[i].Id3v2.IdentificationFrames.TRCK.TotalNumber);
            }
        }

        [TestMethod]
        public void TestTPOS()
        {
            int expNumber = 6;
            int expTotalNumber = 12;
            string expStringValue = @"06/12";

            MP3File test = new MP3File(_fileNameTOAL);

            Assert.AreEqual(expNumber, test.Id3v2.IdentificationFrames.TPOS.Number);
            Assert.AreEqual(expTotalNumber, test.Id3v2.IdentificationFrames.TPOS.TotalNumber);
            Assert.AreEqual(expStringValue, test.Id3v2.IdentificationFrames.TPOS.NumericString);
        }

        [TestMethod]
        public void TestTSRC()
        {
            string expTSRC = "GBUM70812435";

            MP3File test = new MP3File(_fileNameTSRC);

            Assert.AreEqual(expTSRC, test.Id3v2.IdentificationFrames.TSRC.ToString());
        }
    }
}
