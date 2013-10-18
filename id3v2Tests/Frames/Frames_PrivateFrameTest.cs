using elp87.TagReader;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.Frames
{
    [TestClass]
    public class Frames_PrivateFrameTest
    {
        private const string _fileNameSvetSneg = @"D:\TestAudio\Свет-Снег.mp3";

        [TestMethod]
        public void TestPRIV()
        {
            string[] expOwnerID = new string[]
            {
                "PeakValue", "AverageLevel"
            };
            byte[][] expData = new byte[][]
            {
                new byte[] {0xA1, 0x7F, 0x00, 0x00},
                new byte[] {0x7B, 0x2A, 0x00, 0x00}
            };

            MP3File test = new MP3File(_fileNameSvetSneg);

            Assert.AreEqual(expOwnerID.Length, test.Id3v2.PRIV.Length);
            for(int i = 0; i < expOwnerID.Length; i++)
            {
                Assert.AreEqual(expOwnerID[i], test.Id3v2.PRIV[i].OwnerID);
                CollectionAssert.AreEqual(expData[i], test.Id3v2.PRIV[i].GetData());
            }
        }
    }
}
