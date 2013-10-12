using elp87.TagReader.id3v2.Frames;
using System;
using System.IO;

namespace elp87.TagReader
{
    namespace id3v2
    {
        public partial class ID3V2
        {
            #region Constants
            private readonly byte[] _ID3HeaderMask = { 0x49, 0x44, 0x33 };
            #endregion

            #region Fields
            private string filename;
            private Header _header;
            private ExtHeader _extHeader;
            private byte[] _byteArray;
            private int _pointPosition;

            private IdentificationFrameSet _identificationFrames;
            private PersonsFrameSet _personsFrames;
            private DeliveredFrameSet _deliveredFrames;
            private LicensesFrameSet _licensesFrames;
            private OtherFrameSet _otherFrames;
            private UrlFrameSet _urlFrames;
            #endregion

            #region Constructors
            private ID3V2()
            {               
                _identificationFrames = new IdentificationFrameSet();
                _personsFrames = new PersonsFrameSet();
                _deliveredFrames = new DeliveredFrameSet();
                _licensesFrames = new LicensesFrameSet();
                _otherFrames = new OtherFrameSet();
                _urlFrames = new UrlFrameSet();
            }
            public ID3V2(string filename)
                : this()
            {
                this._pointPosition = 0;
                this.filename = filename;
                this.ReadTag();
            }
            #endregion

            #region Properties
            public Header Header { get { return _header; } }
            public ExtHeader ExtHeader { get { return _extHeader; } }
            
            #region TagProperties
            public IdentificationFrameSet   IdentificationFrames    { get { return _identificationFrames; } }
            public PersonsFrameSet          PersonsFrames           { get { return _personsFrames; } }
            public DeliveredFrameSet        DeliveredFrames         { get { return _deliveredFrames; } }
            public LicensesFrameSet         LicensesFrames          { get { return _licensesFrames; } }
            public OtherFrameSet            OtherFrames             { get { return _otherFrames; } }
            public UrlFrameSet              UrlFrames               { get { return _urlFrames; } }
            #endregion
            #endregion

            #region Methods
            #region Public
            public byte[] GetTagArray()
            {
                if (this._byteArray.Length > 0)
                {
                    return (byte[])this._byteArray.Clone();
                }
                else
                {
                    throw new NullReferenceException("The tag array is empty");
                }
            }
            #endregion

            #region Private
            private void ReadTag()
            {
                byte[] file = this.LoadFile();
                int headerPosition = this.FindHeader(file);
                if (headerPosition == -1) throw new Exceptions.NoID3V2TagException("No ID3v2 Tag in file", "Id3v2 tag is not found", DateTime.Now);
                _header = new Header();

                _header.ReadHeader(file, headerPosition);
                _byteArray = new byte[this.Header.TagSize + 10];
                this.GetTagByteArray(file, headerPosition);

                _pointPosition += 10;
                if (this._header.FlagFields.ExtendedHeader)
                {
                    this._extHeader = new ExtHeader();
                    _extHeader.ReadExtHeader(_byteArray, _pointPosition);
                    _pointPosition += this._extHeader.Size;
                }
                while (this._header.TagSize > _pointPosition)
                {
                    FrameReader frame = new FrameReader();
                    frame.ReadFrame(this, _byteArray, _pointPosition);
                    _pointPosition += frame.FrameSize + 10;
                }
            }

            private void GetTagByteArray(byte[] file, int headerPosition)
            {
                int tagSize = this._header.TagSize;
                Array.Copy(file, headerPosition, _byteArray, 0, tagSize + 10);
            }

            private byte[] LoadFile()
            {
                return File.ReadAllBytes(filename);
            }

            private int FindHeader(byte[] byteArray)
            {
                return ByteArray.FindSubArray(byteArray, _ID3HeaderMask);
            }
            #endregion
            #endregion

        }
    }
}
