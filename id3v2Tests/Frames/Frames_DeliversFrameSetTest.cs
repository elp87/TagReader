﻿using elp87.TagReader;
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
        private const string _fileNameIntro = @"D:\TestAudio\01. Интро.mp3";
        private const string _fileNameSample = @"D:\TestAudio\sample.mp3";
        private const string _fileNameTENC = @"D:\TestAudio\TENC.mp3";
        private const string _fileNameTIT1 = @"D:\TestAudio\TIT1.mp3";
        private const string _fileNameTSRC = @"D:\TestAudio\TSRC.mp3";

        [TestMethod]
        public void TestTBPM()
        {
            int expValue = 35;

            Mp3Tag test = new Mp3Tag(_fileNameTBPM);

            Assert.AreEqual(expValue, test.Id3v2.DeliveredFrames.TBPM.Number);
        }

        [TestMethod]
        public void TestTLEN()
        {
            int expValue = 335908;

            Mp3Tag test = new Mp3Tag(_fileNameTOAL);

            Assert.AreEqual(expValue, test.Id3v2.DeliveredFrames.TLEN.Number);
        }

        [TestMethod]
        public void TestTKEY()
        {
            string expValue = "Dbm";

            Mp3Tag test = new Mp3Tag(_fileNameTKEY);

            Assert.AreEqual(expValue, test.Id3v2.DeliveredFrames.TKEY.ToString());
        }

        [TestMethod]
        public void TestTLAN()
        {
            string expValue = "eng";

            Mp3Tag test = new Mp3Tag(_fileNameTLAN);

            Assert.AreEqual(expValue, test.Id3v2.DeliveredFrames.TLAN.ToString());
        }

        [TestMethod]
        public void TestTCON()
        {
            string[] expValue = new string[]
            {
                "MetalCore", "Other", "Other", "255", "Post-rock", "Metal", "Power Metal", "Thrash Metal"
            };

            Mp3Tag[] test = new Mp3Tag[]
            {
                new Mp3Tag(_fileNameIntro),
                new Mp3Tag(_fileNameSample),
                new Mp3Tag(_fileNameTBPM),
                new Mp3Tag(_fileNameTENC),
                new Mp3Tag(_fileNameTIT1),
                new Mp3Tag(_fileNameTLAN),
                new Mp3Tag(_fileNameTOAL),
                new Mp3Tag(_fileNameTSRC)
            };

            Assert.AreEqual(expValue.Length, test.Length);
            for (int i = 0; i < expValue.Length; i++)
            {
                Assert.AreEqual(expValue[i], test[i].Id3v2.DeliveredFrames.TCON.ToString());
            }
        }

        [TestMethod]
        public void TestTMED()
        {
            string[] expValue = new string[] { "CD (Lossless)", "CD (CD)" };

            Mp3Tag[] test = new Mp3Tag[] 
            {
                new Mp3Tag(_fileNameTLAN),
                new Mp3Tag(_fileNameTOAL),
            };

            Assert.AreEqual(expValue.Length, test.Length);
            for (int i = 0; i < expValue.Length; i++)
            {
                Assert.AreEqual(expValue[i], test[i].Id3v2.DeliveredFrames.TMED.ToString());
            }
        }
    }
}
