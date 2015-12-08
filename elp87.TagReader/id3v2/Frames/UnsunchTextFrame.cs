using elp87.TagReader.id3v2.Abstract;
using System;

namespace elp87.TagReader.id3v2.Frames
{
    /// <summary>
    /// Provides functionality for Unsynchronised text frames.
    /// </summary>
    /// <remarks>This class allows to read USLT and COMM frames. For details read "ID3 tag version 2.4.0 - Native Frames"</remarks>
    /// <seealso cref="elp87.TagReader.id3v2.ID3V2.USLT"/>
    /// <seealso cref="elp87.TagReader.id3v2.ID3V2.COMM"/>
    public class UnsunchTextFrame
        : LanguageTextFrame
    {
        #region Fields
        private string _description;
        private string _textValue;
        private byte[] _frameBody;                
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.UnsunchTextFrame"/> that is empty.
        /// </summary>
        protected UnsunchTextFrame()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="elp87.TagReader.id3v2.Frames.UnsunchTextFrame"/> and read frame data
        /// </summary>
        /// <param name="flags">Flag fields of current frame.</param>
        /// <param name="frameData">Byte array that contains frame data excluding frame header and header extra data.</param>
        public UnsunchTextFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        {
            this._frameBody = this.ReadFrameBody();
            int terminatorPosition = this.ParseTerminatorPos(this._frameBody);
            byte[] descArray = new byte[terminatorPosition];
            byte[] lyricArray = new byte[this._frameBody.Length - terminatorPosition - 1];
            Array.Copy(this._frameBody, descArray, terminatorPosition);
            Array.Copy(this._frameBody, terminatorPosition + 1, lyricArray, 0, lyricArray.Length);
            this._description = this.GetString(descArray);
            this._textValue = this.GetString(lyricArray);            
        }        
        #endregion

        #region Properties
        /// <summary>
        /// Gets short frame description
        /// </summary>
        public string Description { get { return this._description; } }

        /// <summary>
        /// Gets actual frame text
        /// </summary>
        public string Value      { get { return this._textValue; } }
        #endregion

        #region Methods        

        private byte[] ReadFrameBody()
        {
            byte[] frameBody = new byte[this._frameData.Length - 3];
            Array.Copy(this._frameData, 3, frameBody, 0, frameBody.Length);
            return frameBody;
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

            if (frameData.Length == 1) return 0; // Bugfix: empty COMM or USLT frame
            while (frameData[position + 1] == 0x00) { position++; }
            return position;
        } 
        #endregion
    }
}
