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
            private byte[] _byteArray;
            private int _pointPosition;


            private string _album;
            private string _performer;
            private string _title;
            private string _trackNumber;
            private string _year;
            private Ufid _UFID;
            #endregion

            #region Constructors
            private ID3V2()
            {
                _UFID = new Ufid();
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

            public Frame frame { get; set; }

            #region TagProperties
            public string album { get { return _album; } set { _album = value; } }
            public string performer { get { return _performer; } set { _performer = value; } }
            public string title { get { return _title; } set { _title = value; } }
            public string trackPosition { get { return _trackNumber; } set { _trackNumber = value; } }
            public int trackNumber { get { return getTrackNumber(_trackNumber); } set { _trackNumber = value.ToString(); } }            
            public string year { get { return _year; } set { _year = value; } }
            public Ufid UFID { get { return _UFID; } set { _UFID = value; } }
            #endregion
            #endregion

            #region Methods
            #region Public
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
                while (this._header.tagSize > _pointPosition)
                {
                    frame = new Frame();
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
            
            #region Getters and Setters
            private int getTrackNumber(string value)
            {
                if (value == "") return -1;
                int slashPos = value.IndexOf('/');
                int dotPos = value.IndexOf('.');
                if ((slashPos == -1) && (dotPos == -1))
                {
                    return Convert.ToInt32(value);
                }
                else
                {
                    if (slashPos != -1) return Convert.ToInt32(value.Substring(0, slashPos));
                    if (dotPos != -1) return Convert.ToInt32(value.Substring(dotPos + 1));
                }
                throw new Exceptions.FrameTRCKException("Cant parse frame value", "Frame value - " + value, DateTime.Now);
            }
            #endregion
            #endregion


            #region Static

            #endregion
            #endregion

        }
    }
}
