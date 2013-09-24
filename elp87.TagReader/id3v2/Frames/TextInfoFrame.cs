using elp87.TagReader.id3v2.Abstract;

namespace elp87.TagReader.id3v2.Frames
{
    public class TextInfoFrame
        : TextFrame
    {
        #region Fields
        private string[] _values;
        #endregion

        #region Constructors
        public TextInfoFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        {
            this.ParseData(_frameData);
        }
        #endregion

        #region Methods
        #region Public
        public override string ToString()
        {
            return _values[0];
        }

        public string[] GetValues()
        {
            return (string[])_values.Clone();
        }
        #endregion

        #region Private
        private void ParseData(byte[] _frameData)
        {
            string fullValue = this.GetString(_frameData);
            if (fullValue[fullValue.Length - 1] == '\0') { fullValue = fullValue.Substring(0, fullValue.Length - 1); }
            int count = TextInfoFrame.GetStringCount(fullValue);
            _values = new string[count];
            for (int i = 0; i < count; i++)
            {
                int newStrinPos = fullValue.IndexOf('\0');
                if (newStrinPos != -1)
                {
                    _values[i] = fullValue.Substring(0, newStrinPos);
                    fullValue = fullValue.Substring(newStrinPos + 1);
                }
                else
                {
                    _values[i] = fullValue;
                }
            }
        }
        #endregion
        #endregion

        #region Properties
        public string this[int index] { get { return _values[index]; } }
        #endregion
    }
}
