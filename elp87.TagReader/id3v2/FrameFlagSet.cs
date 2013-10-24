using System;

namespace elp87.TagReader.id3v2
{
    /// <summary>
    /// This class provides information about frame header flags
    /// </summary>
    public class FrameFlagSet
    {
        #region Fields
        private byte _grouping;
        private byte _encryptMethod;
        private int _dataLength;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="elp87.TagReader.id3v2.FrameFlagSet"/> that is empty
        /// </summary>
        public FrameFlagSet() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="elp87.TagReader.id3v2.FrameFlagSet"/>
        /// </summary>
        /// <param name="flagBytes">Flags byte array</param>
        /// <exception cref="elp87.TagReader.id3v2.Exceptions.NotUsableFlagException">Not usable flag is set</exception>
        public FrameFlagSet(byte[] flagBytes)
        {
            this.ParseFlags(flagBytes);
        }        
        #endregion

        #region Properies
        /// <summary>
        /// Gets and sets whether "Tag alter preservation" flag is set
        /// </summary>
        public bool TagAlterPreservation { get; set; }

        /// <summary>
        /// Gets and sets whether "File alter preservation" flag is set
        /// </summary>
        public bool FileAlterPreservation { get; set; }

        /// <summary>
        /// Gets and sets whether "Read only" flag is set
        /// </summary>
        public bool ReadOnly { get; set; }

        /// <summary>
        /// Gets and sets whether "Grouping identity" flag is set
        /// </summary>
        public bool GroupingIdentity { get; set; }

        /// <summary>
        /// Gets and sets whether "Compression" flag is set
        /// </summary>
        public bool Compression { get; set; }

        /// <summary>
        /// Gets and sets whether "Encryption" flag is set
        /// </summary>
        public bool Encryption { get; set; }

        /// <summary>
        /// Gets and sets whether "Unsynchronisation" flag is set
        /// </summary>
        public bool Unsynchronisation { get; set; }

        /// <summary>
        /// Gets and sets whether "Data length indicator" flag is set
        /// </summary>
        public bool DataLengthIndicator { get; set; }


        /// <summary>
        /// Gets group identifier byte if "Grouping identity" flag is set.
        /// </summary>
        /// <exception cref="elp87.TagReader.id3v2.Exceptions.FlagUnsetException">"Grouping identity" flag is unset</exception>
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

        /// <summary>
        /// Gets encryption method byte if "Encryption" flag is set
        /// </summary>
        /// <exception cref="elp87.TagReader.id3v2.Exceptions.FlagUnsetException">"Encryption flag is unset</exception>
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

        /// <summary>
        /// Gets data length indicator is the value one would write as the 'Frame length' if all of the frame format flags were zeroed
        /// </summary>
        /// <exception cref="elp87.TagReader.id3v2.Exceptions.FlagUnsetException">Data Length Indicator flag is unset</exception>
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
        internal int GetExtraData(byte[] tagArray, int position)
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
        /// <summary>
        /// Returns length of Grouping, EncryptMethod and DataLength data and sets their value from frame byte array
        /// </summary>
        /// <param name="position">Zero-based position of extra data start</param>
        /// <param name="tagArray">Byte array of current tag</param>
        /// <returns>Length of Grouping, EncryptMethod and DataLength data</returns>
        protected int GetExtraData(int position, byte[] tagArray)
        {
            return this.GetExtraData(tagArray, position);
        }
        #endregion
        #endregion


    }
}
