namespace elp87.TagReader.id3v2.Frames
{
    /// <summary>
    /// This class contains set of all "Derived and subjective properties" text info frames
    /// </summary>
    /// <remarks>For details read "ID3 tag version 2.4.0 - Native Frames" section 4.2.3.</remarks>
    public class DeliveredFrameSet
    {
        #region Fields
        private NumericStringFrame _TBPM;
        private NumericStringFrame _TLEN;
        private TextInfoFrame _TKEY;
        private TextInfoFrame _TLAN;
        private ContentTypeFrame _TCON;
        private TextInfoFrame _TFLT;
        private TextInfoFrame _TMED;
        private TextInfoFrame _TMOO;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.DeliveredFrameSet"/>
        /// </summary>
        public DeliveredFrameSet()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets BPM
        /// </summary>
        public NumericStringFrame TBPM { get { return this._TBPM; } set { this._TBPM = value; } }

        /// <summary>
        /// Gets or sets Length
        /// </summary>
        public NumericStringFrame TLEN { get { return this._TLEN; } set { this._TLEN = value; } }

        /// <summary>
        /// Gets or sets Initial key
        /// </summary>
        public TextInfoFrame      TKEY { get { return this._TKEY; } set { this._TKEY = value; } }

        /// <summary>
        /// Gets or sets Language
        /// </summary>
        public TextInfoFrame      TLAN { get { return this._TLAN; } set { this._TLAN = value; } }

        /// <summary>
        /// Gets or sets Content type
        /// </summary>
        public ContentTypeFrame   TCON { get { return this._TCON; } set { this._TCON = value; } }

        /// <summary>
        /// Gets or sets File type
        /// </summary>
        public TextInfoFrame      TFLT { get { return this._TFLT; } set { this._TFLT = value; } }

        /// <summary>
        /// Gets or sets Media type
        /// </summary>
        public TextInfoFrame      TMED { get { return this._TMED; } set { this._TMED = value; } }

        /// <summary>
        /// Gets or sets Mood
        /// </summary>
        public TextInfoFrame      TMOO { get { return this._TMOO; } set { this._TMOO = value; } }
        #endregion
    }
}
