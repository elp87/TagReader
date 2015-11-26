using elp87.TagReader;
using elp87.TagReader.id3v2.Frames;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.Frames
{
    [TestClass]
    public class Frames_AttachedPictureFrameTest
    {
        private const string _fileNamePic = @"D:\TestAudio\UFID.mp3";

        Bitmap expPicture;

        public Frames_AttachedPictureFrameTest()
        {
            expPicture = new Bitmap(@"Images\output.jpg");
        }

        [TestMethod]
        public void TestPicture()
        {            
            Mp3Tag test = new Mp3Tag(_fileNamePic);
            Image image = test.Id3v2.APIC[0].GetPicture();

            Assert.AreEqual(expPicture.Width, image.Width);
            Assert.AreEqual(expPicture.Height, image.Height);
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Assert.AreEqual(expPicture.GetPixel(i, j), ((Bitmap)image).GetPixel(i, j));
                }
            }
        }

        [TestMethod]
        public void TestPictureType()
        {
            AttachedPictureFrame.PictureTypes expValue = AttachedPictureFrame.PictureTypes.CoverFront;

            Mp3Tag test = new Mp3Tag(_fileNamePic);

            Assert.AreEqual(expValue, test.Id3v2.APIC[0].PictureType);            
        }
    }
}
