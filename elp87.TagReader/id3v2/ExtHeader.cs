using System;

namespace elp87.TagReader.id3v2
{
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
        public int Size { get; set; }
        public bool IsUpdate { get { return _isUpdate; } }
        public bool IsCRC { get { return _isCRC; } }
        public bool IsRestrictions { get { return _isRestrictions; } }

        public int CRC { get { return _CRC; } }

        public TagSizeRestrictions TagSizeRestriction { get { return _tagSizeRestriction; } }
        public TextEncodingRestrictions TextEncodingRestriction { get { return _textEncodingRestriction; } }
        public TextFieldsSizeRestrictions TextFieldsSizeRestriction { get { return _textFieldsSizeRestriction; } }
        public ImageEncodingRestrictions ImageEncodingRestriction { get { return _imageEncodingRestriction; } }
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
        public enum TagSizeRestrictions
        {
            NoMore1MBTagSize = 0,
            NoMore128KBTagSize = 1,
            NoMore40KBTagSize = 2,
            NoMore4KBTagSize = 3
        }

        public enum TextEncodingRestrictions
        {
            NoRestrictions = 0,
            ISO_8859_Or_UTF8_Only
        }

        public enum TextFieldsSizeRestrictions
        {
            NoRestrictions = 0,
            NoLonger1024Char = 1,
            NoLonger128Char = 2,
            NoLonger30Char = 3
        }

        public enum ImageEncodingRestrictions
        {
            NoRestrictions = 0,
            PngOrJpegOnly = 1
        }

        public enum ImageSizeRestrictions
        {
            NoRestrictions = 0,
            Smaller256Pixel = 1,
            Smaller64Pixel = 2,
            Exactly64Pixel = 3
        }
        #endregion

    }
}
