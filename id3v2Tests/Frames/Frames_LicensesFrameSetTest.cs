﻿using elp87.TagReader;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.Frames
{
    [TestClass]
    public class Frames_LicensesFrameSetTest
    {
        private const string _fileNameTENC = @"D:\TestAudio\TENC.mp3";
        private const string _fileNameTLAN = @"D:\TestAudio\TLAN.mp3";
        private const string _fileNameTOAL = @"D:\TestAudio\TOAL.mp3";

        [TestMethod]
        public void TestTCOP()
        {
            string expValue = @"2007-11-27T16:11:38+01:00 The Phase. Licensed to the public under http://creativecommons.org/licenses/by-sa/3.0/ verify at http://www.jamendo.comalbum/13125/";

            Mp3Tag test = new Mp3Tag(_fileNameTENC);

            Assert.AreEqual(expValue, test.Id3v2.LicensesFrames.TCOP.ToString());
        }

        [TestMethod]
        public void TestTPUB()
        {
            string[] expValue = new string[] { "Jamendo", "My Place Records" };

            Mp3Tag[] test = new Mp3Tag[]
            {
                new Mp3Tag(_fileNameTENC),
                new Mp3Tag(_fileNameTLAN)
            };

            Assert.AreEqual(expValue.Length, test.Length);
            for (int i = 0; i < expValue.Length; i++)
            {
                Assert.AreEqual(expValue[i], test[i].Id3v2.LicensesFrames.TPUB.ToString());
            }
        }

        [TestMethod]
        public void TestTOWN()
        {
            string expValue = @"Federico Agudo Calderón 50456599G , Diego Millán Ruíz 33531313G , David Imbernon Alcántara 50462594L , Oriana Daleina Castillo Matute X9367817D, Daniel Cabal Fernández 09428917K";

            Mp3Tag test = new Mp3Tag(_fileNameTOAL);

            Assert.AreEqual(expValue, test.Id3v2.LicensesFrames.TOWN.ToString());
        }
    }
}
