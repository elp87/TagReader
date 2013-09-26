using elp87.TagReader.id3v2;
using elp87.TagReader.id3v2.Abstract;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.AbstractTests
{
    [TestClass]
    public class Abstract_OwnerIDFrameTest
    {
        #region Subclasses
        private class OwnerIDFrame_TestClass
            : OwnerIDFrame
        {
            #region Constructors
            public OwnerIDFrame_TestClass(FrameFlagSet flags, byte[] frameData)
                : base(flags, frameData)
            { } 
            #endregion

            #region Methods
            protected override void ParseFrame(byte[] frameData)
            {
                base.ParseFrame(frameData);
                this._data = this.ReadData(frameData, this._terminatorPos);
            }

            protected override byte[] ReadData(byte[] frameData, int position)
            {
                byte[] data = new byte[frameData.Length - position - 1];
                Array.Copy(frameData, position + 1, data, 0, frameData.Length - position - 1);
                return data;
            } 
            #endregion
        } 
        #endregion

        byte[] testArray;
        OwnerIDFrame_TestClass test;

        public Abstract_OwnerIDFrameTest()
        {
            FrameFlagSet ffs = new FrameFlagSet(new byte[] { 0x00, 0x00 });

            testArray = new byte[]
            {
                0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x77, 0x77, 0x77, 0x2E, 0x63, 0x64, 0x64, 0x62, 0x2E, 
                0x63, 0x6F, 0x6D, 0x2F, 0x69, 0x64, 0x33, 0x2F, 0x74, 0x61, 0x67, 0x69, 0x6E, 0x66, 0x6F, 0x31, 
                0x2E, 0x68, 0x74, 0x6D, 0x6C, 0x00, 0x33, 0x43, 0x44, 0x33, 0x4E, 0x39, 0x33, 0x51, 0x32, 0x36, 
                0x39, 0x33, 0x36, 0x35, 0x39, 0x33, 0x32, 0x55, 0x32, 0x31, 0x38, 0x35, 0x43, 0x34, 0x43, 0x41, 
                0x31, 0x34, 0x44, 0x35, 0x43, 0x44, 0x32, 0x32, 0x39, 0x46, 0x38, 0x38, 0x37, 0x37, 0x32, 0x36, 
                0x42, 0x30, 0x31, 0x31, 0x36, 0x44, 0x38, 0x42, 0x38, 0x42, 0x42, 0x50, 0x32
            };

            test = new OwnerIDFrame_TestClass(ffs, testArray);

        }
        [TestMethod]
        public void TestGetID()
        {
            string expID = "http://www.cddb.com/id3/taginfo1.html";

            Assert.AreEqual(expID, test.ownerID);
        }

        [TestMethod]
        public void TestData()
        {
            byte[] expData = new byte[]
            {
                0x33, 0x43, 0x44, 0x33, 0x4E, 0x39, 0x33, 0x51, 0x32, 0x36, 
                0x39, 0x33, 0x36, 0x35, 0x39, 0x33, 0x32, 0x55, 0x32, 0x31, 0x38, 0x35, 0x43, 0x34, 0x43, 0x41, 
                0x31, 0x34, 0x44, 0x35, 0x43, 0x44, 0x32, 0x32, 0x39, 0x46, 0x38, 0x38, 0x37, 0x37, 0x32, 0x36, 
                0x42, 0x30, 0x31, 0x31, 0x36, 0x44, 0x38, 0x42, 0x38, 0x42, 0x42, 0x50, 0x32
            };

            CollectionAssert.AreEqual(expData, test.GetData());
        }
    }
}
