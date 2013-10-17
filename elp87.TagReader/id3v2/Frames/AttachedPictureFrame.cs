using elp87.TagReader.id3v2.Abstract;
using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace elp87.TagReader.id3v2.Frames
{
    public class AttachedPictureFrame
        : TextFrame
    {
        #region Fields
        private string _mimeType;
        private byte _picType;
        private string _description;
        private byte[] _picData;
        #endregion

        #region Constructors
        protected AttachedPictureFrame()
            : base()
        { }

        public AttachedPictureFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        {
            int mimeTerminatorPos = Array.IndexOf(this._frameData, ByteArray.Terminator);
            this._mimeType = this.ReadMimeType(mimeTerminatorPos);
            this._picType = this._frameData[mimeTerminatorPos + 1];

            int descTerminatorPos = this.ReadDescTerminatorPos(mimeTerminatorPos);
            this._description = this.ReadDescription(mimeTerminatorPos, descTerminatorPos);

            this.ReadPictureData(descTerminatorPos);
        }             
        #endregion

        #region Properies
        public string       MimeType    { get { return this._mimeType; } }
        public string       Description { get { return this._description; } }
        public PictureTypes PictureType { get { return (PictureTypes)this._picType; } }
        #endregion

        #region Methods
        #region Public
        public byte[] GetPictureData()
        {
            return (byte[])this._picData.Clone();
        }

        public Image GetPicture()
        {
            Image image = Image.FromStream(new MemoryStream(this._picData));
            return image;
        }
        #endregion

        #region Private
        private string ReadMimeType(int mimeTerminatorPos)
        {
            byte[] mimeArray = new byte[mimeTerminatorPos];
            Array.Copy(this._frameData, mimeArray, mimeTerminatorPos);
            string mime = Encoding.ASCII.GetString(mimeArray);
            return mime;
        }

        private int ReadDescTerminatorPos(int mimeTerminatorPos)
        {
            int arrayLength = this._frameData.Length - mimeTerminatorPos - 2;
            byte[] tempArray = new byte[arrayLength];
            Array.Copy(this._frameData, mimeTerminatorPos + 2, tempArray, 0, arrayLength);
            int termPosition = this.ParseTerminatorPos(tempArray) + mimeTerminatorPos + 2;
            return termPosition;
        }

        private int ParseTerminatorPos(byte[] frameData)
        {
            int position;

            if (this._encoding == TextEncoding.UTF16 || this._encoding == TextEncoding.UTF16_BE)
            {
                byte[] termByteArray = new byte[] { 0x00, 0x00 };
                position = ByteArray.FindSubArray(frameData, termByteArray);
            }
            else
            {
                byte termByte = 0x00;
                position = Array.IndexOf(frameData, termByte);
            }

            while (frameData[position + 1] == 0x00) { position++; }
            return position;
        }

        private void ReadPictureData(int descTerminatorPos)
        {
            this._picData = new byte[this._frameData.Length - descTerminatorPos - 1];
            Array.Copy(this._frameData, descTerminatorPos + 1, this._picData, 0, this._picData.Length);
        }

        private string ReadDescription(int mimeTerminatorPos, int descTerminatorPos)
        {
            byte[] descArray = new byte[descTerminatorPos - mimeTerminatorPos - 2];
            Array.Copy(this._frameData, mimeTerminatorPos + 2, descArray, 0, descArray.Length);
            return this.GetString(descArray);
        }
        #endregion
        #endregion

        #region Enums
        public enum PictureTypes : byte
        {
            Other              = 0x00,
            FileIcon32PNG      = 0x01,
            OtherFileIcon      = 0x02,
            CoverFront         = 0x03,
            CoverBack          = 0x04,
            LeafletPage        = 0x05,
            Media              = 0x06,
            LeadArtist         = 0x07,
            Artist             = 0x08,
            Conductor          = 0x09,
            Band               = 0x0A,
            Composer           = 0x0B,
            Lyricist           = 0x0C,
            RecordingLocation  = 0x0D,
            DuringRecording    = 0x0E,
            DuringPerformance  = 0x0F,
            ScreenCapture      = 0x10,
            BrightColouredFish = 0x11,
            Illustration       = 0x12,
            ArtistLogo         = 0x13,
            PublisherLogo      = 0x14
        }
        #endregion
    }
}
