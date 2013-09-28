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
                "﻿Opening", "Интро", "﻿Angel Tears (James Plotkin Remix)"	
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
    }
}
