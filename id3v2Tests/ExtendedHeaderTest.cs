using elp87.TagReader;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests
{
    [TestClass]
    public class ExtendedHeaderTest
    {
        private const string _filenameExtHeaderCRC = @"D:\TestAudio\extHeader_CRC.mp3";
        private const string _filenameExtHeaderComb = @"D:\TestAudio\extHeader1.mp3";


        [TestMethod]
        public void TestExtendedHeader()
        {
            int expSize = 12;

            MP3File testFileExtHeader = new MP3File(_filenameExtHeaderCRC);

            Assert.AreEqual(expSize, testFileExtHeader.id3v2.extHeader.size);
            Assert.AreEqual(false, testFileExtHeader.id3v2.extHeader.isUpdate);
            Assert.AreEqual(true, testFileExtHeader.id3v2.extHeader.isCRC);
            Assert.AreEqual(false, testFileExtHeader.id3v2.extHeader.isRestrictions);

        }

        [TestMethod]
        public void TestExtendedHeaderCRC()
        {
            int expInt = 1723688696;

            MP3File testFileExtHeader = new MP3File(_filenameExtHeaderCRC);

            Assert.AreEqual(expInt, testFileExtHeader.id3v2.extHeader.CRC);
        }

        [TestMethod]
        public void TestCombExtHeader()
        {
            elp87.TagReader.id3v2.ExtHeader.TagSizeRestriction expTagSize = elp87.TagReader.id3v2.ExtHeader.TagSizeRestriction.NoMore128KBTagSize;
            elp87.TagReader.id3v2.ExtHeader.TextEncodingRestriction expTextEncod = elp87.TagReader.id3v2.ExtHeader.TextEncodingRestriction.NoRestrictions;
            elp87.TagReader.id3v2.ExtHeader.TextFieldsSizeRestriction expTextSizeRestriction = elp87.TagReader.id3v2.ExtHeader.TextFieldsSizeRestriction.NoLonger1024Char;
            elp87.TagReader.id3v2.ExtHeader.ImageEncodingRestriction expImageEncodeRestriction = elp87.TagReader.id3v2.ExtHeader.ImageEncodingRestriction.PngOrJpegOnly;
            elp87.TagReader.id3v2.ExtHeader.ImageSizeRestriction expImageSizeRestriction = elp87.TagReader.id3v2.ExtHeader.ImageSizeRestriction.Smaller256Pixel;

            MP3File testFileCombExtHeader = new MP3File(_filenameExtHeaderComb);

            Assert.AreEqual(expTagSize, testFileCombExtHeader.id3v2.extHeader.tagSizeRestriction);
            Assert.AreEqual(expTextEncod, testFileCombExtHeader.id3v2.extHeader.textEncodingRestriction);
            Assert.AreEqual(expTextSizeRestriction, testFileCombExtHeader.id3v2.extHeader.textFieldsSizeRestriction);
            Assert.AreEqual(expImageEncodeRestriction, testFileCombExtHeader.id3v2.extHeader.imageEncodingRestriction);
            Assert.AreEqual(expImageSizeRestriction, testFileCombExtHeader.id3v2.extHeader.imageSizeRestriction);
        }

        [TestMethod]
        public void TestGetTagSizeRestrictionFromEnum()
        {
            int expValue1MB = 0;
            int expValue128 = 1;

            elp87.TagReader.id3v2.ExtHeader.TagSizeRestriction restrict1MB = elp87.TagReader.id3v2.ExtHeader.TagSizeRestriction.NoMore1MBTagSize;
            elp87.TagReader.id3v2.ExtHeader.TagSizeRestriction restrict128 = elp87.TagReader.id3v2.ExtHeader.TagSizeRestriction.NoMore128KBTagSize;

            Assert.AreEqual(expValue1MB, (int)restrict1MB);
            Assert.AreEqual(expValue128, (int)restrict128);
        }
        [TestMethod]
        public void TestGetTagSizeRestrictionFromInt()
        {
            elp87.TagReader.id3v2.ExtHeader.TagSizeRestriction expRestrict = elp87.TagReader.id3v2.ExtHeader.TagSizeRestriction.NoMore128KBTagSize;

            elp87.TagReader.id3v2.ExtHeader.TagSizeRestriction restrict = (elp87.TagReader.id3v2.ExtHeader.TagSizeRestriction)1;
            Assert.AreEqual(expRestrict, restrict);
        }
    }
    
}
