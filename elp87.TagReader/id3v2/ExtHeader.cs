using System;

namespace elp87.TagReader.id3v2
{
    /// <summary>
    /// This class provides information from id3v2 extended header
    /// </summary>
    /// <remarks>
    /// In current version it is supported only id3v2.4 extended header
    /// </remarks>
    public class ExtHeader
    {
        // TODO: ExtHeader work with id3v2.4 only. Make for 2.3
        #region Fields
        private bool _isUpdate;
        private bool _isCRC;
        private bool _isRestrictions;
        private int _CRC;
        private TagSizeRestrictions _tagSizeRestriction;
        private TextEncodingRestrictions _textEncodingRestriction;
        private TextFieldsSizeRestrictions _textFieldsSizeRestriction;
        private ImageEncodingRestrictions _imageEncodingRestriction;
        private ImageSizeRestrictions _imageSizeRestriction;
        #endregion

        #region Properties
        /// <summary>
        /// Gets and sets extended header size
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Gets whether the "Tag is an update" flag is set
        /// </summary>
        public bool IsUpdate { get { return _isUpdate; } }

        /// <summary>
        /// Gets whether the "CRC data present" flag is set
        /// </summary>
        public bool IsCRC { get { return _isCRC; } }

        /// <summary>
        /// Gets whether the "Tag restrictions" flag is set
        /// </summary>
        public bool IsRestrictions { get { return _isRestrictions; } }

        /// <summary>
        /// Gets the CRC value
        /// </summary>
        public int CRC { get { return _CRC; } }

        /// <summary>
        /// Gets tag size restrictions
        /// </summary>
        public TagSizeRestrictions TagSizeRestriction { get { return _tagSizeRestriction; } }

        /// <summary>
        /// Gets text encoding restrictions
        /// </summary>
        public TextEncodingRestrictions TextEncodingRestriction { get { return _textEncodingRestriction; } }

        /// <summary>
        /// Gets text fields size restrictions
        /// </summary>
        public TextFieldsSizeRestrictions TextFieldsSizeRestriction { get { return _textFieldsSizeRestriction; } }

        /// <summary>
        /// Gets image encoding restrictions
        /// </summary>
        public ImageEncodingRestrictions ImageEncodingRestriction { get { return _imageEncodingRestriction; } }

        /// <summary>
        /// Gets image size restrictions
        /// </summary>
        public ImageSizeRestrictions ImageSizeRestriction { get { return _imageSizeRestriction; } }
        #endregion

        #region Methods
        #region Internal
        internal void ParseFlagField(byte flagByte)
        {
            _isUpdate = Convert.ToBoolean((flagByte & 0x40) >> 6);
            _isCRC = Convert.ToBoolean((flagByte & 0x20) >> 5);
            _isRestrictions = Convert.ToBoolean((flagByte & 0x10) >> 4);
            if ((flagByte & 0x8F) != 0) throw new Exceptions.NotUsableFlagException("Invalid flag field in Ext Header. Undefined flags are set", Convert.ToString(flagByte, 2), DateTime.Now);            
        }

        internal void ReadExtHeader(byte[] byteArray, int pointPosition)
        {
            this.Size = this.GetSize(byteArray, pointPosition);
            pointPosition += 4; // Сдвиг после размера
            pointPosition += 1; // 0x01 - Кол-во байт флага
            this.ParseFlagField(byteArray[pointPosition]);
            pointPosition += 1; // Сдвиг после поля флагов
            if (this._isCRC)
            {
                pointPosition += 1; // 0x05 - Кол-во байт флага
                this.ReadCRC(byteArray, pointPosition);
                pointPosition += 5; // Сдвиг после поля CRC
            }
            if (this._isRestrictions)
            {
                pointPosition += 1; // 0x01 - Кол-во байт флага
                this.ReadRestrictions(byteArray, pointPosition);
                pointPosition += 1; // Сдвиг после поля ограничения тега
            }
        }       
        #endregion

        #region Private
        private int GetSize(byte[] byteArray, int pointPosition)
        {
            byte[] extHeaderSizeArray = new byte[4];
            Array.Copy(byteArray, pointPosition, extHeaderSizeArray, 0, 4);
            SynchsafeInteger ssSize = new SynchsafeInteger(extHeaderSizeArray);
            return ssSize.ToInt();
        }

        private void ReadCRC(byte[] byteArray, int pointPosition)
        {
            byte[] CRCbyte = new byte[5];
            Array.Copy(byteArray, pointPosition, CRCbyte, 0, 5);
            SynchsafeCRC CRCField = new SynchsafeCRC(CRCbyte);
            this._CRC = CRCField.ToInt();
        }

