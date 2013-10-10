namespace elp87.TagReader.id3v2.Frames
{
    public class OtherFrameSet
    {
        #region Fields
        private TextInfoFrame _TOFN;
        private NumericStringFrame _TDLY;
        private DateInfoFrame _TDEN;
        private DateInfoFrame _TDOR;
        private DateInfoFrame _TDRC;
        private DateInfoFrame _TDRL;
        private DateInfoFrame _TDTG;
        private TextInfoFrame _TSSE;
        private TextInfoFrame _TSOA;
        private TextInfoFrame _TSOP;
        private TextInfoFrame _TSOT;
        private UserDefinedTextFrame[] _TXXX;
        #endregion

        #region Constructors
        public OtherFrameSet()
        { }
        #endregion

        #region Properties
        public TextInfoFrame          TOFN { get { return this._TOFN; } set { this._TOFN = value; } }
        public NumericStringFrame     TDLY { get { return this._TDLY; } set { this._TDLY = value; } }
        public DateInfoFrame          TDEN { get { return this._TDEN; } set { this._TDEN = value; } }
        public DateInfoFrame          TDOR { get { return this._TDOR; } set { this._TDOR = value; } }
        public DateInfoFrame          TDRC { get { return this._TDRC; } set { this._TDRC = value; } }
        public DateInfoFrame          TDRL { get { return this._TDRL; } set { this._TDRL = value; } }
        public DateInfoFrame          TDTG { get { return this._TDTG; } set { this._TDTG = value; } }
        public TextInfoFrame          TSSE { get { return this._TSSE; } set { this._TSSE = value; } }
        public TextInfoFrame          TSOA { get { return this._TSOA; } set { this._TSOA = value; } }
        public TextInfoFrame          TSOP { get { return this._TSOP; } set { this._TSOP = value; } }
        public TextInfoFrame          TSOT { get { return this._TSOT; } set { this._TSOT = value; } }
        public UserDefinedTextFrame[] TXXX { get { return this._TXXX; } set { this._TXXX = value; } }
        #endregion

        #region Properties
        internal void AddTXXX(UserDefinedTextFrame frame)
        {
            if ( _TXXX == null || _TXXX.Length == 0 )
            {
                _TXXX = new UserDefinedTextFrame[1];
                _TXXX[0] = frame;
            }
            else
            {
                UserDefinedTextFrame[] temp = new UserDefinedTextFrame[_TXXX.Length];
                for (int i = 0; i < _TXXX.Length; i++) { temp[i] = _TXXX[i]; }
                _TXXX = new UserDefinedTextFrame[temp.Length + 1];
                for (int i = 0; i < temp.Length; i++) { _TXXX[i] = temp[i]; }
                _TXXX[_TXXX.Length - 1] = frame;
            }
        } 
        #endregion
    }
}
