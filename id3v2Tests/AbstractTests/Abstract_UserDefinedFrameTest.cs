using elp87.TagReader.id3v2;
using elp87.TagReader.id3v2.Abstract;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.AbstractTests
{
    [TestClass]
    public class Abstract_UserDefinedFrameTest
    {
        #region Subclasses
        private class UserDefinedFrame_TestClass
             : UserDefinedFrame
        {
            public UserDefinedFrame_TestClass(FrameFlagSet flags, byte[] frameData)
                : base(flags, frameData)
            { }

            protected override string ParseValue(byte[] frameData)
            {
                byte[] valueByte = new byte[frameData.Length - this._terminatorPos - 1];
                Array.Copy(frameData, this._terminatorPos + 1, valueByte, 0, valueByte.Length);
                return this.GetString(valueByte);
            }
        }
        #endregion

        byte[] testArray;
        UserDefinedFrame_TestClass test;

        public Abstract_UserDefinedFrameTest()
        {
            testArray = new byte[] { 0x00, 0x6D, 0x61, 0x6A, 0x6F, 0x72, 0x5F, 0x62, 0x72, 0x61, 0x6E, 0x64, 0x00, 0x4D, 0x34, 0x41, 0x20 };
            FrameFlagSet ffs = new FrameFlagSet(new byte[] { 0x00, 0x00 });
            test = new UserDefinedFrame_TestClass(ffs, testArray);
        }

        

        [TestMethod]
        public void TestUserDefined()
        {
            string expDescription = "major_brand";
            string expValue = "M4A ";

            Assert.AreEqual(expDescription, test.description);
            Assert.AreEqual(expValue, test.value);
        }
    }
    


}
