using elp87.TagReader.id3v2.Frames;

namespace elp87.TagReader.id3v2
{
    public partial class ID3V2
    {
        // Identification frames
        private void SetTIT1(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._identificationFrames.TIT1 = frame;
        }

        private void SetTIT2(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._identificationFrames.TIT2 = frame;
        }

        private void SetTIT3(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._identificationFrames.TIT3 = frame;
        }

        private void SetTALB(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._identificationFrames.TALB = frame;
        }

        private void SetTOAL(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._identificationFrames.TOAL = frame;
        }

        private void SetTRCK(FrameFlagSet ffs, byte[] data)
        {
            PositionFrame frame = new PositionFrame(ffs, data);
            this._identificationFrames.TRCK = frame;
        }

        private void SetTPOS(FrameFlagSet ffs, byte[] data)
        {
            PositionFrame frame = new PositionFrame(ffs, data);
            this._identificationFrames.TPOS = frame;
        }

        private void SetTSST(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._identificationFrames.TSST = frame;
        }

        private void SetTSRC(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._identificationFrames.TSRC = frame;
        }

        // Involved persons frames
        private void SetTPE1(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._personsFrames.TPE1 = frame;
        }

        private void SetTPE2(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._personsFrames.TPE2 = frame;
        }
        
        private void SetTPE3(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._personsFrames.TPE3 = frame;
        }
        
        private void SetTPE4(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._personsFrames.TPE4 = frame;
        }
    }
    
}
