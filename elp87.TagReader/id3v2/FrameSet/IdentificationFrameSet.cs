namespace elp87.TagReader.id3v2.Frames
{
    public class IdentificationFrameSet
    {
        #region Fields
        private TextInfoFrame _TIT1;
        private TextInfoFrame _TIT2;
        private TextInfoFrame _TIT3;
        private TextInfoFrame _TALB;
        private TextInfoFrame _TOAL;
        private PositionFrame _TRCK;
        private PositionFrame _TPOS;
        private TextInfoFrame _TSST;
        private TextInfoFrame _TSRC;
        #endregion

        #region Constructors
        public IdentificationFrameSet()
        {
        }
        #endregion

        #region Properties
        public TextInfoFrame TIT1 { get { return _TIT1; } set { this._TIT1 = value; } }
        public TextInfoFrame TIT2 { get { return _TIT2; } set { this._TIT2 = value; } }
        public TextInfoFrame TIT3 { get { return _TIT3; } set { this._TIT3 = value; } }
        public TextInfoFrame TALB { get { return _TALB; } set { this._TALB = value; } }
        public TextInfoFrame TOAL { get { return _TOAL; } set { this._TOAL = value; } }
        public PositionFrame TRCK { get { return _TRCK; } set { this._TRCK = value; } }
        public PositionFrame TPOS { get { return _TPOS; } set { this._TPOS = value; } }
        public TextInfoFrame TSST { get { return _TSST; } set { this._TSST = value; } }
        public TextInfoFrame TSRC { get { return _TSRC; } set { this._TSRC = value; } }
        #endregion
        
    }
}
