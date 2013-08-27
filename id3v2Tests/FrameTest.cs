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
        public void FrameTest1()
        {
            string expID = "TALB";
            string expAlbum = "I Was Here For A Moment, Then I Was Gone";
            string expArtist = "Maybeshewill";

            Assert.AreEqual(expID, testFile03.id3v2.frame.id);
            Assert.AreEqual(expAlbum, testFile03.id3v2.album);
            Assert.AreEqual(expArtist, testFile03.id3v2.performer);
        }
    }
}
