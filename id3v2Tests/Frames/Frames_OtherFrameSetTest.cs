using elp87.TagReader;
using elp87.TagReader.id3v2.Frames;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.Frames
{
    [TestClass]
    public class Frames_OtherFrameSetTest
    {
        private const string _fileNameTOFN = @"D:\TestAudio\TOFN.mp3";
        private const string _fileNameTENC = @"D:\TestAudio\TENC.mp3";
        private const string _fileNameTLAN = @"D:\TestAudio\TLAN.mp3";
        private const string _fileNameTSOT = @"D:\TestAudio\TSOT.mp3";
        private const string _fileNameTSRC = @"D:\TestAudio\TSRC.mp3";
        private const string _fileNameIntro = @"D:\TestAudio\01. Интро.mp3";

        [TestMethod]
        public void TestTOFN()
        {
            string expValue = "Original file name";

            MP3File test = new MP3File(_fileNameTOFN);

            Assert.AreEqual(expValue, test.Id3v2.OtherFrames.TOFN.ToString());
        }

        [TestMethod]
        public void TestTDRC()
        {
            int expValue = 2009;

            MP3File test = new MP3File(_fileNameIntro);

            Assert.AreEqual(expValue, test.Id3v2.OtherFrames.TDRC.Year);
        }

        [TestMethod]
        public void TestTDRL()
        {
            int expValue = 2007;

            MP3File test = new MP3File(_fileNameTENC);

            Assert.AreEqual(expValue, test.Id3v2.OtherFrames.TDRL.Year);
        }

        [TestMethod]
        public void TestTDTG()
        {
            DateTime expDate = new DateTime(2012, 1, 12, 10, 18, 54);
            int expYear = 2012;

            MP3File test = new MP3File(_fileNameTENC);

            Assert.AreEqual(expDate, test.Id3v2.OtherFrames.TDTG.Date);
            Assert.AreEqual(expYear, test.Id3v2.OtherFrames.TDTG.Year);
        }

        [TestMethod]
        public void TestTSSE()
        {
            string expValue = "-V=\"2\"";

            MP3File test = new MP3File(_fileNameTLAN);

            Assert.AreEqual(expValue, test.Id3v2.OtherFrames.TSSE.ToString());
        }

        [TestMethod]
        public void TestTSOT()
        {
            string expValue = "SortOrder";

            MP3File test = new MP3File(_fileNameTSOT);

            Assert.AreEqual(expValue, test.Id3v2.OtherFrames.TSOT.ToString());
        }

        [TestMethod]
        public void TestTXXX()
        {
            string[][] expDescription = new string[][]
            { 
                new string[] {"CDDB Disc ID", "Encoder", "replaygain_track_gain", "replaygain_track_peak", "replaygain_album_gain", "replaygain_album_peak", "Rip date", "Source", 
                    "Ripping tool", "Release type", @"Catalog #"},
                new string[] {"catalog",  }

            };
            string[][] expValue = new string[][]
            {
                new string[] {"5F083508", "Lame 3.97", "+4.98 dB", "0.381683", "-10.01 dB", "1", "2010-06-09", "CD (LP)", "dBpoweramp", "Normal release", @"n/a"},
                new string[] {"0602517737280"}
            };

            MP3File[] test = new MP3File[]
            {
                new MP3File(_fileNameTLAN),
                new MP3File(_fileNameTSRC)
            };

            Assert.AreEqual(expDescription.Length, test.Length);
            Assert.AreEqual(expValue.Length, test.Length);
            for (int i = 0; i < test.Length; i++)
            {
                Assert.AreEqual(expDescription[i].Length, test[i].Id3v2.OtherFrames.TXXX.Length);
                Assert.AreEqual(expValue[i].Length, test[i].Id3v2.OtherFrames.TXXX.Length);
                for (int j = 0; j < test[i].Id3v2.OtherFrames.TXXX.Length; j++)
                {
                    Assert.AreEqual(expDescription[i][j], test[i].Id3v2.OtherFrames.TXXX[j].Description);
                    Assert.AreEqual(expValue[i][j], test[i].Id3v2.OtherFrames.TXXX[j].Value);
                }
            }
        }
    }
}