        private void ReadRestrictions(byte[] byteArray, int pointPosition)
        {
            byte RestrictionByte = byteArray[pointPosition];
            this._tagSizeRestriction = GetTagSizeRestrict(RestrictionByte);
            this._textEncodingRestriction = GetTextEncodingRestriction(RestrictionByte);
            this._textFieldsSizeRestriction = GetTextFieldsSizeRestriction(RestrictionByte);
            this._imageEncodingRestriction = GetImageEncodingRestriction(RestrictionByte);
            this._imageSizeRestriction = GetImageSizeRestriction(RestrictionByte);
        }

        private TagSizeRestrictions GetTagSizeRestrict(byte RestrictionByte)
        {
            int tagSizeFlagValue = (RestrictionByte & 0xC0) >> 6;
            return (TagSizeRestrictions)tagSizeFlagValue;             
        }

        private TextEncodingRestrictions GetTextEncodingRestriction(byte RestrictionByte)
        {
            int textEncodingFlagValue = (RestrictionByte & 0x20) >> 5;
            return (TextEncodingRestrictions)textEncodingFlagValue;
        }

        private TextFieldsSizeRestrictions GetTextFieldsSizeRestriction(byte RestrictionByte)
        {
            int textFieldSizeFlagValue = (RestrictionByte & 0x18) >> 3;
            return (TextFieldsSizeRestrictions)textFieldSizeFlagValue;
        }

        private ImageEncodingRestrictions GetImageEncodingRestriction(byte RestrictionByte)
        {
            int imageEncodingFlagValue = (RestrictionByte & 0x04) >> 2;
            return (ImageEncodingRestrictions)imageEncodingFlagValue;
        }

        private ImageSizeRestrictions GetImageSizeRestriction(byte RestrictionByte)
        {
            int imageSizeFlagValue = (RestrictionByte & 0x03);
            return (ImageSizeRestrictions)imageSizeFlagValue;
        }
        #endregion
        #endregion

        #region Enums
        /// <summary>
        /// Specifies identifiers to indicate tag size restrictions
        /// </summary>
        public enum TagSizeRestrictions
        {
            /// <summary> No more than 128 frames and 1 MB total tag size.</summary>
            NoMore1MBTagSize = 0,
            /// <summary> No more than 64 frames and 128 KB total tag size. </summary>
            NoMore128KBTagSize = 1,
            /// <summary> No more than 32 frames and 40 KB total tag size. </summary>
            NoMore40KBTagSize = 2,
            /// <summary> No more than 32 frames and 4 KB total tag size. </summary>
            NoMore4KBTagSize = 3
        }

        /// <summary>
        /// Specifies identifiers to indicate text encoding restrictions
        /// </summary>
        public enum TextEncodingRestrictions
        {
            /// <summary> No restrictions. </summary>
            NoRestrictions = 0,
            /// <summary> Strings are only encoded with ISO-8859-1 [ISO-8859-1] or UTF-8 [UTF-8]. </summary>
            ISO_8859_Or_UTF8_Only
        }

        /// <summary>
        /// Specifies identifiers to indicate text fields size restrictions
        /// </summary>
        /// <remarks>
        /// Note that nothing is said about how many bytes is used to represent those characters, since it is encoding dependent. 
        /// If a text frame consists of more than one string, the sum of the strungs is restricted as stated.
        /// </remarks>
        public enum TextFieldsSizeRestrictions
        {
            /// <summary> No restrictions </summary>
            NoRestrictions = 0,
            /// <summary> No string is longer than 1024 characters. </summary>
            NoLonger1024Char = 1,
            /// <summary> No string is longer than 128 characters. </summary>
            NoLonger128Char = 2,
            /// <summary> No string is longer than 30 characters. </summary>
            NoLonger30Char = 3
        }

        /// <summary>
        /// Specifies identifiers to indicate image encoding restrictions
        /// </summary>
        public enum ImageEncodingRestrictions
        {
            /// <summary> No restrictions </summary>
            NoRestrictions = 0,
            /// <summary> Images are encoded only with PNG [PNG] or JPEG [JFIF]. </summary>
            PngOrJpegOnly = 1
        }

        /// <summary>
        /// Specifies identifiers to indicate image size restrictions
        /// </summary>
        public enum ImageSizeRestrictions
        {
            /// <summary> No restrictions. </summary>
            NoRestrictions = 0,
            /// <summary> All images are 256x256 pixels or smaller. </summary>
            Smaller256Pixel = 1,
            /// <summary> All images are 64x64 pixels or smaller. </summary>
            Smaller64Pixel = 2,
            /// <summary> All images are exactly 64x64 pixels, unless required otherwise. </summary>
            Exactly64Pixel = 3
        }
        #endregion

    }
}
