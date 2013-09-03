using elp87.TagReader;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests
{
    [TestClass]
    public class ExtendedHeaderTest
    {
        private const string _filenameExtHeader = @"D:\TestAudio\extHeader_CRC.mp3";

        
        [TestMethod]
        public void TestExtendedHeader()
        {
            int expSize = 12;

            MP3File testFileExtHeader = new MP3File(_filenameExtHeader);
                        
            Assert.AreEqual(expSize, testFileExtHeader.id3v2.extHeader.size);
            Assert.AreEqual(false, testFileExtHeader.id3v2.extHeader.isUpdate);
            Assert.AreEqual(true, testFileExtHeader.id3v2.extHeader.isCRC);
            Assert.AreEqual(false, testFileExtHeader.id3v2.extHeader.isRestrictions);

        }

        [TestMethod]
        public void TestExtendedHeaderCRC()
        {
            int expInt = 1723688696;

            MP3File testFileExtHeader = new MP3File(_filenameExtHeader);

            Assert.AreEqual(expInt, testFileExtHeader.id3v2.extHeader.CRC);            
        }
    }
}
