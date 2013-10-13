namespace elp87.TagReader.id3v2.Frames
{
    public class UrlFrameSet
    {
        #region Fields
        private UrlFrame[] _WCOM;
        private UrlFrame _WCOP;
        private UrlFrame _WOAF;
        private UrlFrame[] _WOAR;
        private UrlFrame _WOAS;
        private UrlFrame _WORS;
        private UrlFrame _WPAY;
        private UrlFrame _WPUB;
        private UserDefinedUrlFrame[] _WXXX; 
        #endregion

        #region Constructors
        public UrlFrameSet()
        { }
        #endregion

        #region Properties
        public UrlFrame[]            WCOM { get { return this._WCOM; } set { this._WCOM = value; } }
        public UrlFrame              WCOP { get { return this._WCOP; } set { this._WCOP = value; } }
        public UrlFrame              WOAF { get { return this._WOAF; } set { this._WOAF = value; } }
        public UrlFrame[]            WOAR { get { return this._WOAR; } set { this._WOAR = value; } }
        public UrlFrame              WOAS { get { return this._WOAS; } set { this._WOAS = value; } }
        public UrlFrame              WORS { get { return this._WORS; } set { this._WORS = value; } }
        public UrlFrame              WPAY { get { return this._WPAY; } set { this._WPAY = value; } }
        public UrlFrame              WPUB { get { return this._WPUB; } set { this._WPUB = value; } }
        public UserDefinedUrlFrame[] WXXX { get { return this._WXXX; } set { this._WXXX = value; } }
        #endregion

        #region Methods
        internal void AddWCOM(UrlFrame frame)
        {
            if ( _WCOM == null || _WCOM.Length == 0 )
            {
                _WCOM = new UrlFrame[1];
                _WCOM[0] = frame;
            }
            else
            {
                UrlFrame[] temp = new UrlFrame[_WCOM.Length];
                for (int i = 0; i < _WCOM.Length; i++) { temp[i] = _WCOM[i]; }
                _WCOM = new UrlFrame[temp.Length + 1];
                for (int i = 0; i < temp.Length; i++) { _WCOM[i] = temp[i]; }
                _WCOM[_WCOM.Length - 1] = frame;
            }         
        }

        internal void AddWOAR(UrlFrame frame)
        {
            if (_WOAR == null || _WOAR.Length == 0)
            {
                _WOAR = new UrlFrame[1];
                _WOAR[0] = frame;
            }
            else
            {
                UrlFrame[] temp = new UrlFrame[_WOAR.Length];
                for (int i = 0; i < _WOAR.Length; i++) { temp[i] = _WCOM[i]; }
                _WOAR = new UrlFrame[temp.Length + 1];
                for (int i = 0; i < temp.Length; i++) { _WOAR[i] = temp[i]; }
                _WOAR[_WOAR.Length - 1] = frame;
            } 
        }
        #endregion       
    
        internal void AddWXXX(UserDefinedUrlFrame frame)
        {
            if (_WXXX == null || _WXXX.Length == 0)
            {
                _WXXX = new UserDefinedUrlFrame[1];
                _WXXX[0] = frame;
            }
            else
            {
                UserDefinedUrlFrame[] temp = new UserDefinedUrlFrame[_WXXX.Length];
                for (int i = 0; i < _WXXX.Length; i++) { temp[i] = _WXXX[i]; }
                _WXXX = new UserDefinedUrlFrame[temp.Length + 1];
                for (int i = 0; i < temp.Length; i++) { _WXXX[i] = temp[i]; }
                _WXXX[_WXXX.Length - 1] = frame;
            }
        }
    }
}
