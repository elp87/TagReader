using elp87.TagReader;
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

            Assert.AreEqual(expSize, testFileExtHeader.Id3v2.ExtHeader.Size);
            Assert.AreEqual(false, testFileExtHeader.Id3v2.ExtHeader.IsUpdate);
            Assert.AreEqual(true, testFileExtHeader.Id3v2.ExtHeader.IsCRC);
            Assert.AreEqual(false, testFileExtHeader.Id3v2.ExtHeader.IsRestrictions);

        }

        [TestMethod]
        public void TestExtendedHeaderCRC()
        {
            int expInt = 1723688696;

            MP3File testFileExtHeader = new MP3File(_filenameExtHeaderCRC);

            Assert.AreEqual(expInt, testFileExtHeader.Id3v2.ExtHeader.CRC);
        }

        [TestMethod]
        public void TestCombExtHeader()
        {
            elp87.TagReader.id3v2.ExtHeader.TagSizeRestrictions expTagSize = elp87.TagReader.id3v2.ExtHeader.TagSizeRestrictions.NoMore128KBTagSize;
            elp87.TagReader.id3v2.ExtHeader.TextEncodingRestrictions expTextEncod = elp87.TagReader.id3v2.ExtHeader.TextEncodingRestrictions.NoRestrictions;
            elp87.TagReader.id3v2.ExtHeader.TextFieldsSizeRestrictions expTextSizeRestriction = elp87.TagReader.id3v2.ExtHeader.TextFieldsSizeRestrictions.NoLonger1024Char;
            elp87.TagReader.id3v2.ExtHeader.ImageEncodingRestrictions expImageEncodeRestriction = elp87.TagReader.id3v2.ExtHeader.ImageEncodingRestrictions.PngOrJpegOnly;
            elp87.TagReader.id3v2.ExtHeader.ImageSizeRestrictions expImageSizeRestriction = elp87.TagReader.id3v2.ExtHeader.ImageSizeRestrictions.Smaller256Pixel;

            MP3File testFileCombExtHeader = new MP3File(_filenameExtHeaderComb);

            Assert.AreEqual(expTagSize, testFileCombExtHeader.Id3v2.ExtHeader.TagSizeRestriction);
            Assert.AreEqual(expTextEncod, testFileCombExtHeader.Id3v2.ExtHeader.TextEncodingRestriction);
            Assert.AreEqual(expTextSizeRestriction, testFileCombExtHeader.Id3v2.ExtHeader.TextFieldsSizeRestriction);
            Assert.AreEqual(expImageEncodeRestriction, testFileCombExtHeader.Id3v2.ExtHeader.ImageEncodingRestriction);
            Assert.AreEqual(expImageSizeRestriction, testFileCombExtHeader.Id3v2.ExtHeader.ImageSizeRestriction);
        }

        [TestMethod]
        public void TestGetTagSizeRestrictionFromEnum()
        {
            int expValue1MB = 0;
            int expValue128 = 1;

            elp87.TagReader.id3v2.ExtHeader.TagSizeRestrictions restrict1MB = elp87.TagReader.id3v2.ExtHeader.TagSizeRestrictions.NoMore1MBTagSize;
            elp87.TagReader.id3v2.ExtHeader.TagSizeRestrictions restrict128 = elp87.TagReader.id3v2.ExtHeader.TagSizeRestrictions.NoMore128KBTagSize;

            Assert.AreEqual(expValue1MB, (int)restrict1MB);
            Assert.AreEqual(expValue128, (int)restrict128);
        }
        [TestMethod]
        public void TestGetTagSizeRestrictionFromInt()
        {
            elp87.TagReader.id3v2.ExtHeader.TagSizeRestrictions expRestrict = elp87.TagReader.id3v2.ExtHeader.TagSizeRestrictions.NoMore128KBTagSize;

            elp87.TagReader.id3v2.ExtHeader.TagSizeRestrictions restrict = (elp87.TagReader.id3v2.ExtHeader.TagSizeRestrictions)1;
            Assert.AreEqual(expRestrict, restrict);
        }
    }
    
}
