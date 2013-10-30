using elp87.TagReader.id3v2.Abstract;

namespace elp87.TagReader.id3v2.Frames
{
    /// <summary>
    /// Provides functionality for most of text information frames.
    /// </summary>
    /// <remarks>For details read "ID3 tag version 2.4.0 - Native Frames" section 4.2.</remarks>
    public class TextInfoFrame
        : TextFrame
    {
        #region Fields
        /// <summary>
        /// Array of values
        /// </summary>
        protected string[] _values;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.TextInfoFrame"/> that is empty.
        /// </summary>
        protected TextInfoFrame()
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.TextInfoFrame"/> and read frame data
        /// </summary>
        /// <param name="flags">Flag fields of current frame.</param>
        /// <param name="frameData">Byte array that contains frame data excluding frame header and header extra data.</param>
        public TextInfoFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        {
            this.ParseData(_frameData);
        }
        #endregion

        #region Methods
        #region Public
        /// <summary>
        /// Returns first value of current instance
        /// </summary>
        /// <returns>First value if current instance</returns>
        public override string ToString()
        {
            return _values[0];
        }

        /// <summary>
        /// Returns array of all values
        /// </summary>
        /// <returns>Array of all values</returns>
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
        /// <summary>
        /// Gets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>The element of frame.</returns>
        public string this[int index] { get { return _values[index]; } }
        #endregion
    }
}
