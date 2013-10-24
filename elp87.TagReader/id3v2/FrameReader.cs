using System;
using System.Collections.Generic;
using System.Text;

namespace elp87.TagReader.id3v2
{
    /// <summary>
    /// This class provides functionality to construct new frames from tag byte array
    /// </summary>
    public class FrameReader
    {
        #region Constants
        private static Dictionary<string, FrameTypeInfo> _frameIDs = Dictionaries.frameIDs;

        private static Dictionary<string, string> _conformityFrame3To4 = Dictionaries.conformityFrame3To4;
        #endregion

        #region Fields
        private FrameTypeInfo _frame;
        private string _identificator;
        private byte[] _frameData;
        private int _frameSize;
        private int _pointPosition;
        private byte[] _flags;
        private FrameFlagSet _flagSet;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="elp87.TagReader.id3v2.FrameReader"/> class
        /// </summary>
        public FrameReader()
        {
            _flags = new byte[2];            
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets frame identificator
        /// </summary>
        public string Id { get { return _identificator; } }

        /// <summary>
        /// Gets frame size, excluding frame header
        /// </summary>
        public int FrameSize { get { return _frameSize; } }
        #endregion

        #region Methods
        #region Internal
        internal void ReadFrame(ID3V2 tag, byte[] tagArray, int pointPosition)
        {
            _pointPosition = pointPosition;
            byte[] _id = new byte[4];
            byte[] size = new byte[4];
            

            GetIdentificator(tagArray, _id);
            AdjustTagID();
            GetFrameSize(tagArray, size, tag.Header.TagVersion);
            if (FindId())
            {
                GetFlagsField(tagArray);
                _flagSet = new FrameFlagSet(_flags);
                _pointPosition += _flagSet.GetExtraData(tagArray, _pointPosition);
                GetDataValue(tagArray);
                SetValueIntoTag(tag);
            }
            else
            {
                _pointPosition += this.FrameSize;
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

        private void AdjustTagID()
        {
            string _id4frame = "";
            if (_conformityFrame3To4.TryGetValue(this._identificator, out _id4frame))
            {
                this._identificator = _id4frame;
            }
        }

        private bool FindId()
        {
            return _frameIDs.TryGetValue(this.Id, out _frame);
        }

        private void GetFrameSize(byte[] tag, byte[] size, int tagVersion)
        {
            Array.Copy(tag, _pointPosition, size, 0, 4);
            if (tagVersion == 4) { _frameSize = new SynchsafeInteger(size).ToInt(); }
            if (tagVersion == 3) { _frameSize = BitConverter.ToInt32(ByteArray.Reverse(size), 0); }
            if (tagVersion != 3 && tagVersion != 4) { throw new Exceptions.UnsupportedTagVersionException(); }
            _pointPosition += 4;
        }

        private void GetFlagsField(byte[] tag)
        {
            Array.Copy(tag, _pointPosition, _flags, 0, 2);
            _pointPosition += 2;
        }

        private void GetDataValue(byte[] tag)
        {
            _frameData = new byte[_frameSize];
            Array.Copy(tag, _pointPosition, _frameData, 0, _frameSize);
        }

        private void SetValueIntoTag(ID3V2 tag)
        {            
            Type tagType = tag.GetType();
            string methodName = "Set" + _frame.Id;
            tagType.GetMethod(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .Invoke(tag, new object[] { _flagSet, _frameData });
        }
        #endregion
        #endregion
    }
}
