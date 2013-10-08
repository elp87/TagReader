namespace elp87.TagReader.id3v2.Frames
{
    public class DeliveredFrameSet
    {
        #region Fields
        private NumericStringFrame _TBPM;
        private NumericStringFrame _TLEN;
        private TextInfoFrame _TKEY;
        private ContentTypeFrame _TCON;
        private TextInfoFrame _TFLT;
        private TextInfoFrame _TMED;
        private TextInfoFrame _TMOO;
        #endregion

        #region Constructors
        public DeliveredFrameSet()
        {
        }
        #endregion

        #region Fields
        public NumericStringFrame TBPM { get { return this._TBPM; } set { this._TBPM = value; } }
        public NumericStringFrame TLEN { get { return this._TLEN; } set { this._TLEN = value; } }
        public TextInfoFrame      TKEY { get { return this._TKEY; } set { this._TKEY = value; } }
        public ContentTypeFrame   TCON { get { return this._TCON; } set { this._TCON = value; } }
        public TextInfoFrame TFLT { get { return this._TFLT; } set { this._TFLT = value; } }
        public TextInfoFrame TMED { get { return this._TMED; } set { this._TMED = value; } }
        public TextInfoFrame TMOO { get { return this._TMOO; } set { this._TMOO = value; } }
        #endregion
    }
}
