using System;
using System.Text;

namespace elp87.TagReader.id3v2.Abstract
{
    /// <summary>
    /// This abstract base class provides general functionality for all frames that contain text information with text encoding
    /// </summary>
    public abstract class TextFrame : Frame
    {
        #region Fields
        /// <summary>
        /// Encoding of text information fields
        /// </summary>
        protected TextEncoding _encoding;
        private int posOffset;
        #endregion

        #region Constructors
        /// <summary>
        /// Inheritable constructor for <see cref="elp87.TagReader.id3v2.Abstract.TextFrame"/> class
        /// </summary>
        public TextFrame() : base() { }

        /// <summary>
        /// Main inheritable constructor for <see cref="elp87.TagReader.id3v2.Abstract.TextFrame"/> class.
        /// </summary>
        /// <param name="flags">Flag fields of current frame.</param>
        /// <param name="frameData">Byte array that contains frame data excluding drame header and header extra data.</param>
        public TextFrame(FrameFlagSet flags, byte[] frameData) 
        {
            this._flags = flags;
            this.SetEncoding(frameData[0]);
            this._frameData = new byte[frameData.Length - 1];
            Array.Copy(frameData, 1, this._frameData, 0, frameData.Length - 1);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Returns string from byte array according current text encoding
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected string GetString(byte[] data)
        {
            Encoding enc;
            byte[] bom;
            posOffset = 1;

            switch (_encoding)
            {
                case (TextEncoding.ISO_8859_1) :
                    enc = Encoding.GetEncoding("ISO-8859-1");
                    break;
                case (TextEncoding.UTF16):
                    bom = new byte[2];
                    Array.Copy(data, 0, bom, 0, 2);
                    enc = Encoding.Unicode;
                    posOffset += 2;
                    data = this.RemoveBomFromData(data);
                    // или Encoding.BigEndianUnicode в зависимости от BOM
                    // TODO : Разобраться с BOM
                    break;
                case (TextEncoding.UTF16_BE):
                    enc = Encoding.Unicode;
                    break;
                case (TextEncoding.UTF8):
                    enc = Encoding.UTF8;
                    break;
                default:
                    throw new Exceptions.UnknownEncodingException();                    
            }
            return enc.GetString(data);
        }

        /// <summary>
        /// Returns byte array without byte order mark for <see cref="elp87.TagReader.id3v2.Abstract.TextFrame.TextEncoding.UTF16"/>
        /// </summary>
        /// <param name="dataWithBom">Byte array contained byte order mark</param>
        /// <returns>Byte array without byte order mark</returns>
        protected byte[] RemoveBomFromData(byte[] dataWithBom)
        {
            byte[] withouBom = new byte[dataWithBom.Length - 2];
            Array.Copy(dataWithBom, 2, withouBom, 0, withouBom.Length);
            return withouBom;
        }

        /// <summary>
        /// Returns count of strings contained in general string 
        /// </summary>
        /// <param name="text">General string</param>
        /// <returns>Cunt of strings</returns>
        protected static int GetStringCount(string text)
        {
            int count = 1;

            foreach (char ch in text)
            {
                if (ch == '\0') count++;
            }

            return count;
        }

        /// <summary>
        /// Sets encoding in accordance with text encoding byte
        /// </summary>
        /// <param name="encodeByte"></param>
        protected void SetEncoding(byte encodeByte)
        {
            this._encoding = (TextEncoding)encodeByte;
        }
        #endregion

        #region Enum
        /// <summary>
        /// Specifies text encodings for text frames
        /// </summary>
        protected enum TextEncoding : byte
        {
            /// <summary> ISO-8859-1.Terminated with $00. </summary>
            ISO_8859_1  = 0x00,
            /// <summary> UTF-16 encoded Unicode with BOM. Terminated with $00 00. </summary>
            UTF16       = 0x01,
            /// <summary> UTF-16BE encoded Unicode without BOM. Terminated with $00 00. </summary>
            UTF16_BE    = 0x02,
            /// <summary>
            /// UTF-8 encoded Unicode. Terminated with $00.
            /// </summary>
            UTF8        = 0x03
        }
        #endregion
    }
}
