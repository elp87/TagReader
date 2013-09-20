using elp87.TagReader.id3v2;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests
{
    [TestClass]
    public class FrameFlagSetTest
    {
        private class FrameFlagSet_TestClass : FrameFlagSet
        {
            public FrameFlagSet_TestClass(byte[] flagBytes)
                : base(flagBytes)
            {
            }

            public bool[] frameFlagSetArray
            {
                get
                {
                    return new bool[]
                    {
                        this.tagAlterPreservation,
                        this.fileAlterPreservation,
                        this.readOnly,
                        this.groupingIdentity,
                        this.compression,
                        this.encryption,
                        this.unsynchronisation,
                        this.dataLengthIndicator
                    };
                }
            }

            public void GetEData(byte[] frameData)
            {
                int i = base.GetExtraDate(frameData, 0, true);
            }
        }

        FrameFlagSet_TestClass ffs_00_00;
        FrameFlagSet_TestClass ffs_70_4F;

        public FrameFlagSetTest()
        {
            ffs_00_00 = new FrameFlagSet_TestClass(new byte[] { 0x00, 0x00 });
            ffs_70_4F = new FrameFlagSet_TestClass(new byte[] { 0x70, 0x4F });
        }



        [TestMethod]
        public void TestFrameFlagSet()
        {
            bool[] exp_flagSet_00_00 = new bool[] { false, false, false, false, false, false, false, false };
            bool[] exp_flagSet_70_4f = new bool[] { true, true, true, true, true, true, true, true };

            CollectionAssert.AreEqual(exp_flagSet_00_00, ffs_00_00.frameFlagSetArray);
            CollectionAssert.AreEqual(exp_flagSet_70_4f, ffs_70_4F.frameFlagSetArray);
        }

        [TestMethod]
        public void TestGetEData()
        {
            FrameFlagSet_TestClass ffs_00_40 = new FrameFlagSet_TestClass(new byte[] { 0x00, 0x40 });
            ffs_00_40.GetEData(new byte[] { 0x4C });

            byte expGroupID = 0x4C;

            Assert.AreEqual(expGroupID, ffs_00_40.grouping);
        }

        [TestMethod]
        [ExpectedException(typeof(elp87.TagReader.id3v2.Exceptions.FlagUnsetException))]
        public void TestFlagUnsetException()
        {
            int i = ffs_00_00.dataLength;
        }

        [TestMethod]
        [ExpectedException(typeof(elp87.TagReader.id3v2.Exceptions.NotUsableFlagException))]
        public void TestNotUsableFlagException()
        {
            FrameFlagSet ffs_01_00 = new FrameFlagSet(new byte[] { 0x01, 0x00 });            
        }
    }
}
