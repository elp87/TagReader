﻿using elp87.TagReader;
using elp87.TagReader.id3v2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests
{
    [TestClass]
    public class ID3v2HeaderTest
    {
        private const string _filenameNull = @"D:\TestAudio\03.The Sounds Of Infinity - Freedom (Vocal).mp3";
        private const string _filename02 = @"D:\TestAudio\01 Не простил .mp3";
        private const string _filename03 = @"D:\TestAudio\\01 Opening.mp3"; // Maybeshewill [2011 I Was Here For A Moment, Then I Was Gone] - 01 Opening
        private const string _filename04 = @"D:\TestAudio\\01. Интро.mp3"; // ТКН - [Саундтрек моей жизни] - 01. Интро
        
        Mp3Tag testFile03 = new Mp3Tag(_filename03);
        Mp3Tag testFile04 = new Mp3Tag(_filename04);
        
        [TestMethod]
        public void GetHeaderTest()
        {
            byte[] expHeader03 = { 0x49, 0x44, 0x33, 0x03, 0x00, 0x00, 0x00, 0x09, 0x3F, 0x11 };
            byte[] expHeader04 = { 0x49, 0x44, 0x33, 0x04, 0x00, 0x00, 0x00, 0x02, 0x4E, 0x1E };
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(expHeader03[i], testFile03.Id3v2.Header.HeaderArray[i]);
                Assert.AreEqual(expHeader04[i], testFile04.Id3v2.Header.HeaderArray[i]);
            }
        }

        [TestMethod]
        public void TagVersionTest()
        {
            int _expVersion03 = 3;
            int _expVersion04 = 4;
            Assert.AreEqual(_expVersion03, testFile03.Id3v2.Header.TagVersion);
            Assert.AreEqual(_expVersion04, testFile04.Id3v2.Header.TagVersion);
        }

        [TestMethod]
        public void TagSizeTest()
        {
            int _expSize03 = 155537;
            int _expSize04 = 42782;
            Assert.AreEqual(_expSize03, testFile03.Id3v2.Header.TagSize);
            Assert.AreEqual(_expSize04, testFile04.Id3v2.Header.TagSize);
        }

        [TestMethod]
        public void HeaderFlagFieldTest()
        {
            Header.FlagField flag = new Header.FlagField(0x80);
            Header.FlagField _expFlag = new Header.FlagField(false, false, false, false);
            bool expSync = true;
            Assert.AreEqual(expSync, flag.Unsunc);
            Assert.AreEqual(false, flag.ExperimentalIndicator);

            Assert.AreEqual(_expFlag.Unsunc, testFile04.Id3v2.Header.FlagFields.Unsunc);
            Assert.AreEqual(_expFlag.ExtendedHeader, testFile04.Id3v2.Header.FlagFields.ExtendedHeader);
            Assert.AreEqual(_expFlag.ExperimentalIndicator, testFile04.Id3v2.Header.FlagFields.ExperimentalIndicator);
            Assert.AreEqual(_expFlag.Footer, testFile04.Id3v2.Header.FlagFields.Footer);
        }

        [TestMethod]
        [ExpectedException(typeof(elp87.TagReader.id3v2.Exceptions.UnsupportedTagVersionException))]
        public void UnsupportedTagVersionExceptionTest()
        {
            Mp3Tag testFile02 = new Mp3Tag(_filename02);
        }

        [TestMethod]
        [ExpectedException(typeof(elp87.TagReader.id3v2.Exceptions.NoID3V2TagException))]
        public void NoID3V2TagExceptionTest()
        {
            Mp3Tag testFileNull = new Mp3Tag(_filenameNull);
        }

        
    }
}
