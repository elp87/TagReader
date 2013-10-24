using System;

namespace elp87.TagReader.id3v2
{
    /// <summary>
    /// This class provides reading information from id3v2 tag header.
    /// </summary>
    public class Header
    {
        #region Contants
        private const int _headerLenght = 10;
        #endregion

        #region Fields
        private byte[] _header;
        private int _tagVersion;
        private int _tagRevVersion;
        private byte _flagByte;
        private int _tagSize;
        private FlagField _flagField;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="elp87.TagReader.id3v2.Header"/> class.
        /// </summary>
        public Header() { }

        private Header(byte[] file, int headerPosition)
        {
            _header = new byte[_headerLenght];
            Array.Copy(file, headerPosition, _header, 0, _headerLenght);
            this.ParseHeader();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets header byte array.
        /// </summary>
        public byte[] HeaderArray { get { return _header; } }

        /// <summary>
        /// Gets id3v2 tag version.
        /// </summary>
        /// <remarks>
        /// It means minor version, i.e. <c>TagVersion</c> property will be equal 4 for id3v2.4 tag version.
        /// </remarks>
        public int TagVersion { get { return _tagVersion; } }

        /// <summary>
        /// Gets revision number of id3v2 tag version.
        /// </summary>
        /// <remarks>
        /// Usually it is equal 0.
        /// </remarks>
        public int TagRevision { get { return _tagRevVersion; } }

        /// <summary>
        /// Gets tag header flag fiels
        /// </summary>
        public FlagField FlagFields { get { return _flagField; } }

        /// <summary>
        /// Gets id3v2 tag size including extended header,padding, all frames, but excluding header and footer
        /// </summary>
        public int TagSize { get { return _tagSize; } }
        #endregion

        #region Methods
        #region Internal
        internal void ReadHeader(byte[] file, int headerPosition)
        {
            _header = new byte[_headerLenght];
            Array.Copy(file, headerPosition, _header, 0, _headerLenght);
            this.ParseHeader();
        }
        #endregion

        #region Private
        private void ParseHeader()
        {
            _tagVersion = Convert.ToInt32(_header[3]);
            if (_tagVersion > 4 || _tagVersion < 3) throw new Exceptions.UnsupportedTagVersionException("Unsupported Tag Version", "Tag version is " + _tagVersion, DateTime.Now);
            _tagRevVersion = Convert.ToInt32(_header[4]);
            _flagByte = _header[5];
            _flagField = new FlagField(_flagByte);
            SynchsafeInteger ssTagSize = new SynchsafeInteger(new byte[4] { _header[6], _header[7], _header[8], _header[9] });
            _tagSize = ssTagSize.ToInt();
        }
        #endregion
        #endregion

        #region Classes
        /// <summary>
        /// This class provides information about tag header flags
        /// </summary>
        public class FlagField
        {
            private bool _unsync;
            private bool _extendedHeader;
            private bool _experimental;
            private bool _footer;

            /// <summary>
            /// Initializes a new instance of the <see cref="elp87.TagReader.id3v2.Header.FlagField"/> class and read info from flag byte
            /// </summary>
            /// <param name="flagByte">Flag byte</param>
            public FlagField(byte flagByte)
            {
                _unsync = Convert.ToBoolean((flagByte & 0x80) >> 7);
                _extendedHeader = Convert.ToBoolean((flagByte & 0x40) >> 6);
                _experimental = Convert.ToBoolean((flagByte & 0x20) >> 5);
                _footer = Convert.ToBoolean((flagByte & 0x10) >> 4);
                if ((flagByte & 0x0F) != 0) throw new Exceptions.NotUsableFlagException("Invalid flag field. Undefined flags are set", Convert.ToString(flagByte, 2), DateTime.Now);
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="elp87.TagReader.id3v2.Header.FlagField"/> class
            /// </summary>
            /// <param name="unsynchronisation">Value of "Unsynchronisation" flag</param>
            /// <param name="extendedHeader">Value of "Extended header" flag</param>
            /// <param name="experimentalIndicator">Value of "Experimental indicator" flag</param>
            /// <param name="footer">Value of "Footer present" flag</param>
            public FlagField(bool unsynchronisation, bool extendedHeader, bool experimentalIndicator, bool footer)
            {
                _unsync = unsynchronisation;
                _extendedHeader = extendedHeader;
                _experimental = experimentalIndicator;
                _footer = footer;
            }

            /// <summary>
            /// Gets value of "Unsynchronisation" flag.
            /// </summary>
            /// <remarks>This property indicates whether or not unsynchronisation is applied on all frames. "True" indicates usage.</remarks>
            /// <seealso cref="elp87.TagReader.id3v2.Header.FlagField.ExtendedHeader"/>
            /// <seealso cref="elp87.TagReader.id3v2.Header.FlagField.ExperimentalIndicator"/>
            /// <seealso cref="elp87.TagReader.id3v2.Header.FlagField.Footer"/>
            public bool Unsunc { get { return _unsync; } }

            /// <summary>
            /// Gets value of "Extended header" flag.
            /// </summary>
            /// <remarks>This property indicates whether or not the header is followed by an extended header. 
            /// "True" indicates the presence of an extended header.</remarks>
            /// <seealso cref="elp87.TagReader.id3v2.Header.FlagField.Unsunc"/>
            /// <seealso cref="elp87.TagReader.id3v2.Header.FlagField.ExperimentalIndicator"/>
            /// <seealso cref="elp87.TagReader.id3v2.Header.FlagField.Footer"/>
            public bool ExtendedHeader { get { return _extendedHeader; } }

            /// <summary>
            /// Gets value of "Experimental indicator" flag.
            /// </summary>
            /// <remarks>This property is used as an 'experimental indicator'.
            /// This flag SHALL always be set when the tag is in an experimental stage.</remarks>
            /// <seealso cref="elp87.TagReader.id3v2.Header.FlagField.Unsunc"/>
            /// <seealso cref="elp87.TagReader.id3v2.Header.FlagField.ExtendedHeader"/>
            /// <seealso cref="elp87.TagReader.id3v2.Header.FlagField.Footer"/>
            public bool ExperimentalIndicator { get { return _experimental; } }

            /// <summary>
            /// Gets value of "Footer present" flag.
            /// </summary>
            /// <remarks>This property indicates that a footer is present at the very end of the tag. 
            /// "True" indicates the presence of a footer.</remarks>
            /// <seealso cref="elp87.TagReader.id3v2.Header.FlagField.Unsunc"/>
            /// <seealso cref="elp87.TagReader.id3v2.Header.FlagField.ExtendedHeader"/>
            /// <seealso cref="elp87.TagReader.id3v2.Header.FlagField.ExperimentalIndicator"/>
            public bool Footer { get { return _footer; } }
        }
        #endregion
    }
}
