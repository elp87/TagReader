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

        private void SetTOPE(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._personsFrames.TOPE = frame;
        }

        private void SetTEXT(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._personsFrames.TEXT = frame;
        }

        private void SetTOLY(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._personsFrames.TOLY = frame;
        }

        private void SetTCOM(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._personsFrames.TCOM = frame;
        }

        private void SetTMCL(FrameFlagSet ffs, byte[] data)
        {
            if (this._personsFrames.TMCL == null)
            {
                this._personsFrames.TMCL = new PersonListTextFrame();
            }
            this._personsFrames.TMCL.AddData(ffs, data);
        }

        private void SetTIPL(FrameFlagSet ffs, byte[] data)
        {
            if (this._personsFrames.TIPL == null)
            {
                this._personsFrames.TIPL = new PersonListTextFrame();
            }
            this._personsFrames.TIPL.AddData(ffs, data);
        }

        private void SetTENC(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._personsFrames.TENC = frame;
        }

        // Derived and subjective properties frames
        private void SetTBPM(FrameFlagSet ffs, byte[] data)
        {
            NumericStringFrame frame = new NumericStringFrame(ffs, data);
            this._deliveredFrames.TBPM = frame;
        }

        private void SetTLEN(FrameFlagSet ffs, byte[] data)
        {
            NumericStringFrame frame = new NumericStringFrame(ffs, data);
            this._deliveredFrames.TLEN = frame;
        }

        private void SetTKEY(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._deliveredFrames.TKEY = frame;
        }

        private void SetTLAN(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._deliveredFrames.TLAN = frame;
        }

        private void SetTCON(FrameFlagSet ffs, byte[] data)
        {
            ContentTypeFrame frame = new ContentTypeFrame(ffs, data);
            this._deliveredFrames.TCON = frame;
        }

        private void SetTFLT(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._deliveredFrames.TFLT = frame;
        }

        private void SetTMED(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._deliveredFrames.TMED = frame;
        }

        private void SetTMOO(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._deliveredFrames.TMOO = frame;
        }

        // Rights and license frames
        private void SetTCOP(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._licensesFrames.TCOP = frame;
        }

        private void SetTPRO(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._licensesFrames.TPRO = frame;
        }

        private void SetTPUB(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._licensesFrames.TPUB = frame;
        }

        private void SetTOWN(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._licensesFrames.TOWN = frame;
        }

        private void SetTRSN(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._licensesFrames.TRSN = frame;
        }

        private void SetTRSO(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._licensesFrames.TRSO = frame;
        }

        // Other text frames
        private void SetTOFN(FrameFlagSet ffs, byte[] data)
        {
            TextInfoFrame frame = new TextInfoFrame(ffs, data);
            this._otherFrames.TOFN = frame;
        }

        private void SetTDLY(FrameFlagSet ffs, byte[] data)
        {
            NumericStringFrame frame = new NumericStringFrame(ffs, data);
            this._otherFrames.TDLY = frame;
        }

        private void SetTDEN(FrameFlagSet ffs, byte[] data)
        {
            DateInfoFrame frame = new DateInfoFrame(ffs, data);
            this._otherFrames.TDEN = frame;
        }

        private void SetTDOR(FrameFlagSet ffs, byte[] data)
        {
            DateInfoFrame frame = new DateInfoFrame(ffs, data);
            this._otherFrames.TDOR = frame;
        }

        private void SetTDRC(FrameFlagSet ffs, byte[] data)
        {
            DateInfoFrame frame = new DateInfoFrame(ffs, data);
            this._otherFrames.TDRC = frame;
        }

        private void SetTDRL(FrameFlagSet ffs, byte[] data)
        {
            DateInfoFrame frame = new DateInfoFrame(ffs, data);
            this._otherFrames.TDRL = frame;
        }

        private void SetTDTG(FrameFlagSet ffs, byte[] data)
        {
            DateInfoFrame frame = new DateInfoFrame(ffs, data);
            this._otherFrames.TDTG = frame;
        }
    }
    
}
