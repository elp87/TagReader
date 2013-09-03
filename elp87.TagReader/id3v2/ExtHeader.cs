using System;

namespace elp87.TagReader.id3v2
{
    public class ExtHeader
    {
        // TODO: ExtHeader work with id3v2.4 only. Make for 2.3
        private bool _isUpdate;
        private bool _isCRC;
        private bool _isRestrictions;
        private int _CRC;

        public int size { get; set; }
        public bool isUpdate { get { return _isUpdate; } }
        public bool isCRC { get { return _isCRC; } }
        public bool isRestrictions { get { return _isRestrictions; } }

        public int CRC { get { return _CRC; } }

        internal void ParseFlagField(byte flagByte)
        {
            _isUpdate = Convert.ToBoolean((flagByte & 0x40) >> 6);
            _isCRC = Convert.ToBoolean((flagByte & 0x20) >> 5);
            _isRestrictions = Convert.ToBoolean((flagByte & 0x10) >> 4);
            if ((flagByte & 0x8F) != 0) throw new Exceptions.NotUsableFlagException("Invalid flag field in Ext Header. Undefined flags are set", Convert.ToString(flagByte, 2), DateTime.Now);            
        }

        internal void ReadExtHeader(byte[] byteArray, int pointPosition)
        {


            this.size = this.GetSize(byteArray, pointPosition);
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
                this.ReadRestrictions();
            }
        }

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

        private void ReadRestrictions()
        {
            throw new NotImplementedException();
        }

        
    }
}
