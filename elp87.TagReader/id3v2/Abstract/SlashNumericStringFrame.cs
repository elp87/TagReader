using System;

namespace elp87.TagReader.id3v2.Abstract
{
    /// <summary>
    /// This abstract base class provides general functionality for numeric text frames that contains "slash" character
    /// </summary>
    public abstract class SlashNumericStringFrame
        : TextFrame
    {
        #region Fields
        /// <summary>
        /// String value of frame.
        /// </summary>
        
        protected string _numericString;
        /// <summary>
        /// Main number value.
        /// </summary>
        protected int _number;

        /// <summary>
        /// Total number.
        /// </summary>
        protected int _totalNumber;
        #endregion

        #region Constuctors
        /// <summary>
        /// Inheritable constructor for <see cref="elp87.TagReader.id3v2.Abstract.SlashNumericStringFrame"/> class
        /// </summary>
        public SlashNumericStringFrame()
            : base()
        { }

        /// <summary>
        /// Main inheritable constructor for <see cref="elp87.TagReader.id3v2.Abstract.SlashNumericStringFrame"/> class.
        /// </summary>
        /// <param name="flags">Flag fields of current frame.</param>
        /// <param name="frameData">Byte array that contains frame data excluding frame header and header extra data.</param>
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
        /// <summary>
        /// Gets string value of frame.
        /// </summary>
        public string NumericString { get { return this._numericString; } }

        /// <summary>
        /// Gets main number value.
        /// </summary>
        public int Number           { get { return this._number; } }

        /// <summary>
        /// Gets total number.
        /// </summary>
        public int TotalNumber      { get { return this._totalNumber; } }
        #endregion

        #region Methods
        #region Public
        /// <summary>
        /// Returns string value of frame.
        /// </summary>
        /// <returns>String value of frame.</returns>
        public override string ToString()
        {
            return this._numericString;
        }
        #endregion

        #region Protected
        /// <summary>
        /// Parse frame numeric string to compliant fields
        /// </summary>
        /// <param name="numericString">Numeric string</param>
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
