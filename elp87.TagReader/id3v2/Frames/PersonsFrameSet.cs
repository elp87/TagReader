namespace elp87.TagReader.id3v2.Frames
{
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
        public PersonsFrameSet()
        { 
        }
        #endregion

        #region Properties
        public TextInfoFrame        TPE1 { get { return _TPE1; } set { _TPE1 = value; } }
        public TextInfoFrame        TPE2 { get { return _TPE2; } set { _TPE2 = value; } }
        public TextInfoFrame        TPE3 { get { return _TPE3; } set { _TPE3 = value; } }
        public TextInfoFrame        TPE4 { get { return _TPE4; } set { _TPE4 = value; } }
        public TextInfoFrame        TOPE { get { return _TOPE; } set { _TOPE = value; } }
        public TextInfoFrame        TEXT { get { return _TEXT; } set { _TEXT = value; } }
        public TextInfoFrame        TOLY { get { return _TOLY; } set { _TOLY = value; } }
        public TextInfoFrame        TCOM { get { return _TCOM; } set { _TCOM = value; } }
        public PersonListTextFrame  TMCL { get { return _TMCL; } set { _TMCL = value; } }
        public PersonListTextFrame  TIPL { get { return _TIPL; } set { _TIPL = value; } }
        public TextInfoFrame        TENC { get { return _TENC; } set { _TENC = value; } }
        
        #endregion
    }
}
