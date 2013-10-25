using System;
using System.Text;

namespace elp87.TagReader.id3v2.Abstract
{
    /// <summary>
    /// This abstract base class provides general functionality for all text frames with language information
    /// </summary>
    public abstract class LanguageTextFrame
        : TextFrame
    {
        #region Fields
        /// <summary>
        /// Language of frame
        /// </summary>
        protected string _language;
        #endregion

        #region Constructors
        /// <summary>
        /// Inheritable constructor for <see cref="elp87.TagReader.id3v2.Abstract.LanguageTextFrame"/> class
        /// </summary>
        public LanguageTextFrame()
            : base()
        { }

        /// <summary>
        /// Main inheritable constructor for <see cref="elp87.TagReader.id3v2.Abstract.LanguageTextFrame"/> class.
        /// </summary>
        /// <param name="flags">Flag fields of current frame.</param>
        /// <param name="frameData">Byte array that contains frame data excluding frame header and header extra data.</param>
        public LanguageTextFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        {
            this._language = this.GetLanguage();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets language.
        /// </summary>
        /// <exception cref="elp87.TagReader.id3v2.Exceptions.IncorrectLanguageException">Language string length is not equal 3.</exception>
        public string Language
        {
            get
            {
                if (this._language.Length == 3) return this._language;
                else throw new elp87.TagReader.id3v2.Exceptions.IncorrectLanguageException();
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Returns language value from <see cref="elp87.TagReader.id3v2.Abstract.Frame._frameData"/>
        /// </summary>
        /// <returns>Language value.</returns>
        protected string GetLanguage()
        {
            byte[] langBytes = new byte[3];
            Array.Copy(this._frameData, langBytes, 3);
            string lang = Encoding.ASCII.GetString(langBytes);
            return lang;
        }        
        #endregion
    }
}
