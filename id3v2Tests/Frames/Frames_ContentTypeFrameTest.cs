using elp87.TagReader.id3v2;
using elp87.TagReader.id3v2.Frames;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.Frames
{
    [TestClass]
    public class Frames_ContentTypeFrameTest
    {
        FrameFlagSet ffs;
        public Frames_ContentTypeFrameTest()
        {
            ffs = new FrameFlagSet(new byte[] { 0x00, 0x00 });
        }

        [TestMethod]
        public void TestNumber()
        {
            string expValue = "Metal";

            byte[] data = new byte[] { 0x00, 0x28, 0x39, 0x29 };
            ContentTypeFrame test = new ContentTypeFrame(ffs, data);

            Assert.AreEqual(expValue, test.ToString());
        }

        [TestMethod]
        public void TestString()
        {
            string expValue = "MetalCore";

            byte[] data = new byte[] { 0x03, 0x4D, 0x65, 0x74, 0x61, 0x6C, 0x43, 0x6F, 0x72, 0x65 };
            ContentTypeFrame test = new ContentTypeFrame(ffs, data);

            Assert.AreEqual(expValue, test.ToString());
        }

        [TestMethod]
        public void TestGenreDictionary()
        {
            string[] expGenres = new string[] 
            { 
                "Blues", "Classic Rock", "Country", "Dance", "Disco", "Funk", "Grunge", "Hip-Hop", "Jazz", "Metal", "New Age", "Oldies", "Other", "Pop", "R&B",
                "Rap", "Reggae", "Rock", "Techno", "Industrial", "Alternative", "Ska", "Death Metal", "Pranks", "Soundtrack", "Euro-Techno", "Ambient", "Trip-Hop",
                "Vocal", "Jazz+Funk", "Fusion", "Trance", "Classical", "Instrumental", "Acid", "House", "Game", "Sound Clip", "Gospel", "Noise", "AlternRock", 
                "Bass", "Soul", "Punk", "Space", "Meditative", "Instrumental Pop", "Instrumental Rock", "Ethnic", "Gothic", "Darkwave", "Techno-Industrial",
                "Electronic", "Pop-Folk", "Eurodance", "Dream", "Southern Rock", "Comedy", "Cult", "Gangsta", "Top 40", "Christian Rap", @"Pop/Funk", "Jungle",
                "Native American", "Cabaret", "New Wave", "Psychadelic", "Rave", "Showtunes", "Trailer", "Lo-Fi", "Tribal", "Acid Punk", "Acid Jazz", "Polka", 
                "Retro", "Musical", "Rock & Roll", "Hard Rock"
            };

            PrivateObject target = new PrivateObject(typeof(ContentTypeFrame));

            for (int i = 0; i < expGenres.Length; i++)
            {
                string value = (string)target.Invoke("GetGenreFromDictionary", i);
                Assert.AreEqual(expGenres[i], value);
            }
        }
    }
}
