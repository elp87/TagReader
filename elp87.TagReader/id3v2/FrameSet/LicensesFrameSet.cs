namespace elp87.TagReader.id3v2.Frames
{
    /// <summary>
    /// This class contains set of all "Rights and license" text info frames
    /// </summary>
    /// <remarks>For details read "ID3 tag version 2.4.0 - Native Frames" section 4.2.4.</remarks>
    public class LicensesFrameSet
    {
        #region Fields
        private TextInfoFrame _TCOP;
        private TextInfoFrame _TPRO;
        private TextInfoFrame _TPUB;
        private TextInfoFrame _TOWN;
        private TextInfoFrame _TRSN;
        private TextInfoFrame _TRSO;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.LicensesFrameSet"/>
        /// </summary>
        public LicensesFrameSet()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets Copyright message
        /// </summary>
        public TextInfoFrame TCOP { get { return this._TCOP; } set { this._TCOP = value; } }

        /// <summary>
        /// Gets or sets Produced notice
        /// </summary>
        public TextInfoFrame TPRO { get { return this._TPRO; } set { this._TPRO = value; } }

        /// <summary>
        /// Gets or sets Publisher
        /// </summary>
        public TextInfoFrame TPUB { get { return this._TPUB; } set { this._TPUB = value; } }

        /// <summary>
        /// Gets or sets File owner/licensee
        /// </summary>
        public TextInfoFrame TOWN { get { return this._TOWN; } set { this._TOWN = value; } }

        /// <summary>
        /// Gets or sets Internet radio station name
        /// </summary>
        public TextInfoFrame TRSN { get { return this._TRSN; } set { this._TRSN = value; } }

        /// <summary>
        /// Gets or sets Internet radio station owner
        /// </summary>
        public TextInfoFrame TRSO { get { return this._TRSO; } set { this._TRSO = value; } }
        #endregion
    }
}
