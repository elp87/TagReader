using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elp87.TagReader.id3v2
{
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
        public Header() { }

        private Header(byte[] file, int headerPosition)
        {
            _header = new byte[_headerLenght];
            Array.Copy(file, headerPosition, _header, 0, _headerLenght);
            this.ParseHeader();
        }
        #endregion

        #region Properties
        public byte[] header { get { return _header; } }

        public int tagVersion { get { return _tagVersion; } }

        public int tagRevision { get { return _tagRevVersion; } }

        public FlagField flagField { get { return _flagField; } }

        public int tagSize { get { return _tagSize; } }
        #endregion

        #region Methods
        #region Public
        public void ReadHeader(byte[] file, int headerPosition)
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
        public class FlagField
        {
            private bool _unsync;
            private bool _extendedHeader;
            private bool _experimental;
            private bool _footer;

            public FlagField(byte flagByte)
            {
                _unsync = Convert.ToBoolean((flagByte & 0x80) >> 7);
                _extendedHeader = Convert.ToBoolean((flagByte & 0x40) >> 6);
                _experimental = Convert.ToBoolean((flagByte & 0x20) >> 5);
                _footer = Convert.ToBoolean((flagByte & 0x10) >> 4);
                if ((flagByte & 0x0F) != 0) throw new Exceptions.NotUsableFlagException("Invalid flag field. Undefined flags are set", Convert.ToString(flagByte, 2), DateTime.Now);
            }

            public FlagField(bool unsynchronisation, bool extendedHeader, bool experimentalIndicator, bool footer)
            {
                _unsync = unsynchronisation;
                _extendedHeader = extendedHeader;
                _experimental = experimentalIndicator;
                _footer = footer;
            }

            public bool unsunc { get { return _unsync; } }
            public bool extendedHeader { get { return _extendedHeader; } }
            public bool experimentalIndicator { get { return _experimental; } }
            public bool footer { get { return _footer; } }
        }
        #endregion
    }
}
