using System;

namespace elp87.TagReader.id3v2
{
    public class FrameFlagSet
    {
        #region Fields
        private byte _grouping;
        private byte _encryptMethod;
        private int _dataLength;
        #endregion

        #region Constructors
        public FrameFlagSet() { }

        public FrameFlagSet(byte[] flagBytes)
        {
            this.ParseFlags(flagBytes);
        }        
        #endregion

        #region Properies
        public bool TagAlterPreservation { get; set; }
        public bool FileAlterPreservation { get; set; }
        public bool ReadOnly { get; set; }
        public bool GroupingIdentity { get; set; }
        public bool Compression { get; set; }
        public bool Encryption { get; set; }
        public bool Unsynchronisation { get; set; }
        public bool DataLengthIndicator { get; set; }

        public byte Grouping
        {
            get
            {
                if (this.GroupingIdentity)
                {
                    return _grouping;
                }
                else
                {
                    throw new Exceptions.FlagUnsetException("this value is not exist", "Grouping Identity flag is unset", DateTime.Now); 
                }
            }
        }
        public byte EncryptMethod
        {
            get
            {
                if (this.Encryption)
                {
                    return _encryptMethod;
                }
                else
                {
                    throw new Exceptions.FlagUnsetException("this value is not exist", "Encryption flag is unset", DateTime.Now);
                }
            }
        }
        public int DataLength
        {
            get
            {
                if (this.DataLengthIndicator)
                {
                    return _dataLength;
                }
                else
                {
                    throw new Exceptions.FlagUnsetException("this value is not exist", "Data Length Indicator flag is unset", DateTime.Now);
                }
            }
        }
        #endregion

        #region Methods
        #region Internal
        internal int GetExtraDate(byte[] tagArray, int position)
        {
            int offset = 0;
            if (this.GroupingIdentity)
            {
                this._grouping = tagArray[position + offset];
                offset++;
            }
            if (this.Encryption)
            {
                this._encryptMethod = tagArray[position + offset];
                offset++;
            }
            if (this.DataLengthIndicator)
            {
                byte[] lengthByte = new byte[4];
                Array.Copy(tagArray, position + offset, lengthByte, 0, 4);
                SynchsafeInteger ssLength = new SynchsafeInteger(lengthByte);
                this._dataLength = ssLength.ToInt();
                offset += 4;
            }
            return offset;
        }
        #endregion

        #region Private
        private void ParseFlags(byte[] flagBytes)
        {
            this.TagAlterPreservation = ByteOperation.GetBit(flagBytes[0], 6);
            this.FileAlterPreservation = ByteOperation.GetBit(flagBytes[0], 5);
            this.ReadOnly = ByteOperation.GetBit(flagBytes[0], 4);

            this.GroupingIdentity = ByteOperation.GetBit(flagBytes[1], 6);
            this.Compression = ByteOperation.GetBit(flagBytes[1], 3);
            this.Encryption = ByteOperation.GetBit(flagBytes[1], 2);
            this.Unsynchronisation = ByteOperation.GetBit(flagBytes[1], 1);
            this.DataLengthIndicator = ByteOperation.GetBit(flagBytes[1], 0);

            if (((flagBytes[0] & 0x8F) != 0) || ((flagBytes[1] & 0xB0) != 0)) throw new Exceptions.NotUsableFlagException("Invalid flag field in FrameFlagSet. Undefined flags are set", "", DateTime.Now);
        }
        #endregion
        #region Protected
        protected int GetExtraDate(byte[] tagArray, int position, bool b)
        {
            return this.GetExtraDate(tagArray, position);
        }
        #endregion
        #endregion


    }
}
