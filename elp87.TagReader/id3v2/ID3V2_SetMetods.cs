using elp87.TagReader.id3v2.Frames;
using System;
using System.Text;

namespace elp87.TagReader.id3v2
{
    public partial class ID3V2
    {
        public void SetTIT1(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._identificationFrames.TIT1 = frame;
        }

        public void SetTIT2(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._identificationFrames.TIT2 = frame;
        }

        public void SetTIT3(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._identificationFrames.TIT3 = frame;
        }

        public void SetTALB(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._identificationFrames.TALB = frame;
        }

        public void SetTOAL(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._identificationFrames.TOAL = frame;
        }
    }
    
}
