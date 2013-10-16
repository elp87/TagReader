using elp87.TagReader.id3v2.Abstract;
using System;

namespace elp87.TagReader.id3v2.Frames
{
    public class UnsunchTextFrame
        : LanguageTextFrame
    {
        #region Fields
        private string _description;
        private string[] _lyrics;
        private byte[] _frameBody;                
        #endregion

        #region Constructors
        protected UnsunchTextFrame()
            : base()
        { }

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
            string fullLyric = this.GetString(lyricArray);
            this._lyrics = this.ReadLyrics(fullLyric);
        }        
        #endregion

        #region Properties
        public string Description { get { return this._description; } }
        #endregion

        #region Methods
        public string[] GetLyrics()
        {
            return (string[])this._lyrics.Clone();
        }

        private byte[] ReadFrameBody()
        {
            byte[] frameBody = new byte[this._frameData.Length - 3];
            Array.Copy(this._frameData, 3, frameBody, 0, frameBody.Length);
            return frameBody;
        }

        private string[] ReadLyrics(string lyricsString)
        {            
            int stringCount = UnsunchTextFrame.GetStringCount(lyricsString);
            string[] lyricsArray = new string[stringCount];

            for (int i = 0; i < stringCount; i++)
            {
                int newStrinPos = lyricsString.IndexOf('\0');
                if (newStrinPos != -1)
                {
                    lyricsArray[i] = lyricsString.Substring(0, newStrinPos);
                    lyricsString = lyricsString.Substring(newStrinPos + 1);
                }
                else
                {
                    lyricsArray[i] = lyricsString;
                }
            }
            return lyricsArray;
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
        #endregion
    }
}
