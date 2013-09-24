using elp87.TagReader.id3v2.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace elp87.TagReader.id3v2.Frames
{
    public class NumericStringFrame
        : Frame
    {
        #region Fields
        private string _stringNumber;
        private int _number;
        #endregion

        #region Constructors
        public NumericStringFrame() { }

        public NumericStringFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        {
            this.ParseNumericString(frameData);
        }
        #endregion

        #region Properties
        public string stringNumber { get { return this._stringNumber; } }

        public int number { get { return this._number; } }
        #endregion

        #region Methods
        #region Public
        public override string ToString()
        {
            return _number.ToString();
        }
        #endregion

        #region Private
        private void ParseNumericString(byte[] frameData)
        {
            string val = Encoding.ASCII.GetString(frameData);
            while (val[val.Length - 1] == '\0')
            {
                val = val.Substring(0, val.Length - 1);
            }
            this._stringNumber = val;
            try
            {
                this._number = Convert.ToInt32(this._stringNumber);
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
