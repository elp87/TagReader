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

        MP3File testFile03 = new MP3File(_filename03);
        MP3File testFile04 = new MP3File(_filename04);

        [TestMethod]
        public void FrameFile3Test()
        {
            string expAlbum = "I Was Here For A Moment, Then I Was Gone";
            string expArtist = "Maybeshewill";
            string expTitle = "Opening";
            string expDate = "2011";
            string expNumber = "1";

            Assert.AreEqual(expAlbum, testFile03.id3v2.album);
            Assert.AreEqual(expArtist, testFile03.id3v2.performer);
            Assert.AreEqual(expTitle, testFile03.id3v2.title);
            Assert.AreEqual(expDate, testFile03.id3v2.year);
            Assert.AreEqual(expNumber, testFile03.id3v2.trackNumber);
        }

        
    }
}
