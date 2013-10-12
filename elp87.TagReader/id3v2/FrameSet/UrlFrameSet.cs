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
    }
}
