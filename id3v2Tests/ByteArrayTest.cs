using elp87.TagReader;
using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests
{
    [TestClass]
    public class ByteArrayTest
    {
        private const string _fileNameIssueTagFinderN2 = @"D:\TestAudio\01 Prey For Me.mp3";
        private const string _fileNameIssueTagFinderN2_1 = @"D:\TestAudio\01 This Time Last Year.mp3";
        

        [TestMethod]
        public void TestFindSubArray()
        {
            string stMask = "SEEK";
            byte[] mask = Encoding.ASCII.GetBytes(stMask);
            Mp3Tag test = new Mp3Tag(_fileNameIssueTagFinderN2);
            byte[] byteArray = test.Id3v2.GetTagArray();
            int position = ByteArray.FindSubArray(byteArray, mask);
        }

        [TestMethod]
        public void TestFindSubArray1()
        {
            string stMask = "SEEK";
            byte[] mask = Encoding.ASCII.GetBytes(stMask);
            Mp3Tag test = new Mp3Tag(_fileNameIssueTagFinderN2_1);
            byte[] byteArray = test.Id3v2.GetTagArray();
            int position = ByteArray.FindSubArray(byteArray, mask);
        }

        [TestMethod]
        public void TestFindSubArraySimple()
        {
            int expValue = 3;
            byte[] array = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C};
            byte[] mask = new byte[] { 0x03, 0x04, 0x05 };

            int index = ByteArray.FindSubArray(array, mask);
            Assert.AreEqual(expValue, index);
        }
    }
}
