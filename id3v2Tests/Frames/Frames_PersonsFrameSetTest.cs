using elp87.TagReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.Frames
{
    [TestClass]
    public class Frames_PersonsFrameSetTest
    {
        private const string _fileNameOpening = @"D:\TestAudio\01 Opening.mp3";
        private const string _fileNameIntro = @"D:\TestAudio\01. Интро.mp3";
        private const string _fileNameTIT1 = @"D:\TestAudio\TIT1.mp3";
        private const string _fileNameTOAL = @"D:\TestAudio\TOAL.mp3";
        private const string _fileNameTSRC = @"D:\TestAudio\TSRC.mp3";
        private const string _fileNameTIPL = @"D:\TestAudio\TIPL.mp3";
        private const string _fileNameTENC = @"D:\TestAudio\TENC.mp3";
        private const string _fileNameSvetSneg = @"D:\TestAudio\Свет-Снег.mp3";

        [TestMethod]
        public void TestTPE1()
        {
            string[] expValue = new string[]
            {
                "Maybeshewill", "ТонкаяКраснаяНить", "Pelican", "Enuma Elish", "Metallica"
            };


            MP3File[] testFiles = new MP3File[]
                {
                    new MP3File(_fileNameOpening),
                    new MP3File(_fileNameIntro),
                    new MP3File(_fileNameTIT1),
                    new MP3File(_fileNameTOAL),
                    new MP3File(_fileNameTSRC)
                };
            Assert.AreEqual(expValue.Length, testFiles.Length);
            for (int i = 0; i < testFiles.Length; i++)
            {
                Assert.AreEqual(expValue[i], testFiles[i].Id3v2.PersonsFrames.TPE1.ToString());
            }
        }

        [TestMethod]
        public void TestTPE2()
        {
            string expValue = "MOLECUL";

            MP3File test = new MP3File(_fileNameSvetSneg);

            Assert.AreEqual(expValue, test.Id3v2.PersonsFrames.TPE2.ToString());
        }

        [TestMethod]
        public void TestTPE3()
        {
            string expValue =  "MOLECUL";

            MP3File test = new MP3File(_fileNameSvetSneg);

            Assert.AreEqual(expValue, test.Id3v2.PersonsFrames.TPE3.ToString());
        }

        [TestMethod]
        public void TestTPE4()
        {
            string expValue = "FEDE AGUDO";

            MP3File test = new MP3File(_fileNameTOAL);

            Assert.AreEqual(expValue, test.Id3v2.PersonsFrames.TPE4.ToString());
        }

        [TestMethod]
        public void TestTOPE()
        {
            string[] expValue = new string[] 
            { 
                "ENUMA ELISH", "MOLECUL"
            };

            MP3File[] testFiles = new MP3File[]
            {
                new MP3File(_fileNameTOAL),
                new MP3File(_fileNameSvetSneg)
            };

            Assert.AreEqual(expValue.Length, testFiles.Length);
            for (int i = 0; i < testFiles.Length; i++)
            {
                Assert.AreEqual(expValue[i], testFiles[i].Id3v2.PersonsFrames.TOPE.ToString());
            }
        }

        [TestMethod]
        public void TestTEXT()
        {
            string[] expValue = new string[]
            {
                "ENUMA ELISH", "MOLECUL"
            };

            MP3File[] testFiles = new MP3File[]
            {
                new MP3File(_fileNameTOAL),
                new MP3File(_fileNameSvetSneg)
            };

            Assert.AreEqual(expValue.Length, testFiles.Length);
            for (int i = 0; i < testFiles.Length; i++)
            {
                Assert.AreEqual(expValue[i], testFiles[i].Id3v2.PersonsFrames.TEXT.ToString());
            }
        }

        [TestMethod]
        public void TestTOLY()
        {
            string[] expValue = new string[]
            {
                "Federico Agudo Calderón 50456599G , Diego Millán Ruíz 33531313G , David Imbernon Alcántara 50462594L , Oriana Daleina Castillo Matute X9367817D, Daniel Cabal Fernández 09428917K", 
                "MOLECUL"
            };

            MP3File[] testFiles = new MP3File[]
            {
                new MP3File(_fileNameTOAL),
                new MP3File(_fileNameSvetSneg)
            };

            Assert.AreEqual(expValue.Length, testFiles.Length);
            for (int i = 0; i < testFiles.Length; i++)
            {
                Assert.AreEqual(expValue[i], testFiles[i].Id3v2.PersonsFrames.TOLY.ToString());
            }
        }

        [TestMethod]
        public void TestTCOM()
        {
            string expValue = "MOLECUL";

            MP3File test = new MP3File(_fileNameSvetSneg);

            Assert.AreEqual(expValue, test.Id3v2.PersonsFrames.TCOM.ToString());
        }

        [TestMethod]
        public void TestTIPL()
        {
            string[] expRoles = new string[]
            {
                "producer", "mastering"
            };
            string[] expPersons = new string[]
            {
                "producerName", "masteringName"
            };

            MP3File test = new MP3File(_fileNameTIPL);

            for (int i = 0; i < expRoles.Length; i++)
            {
                Assert.AreEqual(expRoles[i], test.Id3v2.PersonsFrames.TIPL.GetValue(i).role);
                Assert.AreEqual(expPersons[i], test.Id3v2.PersonsFrames.TIPL.GetValue(i).person);
            }
        }

        [TestMethod]
        public void TestTENC()
        {
            string expValue = @"Jamendo : http://www.jamendo.com | LAME";

            MP3File test = new MP3File(_fileNameTENC);

            Assert.AreEqual(expValue, test.Id3v2.PersonsFrames.TENC.ToString());
        }
    }
}
