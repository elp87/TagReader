using elp87.TagReader.id3v2;
using elp87.TagReader.id3v2.Frames;

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.Frames
{
    [TestClass]
    public class Frames_PersonListTextFrameTest
    {
        FrameFlagSet ffs;
        byte[] byteArray00, byteArray01, byteArray02, byteArray03;
        public Frames_PersonListTextFrameTest()
        {
            ffs = new FrameFlagSet(new byte[] { 0x00, 0x00 });
            byteArray00 = new byte[] 
            { 
                0x01, 0xFF, 0xFE, 0x70, 0x00, 0x72, 0x00, 0x6F, 0x00, 0x64, 0x00, 0x75, 0x00, 0x63, 0x00, 0x65, 
                0x00, 0x72, 0x00 
            };
            byteArray01 = new byte[] 
            { 
                0x01, 0xFF, 0xFE, 0x70, 0x00, 0x72, 0x00, 0x6F, 0x00, 0x64, 0x00, 0x75, 0x00, 0x63, 0x00, 0x65, 
                0x00, 0x72, 0x00, 0x4E, 0x00, 0x61, 0x00, 0x6D, 0x00, 0x65, 0x00 
            };

            byteArray02 = new byte[]
            {
                0x01, 0xFF, 0xFE, 0x6D, 0x00, 0x61, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x72, 0x00, 0x69, 
                0x00, 0x6E, 0x00, 0x67, 0x00
            };

            byteArray03 = new byte[]
            {
                0x01, 0xFF, 0xFE, 0x6D, 0x00, 0x61, 0x00, 0x73, 0x00, 0x74, 0x00, 0x65, 0x00, 0x72, 0x00, 0x69, 
                0x00, 0x6E, 0x00, 0x67, 0x00, 0x4E, 0x00, 0x61, 0x00, 0x6D, 0x00, 0x65, 0x00 
            };
        }

        [TestMethod]
        public void TestPersonListItemFrame()
        {
            string expValue = "producer";
            
            PersonListTextFrame.PersonListItemFrame item = new PersonListTextFrame.PersonListItemFrame(ffs, byteArray00);

            Assert.AreEqual(expValue, item.GetString());
        }

        [TestMethod]
        public void TestPersonList()
        {
            string[] expRoles = new string[] { "producer", "mastering" };
            string[] expPersons = new string[] { "producerName", "masteringName" };
            PersonListTextFrame test = new PersonListTextFrame();
            test.AddData(ffs, byteArray00);
            test.AddData(ffs, byteArray01);
            test.AddData(ffs, byteArray02);
            test.AddData(ffs, byteArray03);

            Assert.AreEqual(expRoles.Length, test.ListCount);
            for (int i = 0; i < test.ListCount; i++)
            {
                Assert.AreEqual(expRoles[i], test.GetValue(i).role);
                Assert.AreEqual(expPersons[i], test.GetValue(i).person);
            }
        }
    }
}
