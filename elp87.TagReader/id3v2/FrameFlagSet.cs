using System;
using System.Collections.Generic;
using System.Text;

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
        public bool tagAlterPreservation { get; set; }
        public bool fileAlterPreservation { get; set; }
        public bool readOnly { get; set; }
        public bool groupingIdentity { get; set; }
        public bool compression { get; set; }
        public bool encryption { get; set; }
        public bool unsynchronisation { get; set; }
        public bool dataLengthIndicator { get; set; }

        public byte grouping
        {
            get
            {
                if (this.groupingIdentity)
                {
                    return _grouping;
                }
                else
                {
                    throw new Exceptions.FlagUnsetException("this value is not exist", "Grouping Identity flag is unset", DateTime.Now); 
                }
            }
        }
        public byte encryptMethod
        {
            get
            {
                if (this.encryption)
                {
                    return _encryptMethod;
                }
                else
                {
                    throw new Exceptions.FlagUnsetException("this value is not exist", "Encryption flag is unset", DateTime.Now);
                }
            }
        }
        public int dataLength
        {
            get
            {
                if (this.dataLengthIndicator)
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
            if (this.groupingIdentity)
            {
                this._grouping = tagArray[position + offset];
                offset++;
            }
            if (this.encryption)
            {
                this._encryptMethod = tagArray[position + offset];
                offset++;
            }
            if (this.dataLengthIndicator)
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
            this.tagAlterPreservation = ByteOperation.GetBit(flagBytes[0], 6);
            this.fileAlterPreservation = ByteOperation.GetBit(flagBytes[0], 5);
            this.readOnly = ByteOperation.GetBit(flagBytes[0], 4);

            this.groupingIdentity = ByteOperation.GetBit(flagBytes[1], 6);
            this.compression = ByteOperation.GetBit(flagBytes[1], 3);
            this.encryption = ByteOperation.GetBit(flagBytes[1], 2);
            this.unsynchronisation = ByteOperation.GetBit(flagBytes[1], 1);
            this.dataLengthIndicator = ByteOperation.GetBit(flagBytes[1], 0);

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
