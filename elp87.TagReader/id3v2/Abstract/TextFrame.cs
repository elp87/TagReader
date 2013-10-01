using System;
using System.Text;

namespace elp87.TagReader.id3v2.Abstract
{
    public abstract class TextFrame : Frame
    {
        #region Fields
        protected TextEncoding _encoding;
        private int posOffset;
        #endregion

        #region Constructors
        public TextFrame() : base() { }

        public TextFrame(FrameFlagSet flags, byte[] frameData) 
        {
            this._flags = flags;
            this.SetEncoding(frameData[0]);
            this._frameData = new byte[frameData.Length - 1];
            Array.Copy(frameData, 1, this._frameData, 0, frameData.Length - 1);
        }
        #endregion

        #region Methods
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

        protected byte[] RemoveBomFromData(byte[] dataWithBom)
        {
            byte[] withouBom = new byte[dataWithBom.Length - 2];
            Array.Copy(dataWithBom, 2, withouBom, 0, withouBom.Length);
            return withouBom;
        }

        protected static int GetStringCount(string text)
        {
            int count = 1;

            foreach (char ch in text)
            {
                if (ch == '\0') count++;
            }

            return count;
        }

        protected void SetEncoding(byte encodeByte)
        {
            this._encoding = (TextEncoding)encodeByte;
        }
        #endregion

        #region Enum
        protected enum TextEncoding : byte
        {
            ISO_8859_1  = 0x00,
            UTF16       = 0x01,
            UTF16_BE    = 0x02,
            UTF8        = 0x03
        }
        #endregion
    }
}
