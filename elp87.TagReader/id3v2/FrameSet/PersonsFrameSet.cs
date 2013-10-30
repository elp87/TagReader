namespace elp87.TagReader.id3v2.Frames
{
    /// <summary>
    /// This class contains set of all "involved persons" text info frames
    /// </summary>
    /// <remarks>For details read "ID3 tag version 2.4.0 - Native Frames" section 4.2.2.</remarks>
    public class PersonsFrameSet
    {
        #region Fields
        private TextInfoFrame _TPE1;
        private TextInfoFrame _TPE2;
        private TextInfoFrame _TPE3;
        private TextInfoFrame _TPE4;
        private TextInfoFrame _TOPE;
        private TextInfoFrame _TEXT;
        private TextInfoFrame _TOLY;
        private TextInfoFrame _TCOM;
        private PersonListTextFrame _TMCL;
        private PersonListTextFrame _TIPL;
        private TextInfoFrame _TENC;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.PersonsFrameSet"/>
        /// </summary>
        public PersonsFrameSet()
        { 
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets Lead artist/Lead performer/Soloist/Performing group
        /// </summary>
        public TextInfoFrame        TPE1 { get { return _TPE1; } set { _TPE1 = value; } }

        /// <summary>
        /// Gets or sets Band/Orchestra/Accompaniment
        /// </summary>
        public TextInfoFrame        TPE2 { get { return _TPE2; } set { _TPE2 = value; } }

        /// <summary>
        /// Gets or sets Conductor
        /// </summary>
        public TextInfoFrame        TPE3 { get { return _TPE3; } set { _TPE3 = value; } }

        /// <summary>
        /// Gets or sets "Interpreted, remixed, or otherwise modified by"
        /// </summary>
        public TextInfoFrame        TPE4 { get { return _TPE4; } set { _TPE4 = value; } }

        /// <summary>
        /// Gets or sets Original artist/performer
        /// </summary>
        public TextInfoFrame        TOPE { get { return _TOPE; } set { _TOPE = value; } }

        /// <summary>
        /// Gets or sets Lyricist/Text writer
        /// </summary>
        public TextInfoFrame        TEXT { get { return _TEXT; } set { _TEXT = value; } }

        /// <summary>
        /// Gets or sets Original lyricist/text writer
        /// </summary>
        public TextInfoFrame        TOLY { get { return _TOLY; } set { _TOLY = value; } }

        /// <summary>
        /// Gets or sets Composer
        /// </summary>
        public TextInfoFrame        TCOM { get { return _TCOM; } set { _TCOM = value; } }

        /// <summary>
        /// Gets or sets Musician credits list
        /// </summary>
        public PersonListTextFrame  TMCL { get { return _TMCL; } set { _TMCL = value; } }

        /// <summary>
        /// Gets or sets Involved people list
        /// </summary>
        public PersonListTextFrame  TIPL { get { return _TIPL; } set { _TIPL = value; } }

        /// <summary>
        /// Gets or sets "Encoded by"
        /// </summary>
        public TextInfoFrame        TENC { get { return _TENC; } set { _TENC = value; } }
        
        #endregion
    }
}
