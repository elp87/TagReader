using System;
using System.Text;

namespace elp87.TagReader.id3v2.Abstract
{
    public abstract class LanguageTextFrame
        : TextFrame
    {
        #region Fields
        string _language;
        #endregion

        #region Constructors
        public LanguageTextFrame()
            : base()
        { }

        public LanguageTextFrame(FrameFlagSet flags, byte[] frameData)
            : base(flags, frameData)
        {
            this._language = this.GetLanguage();
        }
        #endregion

        #region Properties
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
