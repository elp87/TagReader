namespace elp87.TagReader.id3v2.Frames
{
    /// <summary>
    /// This class contains set of all URL link frames
    /// </summary>
    /// <remarks>For details read "ID3 tag version 2.4.0 - Native Frames" section 4.3.</remarks>
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
        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.UrlFrameSet"/>
        /// </summary>
        public UrlFrameSet()
        { }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets Commercial information
        /// </summary>
        public UrlFrame[]            WCOM { get { return this._WCOM; } set { this._WCOM = value; } }

        /// <summary>
        /// Gets or sets Copyright/Legal information
        /// </summary>
        public UrlFrame              WCOP { get { return this._WCOP; } set { this._WCOP = value; } }

        /// <summary>
        /// Gets or sets Official audio file webpage
        /// </summary>
        public UrlFrame              WOAF { get { return this._WOAF; } set { this._WOAF = value; } }

        /// <summary>
        /// Gets or sets Official artist/performer webpage
        /// </summary>
        public UrlFrame[]            WOAR { get { return this._WOAR; } set { this._WOAR = value; } }

        /// <summary>
        /// Gets or sets Official audio source webpage
        /// </summary>
        public UrlFrame              WOAS { get { return this._WOAS; } set { this._WOAS = value; } }

        /// <summary>
        /// Gets or sets Official Official Internet radio station homepage
        /// </summary>
        public UrlFrame              WORS { get { return this._WORS; } set { this._WORS = value; } }

        /// <summary>
        /// Gets or sets Payment
        /// </summary>
        public UrlFrame              WPAY { get { return this._WPAY; } set { this._WPAY = value; } }

        /// <summary>
        /// Gets or sets Publishers official webpage
        /// </summary>
        public UrlFrame              WPUB { get { return this._WPUB; } set { this._WPUB = value; } }

        /// <summary>
        /// Gets or sets User defined URL link frames
        /// </summary>
        public UserDefinedUrlFrame[] WXXX { get { return this._WXXX; } set { this._WXXX = value; } }
        #endregion

        #region Methods
        internal void AddWCOM(UrlFrame frame)
        {
            if ( _WCOM == null || _WCOM.Length == 0 )
            {
                _WCOM = new UrlFrame[] { frame };
            }
            else
            {
                _WCOM = Generic.Add(_WCOM, frame);
            }         
        }

        internal void AddWOAR(UrlFrame frame)
        {
            if (_WOAR == null || _WOAR.Length == 0)
            {
                _WOAR = new UrlFrame[] { frame };
            }
            else
            {
                _WOAR = Generic.Add(_WOAR, frame);
            } 
        }

        internal void AddWXXX(UserDefinedUrlFrame frame)
        {
            if (_WXXX == null || _WXXX.Length == 0)
            {
                _WXXX = new UserDefinedUrlFrame[] { frame };
            }
            else
            {
                _WXXX = Generic.Add(_WXXX, frame);
            }
        }
        #endregion        
    }
}
