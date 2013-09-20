using elp87.TagReader.id3v2;
using elp87.TagReader.id3v2.Abstract;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.AbstractTests
{
    [TestClass]
    public class Abstract_FrameTest
    {
        #region Subclasses
        private class Frame_TestClass : Frame
        {
            public Frame_TestClass(FrameFlagSet flags, byte[] frameData)
                : base(flags, frameData)
            { }

            public bool[] frameFlagSet
            {
                get
                {
                    return new bool[]
                    {
                        this.flags.tagAlterPreservation,
                        this.flags.fileAlterPreservation,
                        this.flags.readOnly,
                        this.flags.groupingIdentity,
                        this.flags.compression,
                        this.flags.encryption,
                        this.flags.unsynchronisation,
                        this.flags.dataLengthIndicator
                    };
                }
            }            
        }
        #endregion

        FrameFlagSet ffs_00_00;
        Frame_TestClass frame_00_00;

        FrameFlagSet ffs_70_4F;
        Frame_TestClass frame_70_4F;

        public Abstract_FrameTest()
        {
            ffs_00_00 = new FrameFlagSet(new byte[] { 0x00, 0x00 });
            frame_00_00 = new Frame_TestClass(ffs_00_00, new byte[] { 0x00 });

            ffs_70_4F = new FrameFlagSet(new byte[] { 0x70, 0x4F });
            frame_70_4F = new Frame_TestClass(ffs_70_4F, new byte[] { 0x00 });
        }

        

        [TestMethod]
        public void TestFrameFalgSet()
        {           
            bool[] exp_flagSet_00_00 = new bool[] { false, false, false, false, false, false, false, false };
            bool[] exp_flagSet_70_4f = new bool[] { true, true, true, true, true, true, true, true };

            CollectionAssert.AreEqual(exp_flagSet_00_00, frame_00_00.frameFlagSet);
            CollectionAssert.AreEqual(exp_flagSet_70_4f, frame_70_4F.frameFlagSet);
        }        
    }
}
