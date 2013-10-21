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
            MP3File test = new MP3File(_fileNameIssueTagFinderN2);
            byte[] byteArray = test.Id3v2.GetTagArray();
            int position = ByteArray.FindSubArray(byteArray, mask);
        }

        [TestMethod]
        public void TestFindSubArray1()
        {
            string stMask = "SEEK";
            byte[] mask = Encoding.ASCII.GetBytes(stMask);
            MP3File test = new MP3File(_fileNameIssueTagFinderN2_1);
            byte[] byteArray = test.Id3v2.GetTagArray();
            int position = ByteArray.FindSubArray(byteArray, mask);
        }
    }
}
