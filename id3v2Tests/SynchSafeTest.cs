using elp87.TagReader.id3v2;
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
        byte[] ssByte3 = { 0, 3, 127, 127 };
        byte[] ssByte4 = { 0, 9, 63, 17 };

        byte[] ssCRCBytes = { 0x06, 0x35, 0x75, 0x4D, 0x78 };

        int expValue1 = 10;
        int expValue2 = 255;
        int expValue3 = 65535;
        int expValue4 = 155537;

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
            SynchsafeInteger testSSInt4 = new SynchsafeInteger(ssByte4);
            Assert.AreEqual(expValue1, testSSInt1.ToInt());
            Assert.AreEqual(expValue2, testSSInt2.ToInt());
            Assert.AreEqual(expValue3, testSSInt3.ToInt());
            Assert.AreEqual(expValue4, testSSInt4.ToInt());            
        }

        [TestMethod]
        public void TestSynchsafeIntToSynchsafeByte()
        {
            SynchsafeInteger testSSInt2 = new SynchsafeInteger(ssByte2);
            int ssIntCalc = testSSInt2.SynchSafeInt;

            Assert.AreEqual(ssInt2, ssIntCalc);
        }

        [TestMethod]
        public void TestSynchsafeCRCToInt()
        {            
            int expInt = 1723688696;

            SynchsafeCRC test = new SynchsafeCRC(ssCRCBytes);

            Assert.AreEqual(expInt, test.ToInt());
        }

        [TestMethod]
        public void TestSynchsafeCRCToCRC32()
        {
            byte[] expByte = { 0X66, 0xBD, 0x66, 0xF8 };

            SynchsafeCRC test = new SynchsafeCRC(ssCRCBytes);

            CollectionAssert.AreEqual(expByte, test.ToByte());
        }

        [TestMethod]
        [ExpectedException(typeof(elp87.TagReader.id3v2.Exceptions.InvalidSynchSafeInt32Exception))]
        public void TestInvalidCRC()
        {
            SynchsafeCRC test = new SynchsafeCRC(ssByte4);
        }
    }
}
