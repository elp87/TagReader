using elp87.TagReader;
using elp87.TagReader.id3v2;
using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests
{
    [TestClass]
    public class ID3v2HeaderTest
    {
        private const string _filenameNull = @"D:\TestAudio\03.The Sounds Of Infinity - Freedom (Vocal).mp3";
        private const string _filename02 = @"D:\TestAudio\01 Не простил .mp3";
        private const string _filename03 = @"Audio\01 Opening.mp3"; // Maybeshewill [2011 I Was Here For A Moment, Then I Was Gone] - 01 Opening
        private const string _filename04 = @"Audio\01. Интро.mp3"; // ТКН - [Саундтрек моей жизни] - 01. Интро

        MP3File testFile03 = new MP3File(_filename03);
        MP3File testFile04 = new MP3File(_filename04);
        
        [TestMethod]
        public void GetHeaderTest()
        {
            byte[] expHeader03 = { 0x49, 0x44, 0x33, 0x03, 0x00, 0x00, 0x00, 0x09, 0x3F, 0x11 };
            byte[] expHeader04 = { 0x49, 0x44, 0x33, 0x04, 0x00, 0x00, 0x00, 0x02, 0x4E, 0x1E };
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(expHeader03[i], testFile03.id3v2.header.header[i]);
                Assert.AreEqual(expHeader04[i], testFile04.id3v2.header.header[i]);
            }
        }

        [TestMethod]
        public void TagVersionTest()
        {
            int _expVersion03 = 3;
            int _expVersion04 = 4;
            Assert.AreEqual(_expVersion03, testFile03.id3v2.header.tagVersion);
            Assert.AreEqual(_expVersion04, testFile04.id3v2.header.tagVersion);
        }

        [TestMethod]
        public void TagSizeTest()
        {
            int _expSize03 = 155537;
            int _expSize04 = 42782;
            Assert.AreEqual(_expSize03, testFile03.id3v2.header.tagSize);
            Assert.AreEqual(_expSize04, testFile04.id3v2.header.tagSize);
        }

        [TestMethod]
        public void HeaderFlagFieldTest()
        {
            Header.FlagField flag = new Header.FlagField(0x80);
            Header.FlagField _expFlag = new Header.FlagField(false, false, false, false);
            bool expSync = true;
            Assert.AreEqual(expSync, flag.unsunc);
            Assert.AreEqual(false, flag.experimentalIndicator);

            Assert.AreEqual(_expFlag.unsunc, testFile04.id3v2.header.flagField.unsunc);
            Assert.AreEqual(_expFlag.extendedHeader, testFile04.id3v2.header.flagField.extendedHeader);
            Assert.AreEqual(_expFlag.experimentalIndicator, testFile04.id3v2.header.flagField.experimentalIndicator);
            Assert.AreEqual(_expFlag.footer, testFile04.id3v2.header.flagField.footer);
        }

        [TestMethod]
        [ExpectedException(typeof(elp87.TagReader.id3v2.Exceptions.UnsupportedTagVersionException))]
        public void UnsupportedTagVersionExceptionTest()
        {
            MP3File testFile02 = new MP3File(_filename02);
        }

        [TestMethod]
        [ExpectedException(typeof(elp87.TagReader.id3v2.Exceptions.NoID3V2TagException))]
        public void NoID3V2TagExceptionTest()
        {
            MP3File testFileNull = new MP3File(_filenameNull);
        }
    }
}
