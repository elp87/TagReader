using elp87.TagReader.id3v2.Abstract;
using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace elp87.TagReader.id3v2.Frames
{
    /// <summary>
    /// Provides functionality for attached picture frames.
    /// </summary>
    /// <remarks>This class allows to read APIC frames. For details read "ID3 tag version 2.4.0 - Native Frames"</remarks>
    /// <seealso cref="elp87.TagReader.id3v2.ID3V2.APIC"/>
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
        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.AttachedPictureFrame"/> that is empty.
        /// </summary>
        protected AttachedPictureFrame()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.AttachedPictureFrame"/> and read frame data
        /// </summary>
        /// <param name="flags">Flag fields of current frame.</param>
        /// <param name="frameData">Byte array that contains frame data excluding frame header and header extra data.</param>
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
        /// <summary>
        /// Gets MIME type and subtype for the image.
        /// </summary>
        /// <remarks>Usually this property is equal <c>image/jpeg</c>.</remarks>
        public string       MimeType    { get { return this._mimeType; } }

        /// <summary>
        /// Gets short description of the picture.
        /// </summary>
        public string       Description { get { return this._description; } }

        /// <summary>
        /// Gets picture type
        /// </summary>
        /// <seealso cref="elp87.TagReader.id3v2.Frames.AttachedPictureFrame.PictureTypes"/>
        public PictureTypes PictureType { get { return (PictureTypes)this._picType; } }
        #endregion

        #region Methods
        #region Public
        /// <summary>
        /// Returns byte array of attached picture.
        /// </summary>
        /// <returns>Byte array of picture data</returns>
        public byte[] GetPictureData()
        {
            return (byte[])this._picData.Clone();
        }

        /// <summary>
        /// Returns instanse of <see cref="System.Drawing.Image"/> that contains frame picture
        /// </summary>
        /// <returns>instanse of <see cref="System.Drawing.Image"/> that contains frame picture</returns>
        /// <example>
        /// <code lang="C#">
        /// MP3File test = new MP3File(_fileNameMP3);
        /// Image image = test.Id3v2.APIC[0].GetPicture();
        /// image.Save(_fileNamePicSave);
        /// </code>
        /// Here is an example of saving the file to disk from mp3 file
        /// </example>
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
        /// <summary>
        /// Specifies available picture types
        /// </summary>
        public enum PictureTypes : byte
        {
            /// <summary> Other </summary>
            Other              = 0x00,
            /// <summary> 32x32 pixels 'file icon' (PNG only) </summary>
            FileIcon32PNG      = 0x01,
            /// <summary> Other file icon </summary>
            OtherFileIcon      = 0x02,
            /// <summary> Cover (front) </summary>
            CoverFront         = 0x03,
            /// <summary> Cover (back) </summary>
            CoverBack          = 0x04,
            /// <summary> Leaflet page </summary>
            LeafletPage        = 0x05,
            /// <summary> Media (e.g. label side of CD) </summary>
            Media              = 0x06,
            /// <summary> Lead artist/lead performer/soloist </summary>
            LeadArtist         = 0x07,
            /// <summary> Artist/performer </summary>
            Artist             = 0x08,
            /// <summary> Conductor </summary>
            Conductor          = 0x09,
            /// <summary> Band/Orchestra </summary>
            Band               = 0x0A,
            /// <summary> Composer </summary>
            Composer           = 0x0B,
            /// <summary> Lyricist/text writer </summary>
            Lyricist           = 0x0C,
            /// <summary> Recording Location </summary>
            RecordingLocation  = 0x0D,
            /// <summary> During recording </summary>
            DuringRecording    = 0x0E,
            /// <summary> During performance </summary>
            DuringPerformance  = 0x0F,
            /// <summary> Movie/video screen capture </summary>
            ScreenCapture      = 0x10,
            /// <summary> A bright coloured fish </summary>
            BrightColouredFish = 0x11,
            /// <summary> Illustration </summary>
            Illustration       = 0x12,
            /// <summary> Band/artist logotype </summary>
            ArtistLogo         = 0x13,
            /// <summary> Publisher/Studio logotype </summary>
            PublisherLogo      = 0x14
        }
        #endregion
    }
}
