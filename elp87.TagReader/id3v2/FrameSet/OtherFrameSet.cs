namespace elp87.TagReader.id3v2.Frames
{
    /// <summary>
    /// This class contains set of all Other text info frames
    /// </summary>
    /// <remarks>For details read "ID3 tag version 2.4.0 - Native Frames" section 4.2.5.</remarks>
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
        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.OtherFrameSet"/>
        /// </summary>
        public OtherFrameSet()
        { }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets Original filename
        /// </summary>
        public TextInfoFrame          TOFN { get { return this._TOFN; } set { this._TOFN = value; } }

        /// <summary>
        /// Gets or sets Playlist delay
        /// </summary>
        public NumericStringFrame     TDLY { get { return this._TDLY; } set { this._TDLY = value; } }

        /// <summary>
        /// Gets or sets Encoding time
        /// </summary>
        public DateInfoFrame          TDEN { get { return this._TDEN; } set { this._TDEN = value; } }

        /// <summary>
        /// Gets or sets Original release time
        /// </summary>
        public DateInfoFrame          TDOR { get { return this._TDOR; } set { this._TDOR = value; } }

        /// <summary>
        /// Gets or sets Recording time
        /// </summary>
        public DateInfoFrame          TDRC { get { return this._TDRC; } set { this._TDRC = value; } }

        /// <summary>
        /// Gets or sets Release time
        /// </summary>
        public DateInfoFrame          TDRL { get { return this._TDRL; } set { this._TDRL = value; } }

        /// <summary>
        /// Gets or sets Tagging time
        /// </summary>
        public DateInfoFrame          TDTG { get { return this._TDTG; } set { this._TDTG = value; } }

        /// <summary>
        /// Gets or sets Software/Hardware and settings used for encoding
        /// </summary>
        public TextInfoFrame          TSSE { get { return this._TSSE; } set { this._TSSE = value; } }

        /// <summary>
        /// Gets or sets Album sort order
        /// </summary>
        public TextInfoFrame          TSOA { get { return this._TSOA; } set { this._TSOA = value; } }

        /// <summary>
        /// Gets or sets Performer sort order
        /// </summary>
        public TextInfoFrame          TSOP { get { return this._TSOP; } set { this._TSOP = value; } }

        /// <summary>
        /// Gets or sets Title sort order
        /// </summary>
        public TextInfoFrame          TSOT { get { return this._TSOT; } set { this._TSOT = value; } }

        /// <summary>
        /// Gets or sets User defined text frames
        /// </summary>
        public UserDefinedTextFrame[] TXXX { get { return this._TXXX; } set { this._TXXX = value; } }
        #endregion

        #region Methods
        internal void AddTXXX(UserDefinedTextFrame frame)
        {
            if ( _TXXX == null || _TXXX.Length == 0 )
            {
                _TXXX = new UserDefinedTextFrame[] { frame };
            }
            else
            {
                _TXXX = Generic.Add(_TXXX, frame);
            }
        } 
        #endregion
    }
}
