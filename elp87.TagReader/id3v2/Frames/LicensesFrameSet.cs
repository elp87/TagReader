namespace elp87.TagReader.id3v2.Frames
{
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
        public LicensesFrameSet()
        {
        }
        #endregion

        #region Properties
        public TextInfoFrame TCOP { get { return this._TCOP; } set { this._TCOP = value; } }
        public TextInfoFrame TPRO { get { return this._TPRO; } set { this._TPRO = value; } }
        public TextInfoFrame TPUB { get { return this._TPUB; } set { this._TPUB = value; } }
        public TextInfoFrame TOWN { get { return this._TOWN; } set { this._TOWN = value; } }
        public TextInfoFrame TRSN { get { return this._TRSN; } set { this._TRSN = value; } }
        public TextInfoFrame TRSO { get { return this._TRSO; } set { this._TRSO = value; } }
        #endregion
    }
}
