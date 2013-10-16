using elp87.TagReader;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.Frames
{
    [TestClass]
    public class Frames_UnsunchTextFrameTest
    {
        private const string _fileNameUSLT = @"D:\TestAudio\USLT.mp3";

        [TestMethod]
        public void TestUSLT()
        {
            string[] expValue = new string[]
            {
                "Test\r\nLyrics" 
            };

            MP3File test = new MP3File(_fileNameUSLT);

            Assert.AreEqual(expValue[0].Length, test.Id3v2.USLT[0].GetLyrics()[0].Length);
        }
    }
}
