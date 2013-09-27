using System;

namespace elp87.TagReader.id3v2.Abstract
{
    public abstract class SlashNumericStringFrame
        : TextFrame
    {
        #region Fields
        protected string _numericString;
        protected int _number;
        protected int _totalNumber;
        #endregion

        #region Constuctors
        public SlashNumericStringFrame()
            : base()
        { }

        public SlashNumericStringFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        {
            this._number = -1;
            this._totalNumber = -1;
            this._numericString = this.GetString(this._frameData);
            this.ParseNumericString(this._numericString);
        }

        
        #endregion

        #region Properties
        public string numericString { get { return this._numericString; } }
        public int number           { get { return this._number; } }
        public int totalNumber      { get { return this._totalNumber; } }
        #endregion

        #region Methods
        #region Public
        public override string ToString()
        {
            return this._numericString;
        }
        #endregion
        #region Protected
        protected void ParseNumericString(string numericString)
        {
            if (numericString == "")
            {
                return;
            }
            int slashPos = numericString.IndexOf('/');
            int dotPos = numericString.IndexOf('.');
            if ((slashPos == -1) && (dotPos == -1))
            {
                this._number = Convert.ToInt32(numericString);
            }
            else
            {
                if (slashPos != -1)
                {
                    this._number = Convert.ToInt32(numericString.Substring(0, slashPos));
                    this._totalNumber = Convert.ToInt32(numericString.Substring(slashPos + 1));
                }
                if (dotPos != -1)
                {
                    this._number = Convert.ToInt32(numericString.Substring(dotPos + 1));
                }
            }
            
        }
        #endregion        
        #endregion
        
    }
}
