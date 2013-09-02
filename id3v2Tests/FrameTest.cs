using elp87.TagReader;
using elp87.TagReader.id3v2;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests
{
    [TestClass]
    public class FrameTest
    {
        private const string _filename03 = @"Audio\01 Opening.mp3"; // Maybeshewill [2011 I Was Here For A Moment, Then I Was Gone] - 01 Opening
        private const string _filename04 = @"Audio\01. Интро.mp3"; // ТКН - [Саундтрек моей жизни] - 01. Интро
        private const string _filenameTIE = @"D:\TestAudio\07 Манечка.mp3";
        
        MP3File testFile03 = new MP3File(_filename03);
        MP3File testFile04 = new MP3File(_filename04);

        [TestMethod]
        public void FrameFile3Test()
        {
            string expAlbum = "I Was Here For A Moment, Then I Was Gone";
            string expArtist = "Maybeshewill";
            string expTitle = "Opening";
            string expDate = "2011";
            string expNumber = "01/1";

            Assert.AreEqual(expAlbum, testFile03.id3v2.album);
            Assert.AreEqual(expArtist, testFile03.id3v2.performer);
            Assert.AreEqual(expTitle, testFile03.id3v2.title);
            Assert.AreEqual(expDate, testFile03.id3v2.year);
            Assert.AreEqual(expNumber, testFile03.id3v2.trackPosition);
        }

        [TestMethod]
        public void FrameStoaTest()
        {
            string _filename = @"D:\TestAudio\11 Hommage.mp3";
            MP3File testFile = new MP3File(_filename);
            string expArtist = "sToa";

            Assert.AreEqual(expArtist, testFile.id3v2.performer);
        }

        [TestMethod]
        public void FrameTRCKWithDotTest()
        {
            MP3File testFileWithDot = new MP3File(_filenameTIE);

            string expTrackPositionWithDot = "1.07";
            int expTrackNumberWithDot = 7;
            string expTrackPositionWithSlash = "01/1";
            int expTrackNumberWithSlash = 1;

            Assert.AreEqual(expTrackPositionWithDot, testFileWithDot.id3v2.trackPosition);
            Assert.AreEqual(expTrackNumberWithDot, testFileWithDot.id3v2.trackNumber);

            Assert.AreEqual(expTrackPositionWithSlash, testFile03.id3v2.trackPosition);
            Assert.AreEqual(expTrackNumberWithSlash, testFile03.id3v2.trackNumber);
        }
        
    }
}
