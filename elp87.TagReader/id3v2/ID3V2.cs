using elp87.TagReader.id3v2.Frames;
using System;
using System.IO;

namespace elp87.TagReader
{
    namespace id3v2
    {
        /// <summary>
        /// This class provides reading id3v2 tags from mp3 files.
        /// </summary>
        public partial class ID3V2
        {
            #region Constants
            private readonly byte[] _ID3HeaderMask = { 0x49, 0x44, 0x33 };
            #endregion

            #region Fields
            private string filename;
            private int _fileSize;
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

            private UniqueFileIdentifierFrame[] _UFID;
            private MusicIdFrame _MCDI;
            private UnsunchTextFrame[] _USLT;
            private UnsunchTextFrame[] _COMM;
            private AttachedPictureFrame[] _APIC;
            private PrivateFrame[] _PRIV;
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

            /// <summary>
            /// Initializes a new instance of the <see cref="elp87.TagReader.id3v2.ID3V2"/> class and reads tags from file.
            /// </summary>
            /// <param name="filename">The file to open for reading.</param>
            public ID3V2(string filename)
                : this()
            {
                this._pointPosition = 0;
                this.filename = filename;
                this.ReadTag();
            }
            #endregion

            #region Properties
            /// <summary>
            /// Gets id3v2 header.
            /// </summary>
            public Header Header { get { return _header; } }

            /// <summary>
            /// Gets id3v2 extended header. If it is no extended header in tag, this property returns null
            /// </summary>
            public ExtHeader ExtHeader { get { return _extHeader; } }
            
            #region TagProperties
            /// <summary>
            /// Gets identification frames
            /// </summary>
            public IdentificationFrameSet      IdentificationFrames    { get { return _identificationFrames; } }
            
            /// <summary>
            /// Gets involved persons frames
            /// </summary>
            public PersonsFrameSet             PersonsFrames           { get { return _personsFrames; } }
            
            /// <summary>
            /// Gets derived and subjective properties frames
            /// </summary>
            public DeliveredFrameSet           DeliveredFrames         { get { return _deliveredFrames; } }
            
            /// <summary>
            /// Gets rights and license frames
            /// </summary>
            public LicensesFrameSet            LicensesFrames          { get { return _licensesFrames; } }
            
            /// <summary>
            /// Gets Other text frames and User defined text information frames
            /// </summary>
            public OtherFrameSet               OtherFrames             { get { return _otherFrames; } }
            
            /// <summary>
            /// Gets URL link frames
            /// </summary>
            public UrlFrameSet                 UrlFrames               { get { return _urlFrames; } }

            /// <summary>
            /// Gets unique file identifier frames
            /// </summary>
            public UniqueFileIdentifierFrame[] UFID                    { get { return _UFID; } }
            
            /// <summary>
            /// Gets Music CD identifier frames
            /// </summary>
            public MusicIdFrame                MCDI                    { get { return _MCDI; } }

            /// <summary>
            /// Gets unsynchronised lyrics/text transcription frames
            /// </summary>
            public UnsunchTextFrame[]          USLT                    { get { return _USLT; } }
            
            /// <summary>
            /// Gets comment frames
            /// </summary>
            public UnsunchTextFrame[]          COMM                    { get { return _COMM; } }
            
            /// <summary>
            /// Gets attached picture frames
            /// </summary>
            public AttachedPictureFrame[]      APIC                    { get { return _APIC; } }
            
            /// <summary>
            /// Gets private frames
            /// </summary>
            public PrivateFrame[]              PRIV                    { get { return _PRIV; } }
            #endregion
            #endregion

            #region Methods
            /// <summary>
            /// Returns byte array of id3v2 tag.
            /// </summary>
            /// <returns>Byte array of id3v2 tag.</returns>
            /// <exception cref="System.NullReferenceException">The tag is empty</exception>
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

            #region Internal
            internal int GetFileSize()
            {
                return this._fileSize;
            }
            #endregion

            #region Private
            private void ReadTag()
            {
                byte[] file = this.LoadFile();
                _fileSize = file.Length;
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
