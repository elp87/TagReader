using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elp87.TagReader.id3v2
{
    public partial class ID3V2
    {
        public void SetTALB(byte[] data)
        {
            this.album = SetTextInformationFrame(data);
        }

        public void SetTDRC(byte[] data)
        {
            this.year = SetTextInformationFrame(data);
        }

        public void SetTIT2(byte[] data)
        {
            this.title = SetTextInformationFrame(data);
        }

        public void SetTPE1(byte[] data)
        {
            this.performer = SetTextInformationFrame(data);
        }

        public void SetTRCK(byte[] data)
        {
            this.trackPosition = SetTextInformationFrame(data);
        }

        #region Private
        private string SetTextInformationFrame(byte[] data)
        {
            byte[] bom = new byte[2];
            int _posOffset;

            Encoding _enc = GetEncoding(data, bom, out _posOffset);
            return GetDataValue(data, _enc, _posOffset);
        }

        
        private Encoding GetEncoding(byte[] tag, byte[] bom, out int posOffset)
        {
            Encoding _enc;
            byte _encodingByte = tag[0];
            posOffset = 1;
            switch (_encodingByte)
            {
                case 0x00:
                    _enc = Encoding.GetEncoding("ISO-8859-1");
                    break;
                case 0x01:
                    Array.Copy(tag, posOffset, bom, 0, 2);
                    _enc = Encoding.Unicode;
                    posOffset += 2;
                    // или Encoding.BigEndianUnicode в зависимости от BOM
                    // TODO : Разобраться с BOM
                    break;
                case 0x02:
                    _enc = Encoding.Unicode;
                    break;
                case 0x03:
                    _enc = Encoding.UTF8;
                    break;
                default:
                    throw new Exceptions.UnknownEncodingException("Unknown encoding in frame " + _pointPosition, _encodingByte.ToString(), DateTime.Now);
                    break;
            }
            return _enc;
        }

        private string GetDataValue(byte[] tag, Encoding enc, int posOffset)
        {
            byte[] _frameData = new byte[tag.Length - posOffset];
            Array.Copy(tag, posOffset, _frameData, 0, _frameData.Length);
            
            string _frameValue = enc.GetString(_frameData);
            if (_frameValue[_frameValue.Length - 1] == '\0') _frameValue = _frameValue.Substring(0, _frameValue.Length - 1);
            return _frameValue;

        }
        #endregion

    }
}
