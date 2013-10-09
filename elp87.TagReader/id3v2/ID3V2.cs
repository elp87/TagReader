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
            #endregion

            #region Constructors
            private ID3V2()
            {               
                _identificationFrames = new IdentificationFrameSet();
                _personsFrames = new PersonsFrameSet();
                _deliveredFrames = new DeliveredFrameSet();
                _licensesFrames = new LicensesFrameSet();
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
            public Header header { get { return _header; } }
            public ExtHeader extHeader { get { return _extHeader; } }
            
            #region TagProperties
            public IdentificationFrameSet   identificationFrames    { get { return _identificationFrames; } }
            public PersonsFrameSet          personsFrames           { get { return _personsFrames; } }
            public DeliveredFrameSet        deliveredFrames         { get { return _deliveredFrames; } }
            public LicensesFrameSet         licensesFrames          { get { return _licensesFrames; } }
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
                _byteArray = new byte[this.header.tagSize + 10];
                this.GetTagByteArray(file, headerPosition);

                _pointPosition += 10;
                if (this._header.flagField.extendedHeader)
                {
                    this._extHeader = new ExtHeader();
                    _extHeader.ReadExtHeader(_byteArray, _pointPosition);
                    _pointPosition += this._extHeader.size;
                }
                while (this._header.tagSize > _pointPosition)
                {
                    FrameReader frame = new FrameReader();
                    frame.ReadFrame(this, _byteArray, _pointPosition);
                    _pointPosition += frame.frameSize + 10;
                }
            }

            private void GetTagByteArray(byte[] file, int headerPosition)
            {
                int tagSize = this._header.tagSize;
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
