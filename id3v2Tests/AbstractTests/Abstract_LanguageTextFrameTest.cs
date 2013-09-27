using elp87.TagReader.id3v2;
using elp87.TagReader.id3v2.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.AbstractTests
{
    [TestClass]
    public class Abstract_LanguageTextFrameTest
    {
        private class LanguageTextFrame_TestClass
            : LanguageTextFrame
        {
            public LanguageTextFrame_TestClass(FrameFlagSet flags, byte[] frameData)
                : base(flags, frameData)
            { }
        }

        [TestMethod]
        public void TestGetLang()
        {
            string expLanguage = "eng";

            byte[] testArray = new byte[]  { 0x00, 0x65, 0x6E, 0x67, 0x00 };
            FrameFlagSet ffs = new FrameFlagSet(new byte[] { 0x00, 0x00 });
            LanguageTextFrame_TestClass test = new LanguageTextFrame_TestClass(ffs, testArray);

            Assert.AreEqual(expLanguage, test.language);
        }
    }
}
