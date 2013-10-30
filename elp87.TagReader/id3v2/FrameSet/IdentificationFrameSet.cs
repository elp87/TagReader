namespace elp87.TagReader.id3v2.Frames
{
    /// <summary>
    /// This class contains set of all identification text info frames
    /// </summary>
    /// <remarks>For details read "ID3 tag version 2.4.0 - Native Frames" section 4.2.1.</remarks>
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
        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.IdentificationFrameSet"/>
        /// </summary>
        public IdentificationFrameSet()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets Content group description
        /// </summary>
        public TextInfoFrame TIT1 { get { return _TIT1; } set { this._TIT1 = value; } }

        /// <summary>
        /// Gets or sets Title/Songname/Content description
        /// </summary>
        public TextInfoFrame TIT2 { get { return _TIT2; } set { this._TIT2 = value; } }

        /// <summary>
        /// Gets or sets Subtitle/Description refinement
        /// </summary>
        public TextInfoFrame TIT3 { get { return _TIT3; } set { this._TIT3 = value; } }

        /// <summary>
        /// Gets or sets Album/Movie/Show title
        /// </summary>
        public TextInfoFrame TALB { get { return _TALB; } set { this._TALB = value; } }

        /// <summary>
        /// Gets or sets Original album/movie/show title
        /// </summary>
        public TextInfoFrame TOAL { get { return _TOAL; } set { this._TOAL = value; } }

        /// <summary>
        /// Gets or sets Track number/Position in set
        /// </summary>
        public PositionFrame TRCK { get { return _TRCK; } set { this._TRCK = value; } }

        /// <summary>
        /// Gets or sets Part of a set
        /// </summary>
        public PositionFrame TPOS { get { return _TPOS; } set { this._TPOS = value; } }

        /// <summary>
        /// Gets or sets Set subtitle
        /// </summary>
        public TextInfoFrame TSST { get { return _TSST; } set { this._TSST = value; } }

        /// <summary>
        /// Gets or sets ISRC
        /// </summary>
        public TextInfoFrame TSRC { get { return _TSRC; } set { this._TSRC = value; } }
        #endregion
        
    }
}
