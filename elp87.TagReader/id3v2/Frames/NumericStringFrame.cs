using elp87.TagReader.id3v2.Abstract;
using System;
using System.Text;

namespace elp87.TagReader.id3v2.Frames
{
    /// <summary>
    /// Provides functionality for text info frames with numbers.
    /// </summary>
    /// <remarks>This class allows to read TBPM, TLEN and TDLY frames. For details read "ID3 tag version 2.4.0 - Native Frames"</remarks>
    public class NumericStringFrame
        : TextFrame
    {
        #region Fields
        private string _numericString;
        private int _number;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.NumericStringFrame"/> that is empty.
        /// </summary>
        public NumericStringFrame() { }

        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.NumericStringFrame"/> and read frame data
        /// </summary>
        /// <param name="flags">Flag fields of current frame.</param>
        /// <param name="frameData">Byte array that contains frame data excluding frame header and header extra data.</param>
        public NumericStringFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        {
            this.ParseNumericString();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets frame value represented as string
        /// </summary>
        public string NumericString { get { return this._numericString; } }

        /// <summary>
        /// Gets frame value represented as number
        /// </summary>
        public int Number { get { return this._number; } }
        #endregion

        #region Methods
        #region Public
        public override string ToString()
        {
            return _number.ToString();
        }
        #endregion

        #region Private
        private void ParseNumericString()
        {
            string val = Encoding.ASCII.GetString(this._frameData);
            while (val[val.Length - 1] == '\0')
            {
                val = val.Substring(0, val.Length - 1);
            }
            this._numericString = val;
            try
            {
                this._number = Convert.ToInt32(this._numericString);
            }
            catch (FormatException ex)
            {
                throw new FormatException("Can't read numeric string", ex);
            }
        }
        #endregion
        #endregion
    }
}
