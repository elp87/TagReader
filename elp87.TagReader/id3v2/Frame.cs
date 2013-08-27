using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace elp87.TagReader.id3v2
{
    public class Frame
    {
        #region Constants
        private static Dictionary<string, string> _frameIDs
            = new Dictionary<string, string>() { { "TALB", "album" }, { "TIT2", "title" }, { "TPE1", "performer" } };
        #endregion

        #region Fields
        private string _identificator;
        private string _frameValue;
        private byte[] _frameData;
        private int _frameSize;
        private int _posOffset;
        private int _pointPosition;
        private byte[] _flags;
        private byte _encodingByte;
        private Encoding _enc;
        #endregion

        #region Constructors
        public Frame()
        {
            _flags = new byte[2];
            _posOffset = 0;
        }
        #endregion

        #region Properties
        public string id { get { return _identificator; } }

        public string value { get { return _frameValue; } }

        public int frameSize { get { return _frameSize; } }
        #endregion

        #region Methods
        #region Public
        public void ReadFrame(ID3V2 tag, byte[] tagArray, int pointPosition)
        {
            _pointPosition = pointPosition;
            byte[] _id = new byte[4];
            byte[] size = new byte[4];
            byte[] bom = new byte[2];

            GetIdentificator(tagArray, _id);
            GetFrameSize(tagArray, size);
            GetFlagsField(tagArray);
            GetEncoding(tagArray, bom);
            GetDataValue(tagArray);

            SetValueIntoTag(tag);
        }

        private void SetValueIntoTag(ID3V2 tag)
        {
            if (_frameIDs.ContainsKey(this.id)) 
            {
                Type tagType = tag.GetType();
                string propertyName = _frameIDs[this.id];
                PropertyInfo selectedField = tagType.GetProperty(propertyName);
                selectedField.SetValue(tag, this.value);
            }
        }
        #endregion

        #region Private
        private void GetIdentificator(byte[] tag, byte[] id)
        {
            Array.Copy(tag, _pointPosition, id, 0, 4);
            _identificator = Encoding.UTF8.GetString(id);
            _pointPosition += 4;            
        }

        private void GetFrameSize(byte[] tag, byte[] size)
        {
            Array.Copy(tag, _pointPosition, size, 0, 4);
            _frameSize = new SynchsafeInteger(size).ToInt();
            _pointPosition += 4;
        }

        private void GetFlagsField(byte[] tag)
        {
            Array.Copy(tag, _pointPosition, _flags, 0, 2);
            _pointPosition += 2;
        }

        private void GetEncoding(byte[] tag, byte[] bom)
        {
            _encodingByte = tag[_pointPosition];
            _posOffset = 1;
            _pointPosition++;
            switch (_encodingByte)
            {
                case 0x00:
                    _enc = Encoding.GetEncoding("ISO-8859-1");
                    break;
                case 0x01:
                    Array.Copy(tag, _pointPosition, bom, 0, 2);
                    _enc = Encoding.Unicode;
                    _pointPosition += 2;
                    _posOffset += 2;
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
                    byte[] idb = Encoding.UTF8.GetBytes(id);
                    throw new UnknownEncodingException("Unknown encoding in frame " + _pointPosition, _encodingByte.ToString(), DateTime.Now);
                    break;
            }
        }

        private void GetDataValue(byte[] tag)
        {
            _frameData = new byte[_frameSize - _posOffset];
            Array.Copy(tag, _pointPosition, _frameData, 0, _frameSize - _posOffset);
            _frameValue = _enc.GetString(_frameData);
        }
        #endregion
        #endregion
    }
}
