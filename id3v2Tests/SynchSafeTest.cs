using elp87.TagReader.id3v2;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests
{
    [TestClass]
    public class SynchSafeTest
    {
        int ssInt1 = 10;
        int ssInt2 = 383;
        int ssInt3 = 229247;

        byte[] ssByte1 = { 10 };
        byte[] ssByte2 = { 1, 127 };
        byte[] ssByte3 = { 3, 127, 127 };

        int expValue1 = 10;
        int expValue2 = 255;
        int expValue3 = 65535;

        [TestMethod]
        public void SynchsafeIntToIntTest()
        {
            SynchsafeInteger testSSInt1 = new SynchsafeInteger(ssInt1);
            SynchsafeInteger testSSInt2 = new SynchsafeInteger(ssInt2);
            SynchsafeInteger testSSInt3 = new SynchsafeInteger(ssInt3);
            Assert.AreEqual(expValue2, testSSInt2.ToInt());
            Assert.AreEqual(expValue1, testSSInt1.ToInt());
            Assert.AreEqual(expValue3, testSSInt3.ToInt());
        }

        [TestMethod]
        public void SynchsafeByteToIntTest()
        {
            SynchsafeInteger testSSInt1 = new SynchsafeInteger(ssByte1);
            SynchsafeInteger testSSInt2 = new SynchsafeInteger(ssByte2);
            SynchsafeInteger testSSInt3 = new SynchsafeInteger(ssByte3);
            Assert.AreEqual(expValue1, testSSInt1.ToInt());
            Assert.AreEqual(expValue2, testSSInt2.ToInt());
            Assert.AreEqual(expValue3, testSSInt3.ToInt());
        }
               
    }
}
