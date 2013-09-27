using elp87.TagReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests
{
    [TestClass]
    public class BitOperationTest
    {
        [TestMethod]
        public void TestGetBit()
        {
            bool expTrue = true;
            bool expFalse = false;

            byte byte01 = 0x01;
            byte byteCA = 0xCA;

            Assert.AreEqual(expTrue, ByteOperation.GetBit(byte01, 0));
            Assert.AreEqual(expFalse, ByteOperation.GetBit(byte01, 1));

            Assert.AreEqual(false, ByteOperation.GetBit(byteCA, 0));
            Assert.AreEqual(true, ByteOperation.GetBit(byteCA, 1));
            Assert.AreEqual(false, ByteOperation.GetBit(byteCA, 2));
            Assert.AreEqual(true, ByteOperation.GetBit(byteCA, 3));
            Assert.AreEqual(false, ByteOperation.GetBit(byteCA, 4));
            Assert.AreEqual(false, ByteOperation.GetBit(byteCA, 5));
            Assert.AreEqual(true, ByteOperation.GetBit(byteCA, 6));
            Assert.AreEqual(true, ByteOperation.GetBit(byteCA, 7));
        }
    }
}
