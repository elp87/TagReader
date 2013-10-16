using elp87.TagReader;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.Frames
{
    [TestClass]
    public class Frames_UnsunchTextFrameTest
    {
        private const string _fileNameUSLT = @"D:\TestAudio\USLT.mp3";
        private const string _fileNameTOAL = @"D:\TestAudio\TOAL.mp3";

        [TestMethod]
        public void TestUSLT()
        {
            string expValue = "Test\r\nLyrics";

            MP3File test = new MP3File(_fileNameUSLT);

            Assert.AreEqual(expValue.Length, test.Id3v2.USLT[0].Value.Length);
            Assert.AreEqual(expValue, test.Id3v2.USLT[0].Value);
        }

        [TestMethod]
        public void TestRealUSLT()
        {
            string expValue = "Murder, treason! ring the bell, awake!\r\nonly horror and silence\r\nwho could have dared to do so?\r\nour king is death!\r\nWho killed him? I will cut his hand\r\nwho did it? I can not believe\r\ni did not hear a noise I did not feel\r\nin my heart it could happen\r\n\r\nI could never forget that morning\r\nit was over we were left alone\r\nhe was all covered in blood\r\nhe was gone\r\nit feels like I’m still hearing him around\r\n\r\nWe did not shed a tear that day and left\r\non hour horses we ran away\r\nnow we’re so far from home and alone\r\nremember all every day\r\nit is all so far away\r\n\r\nI could never forget that morning\r\nit was over we were left alone\r\nhe was all covered in blood\r\nhe was gone\r\nit feels like I’m still hearing him around\r\n\r\nthose daggers were found beside him\r\nif they could only tell\r\nwhich was the killer hand\r\nremember all every day\r\nit is all so far away\r\nI could never forget that morning...\r\n";

            MP3File test = new MP3File(_fileNameTOAL);

            Assert.AreEqual(expValue, test.Id3v2.USLT[0].Value);
        }

        [TestMethod]
        public void MyTestMethod()
        {
            MP3File test = new MP3File(@"D:\music\google.Play\Korn\The Paradigm Shift\01 Prey For Me.mp3");
        }
    }
}
