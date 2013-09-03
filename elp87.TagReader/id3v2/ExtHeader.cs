﻿using System;

namespace elp87.TagReader.id3v2
{
    public class ExtHeader
    {
        private bool _update;
        private bool _isCRC;
        private bool _restrictions;
        private int _CRC;

        public int size { get; set; }
        public bool isUpdate { get { return _update; } }
        public bool isCRC { get { return _isCRC; } }
        public bool isRestrictions { get { return _restrictions; } }

        public int CRC { get { return _CRC; } }

        internal void ParseFlagField(byte flagByte)
        {
            _update = Convert.ToBoolean((flagByte & 0x40) >> 6);
            _isCRC = Convert.ToBoolean((flagByte & 0x20) >> 5);
            _restrictions = Convert.ToBoolean((flagByte & 0x10) >> 4);
            if ((flagByte & 0x8F) != 0) throw new Exceptions.NotUsableFlagException("Invalid flag field in Ext Header. Undefined flags are set", Convert.ToString(flagByte, 2), DateTime.Now);            
        }

        internal void ReadExtHeader(byte[] byteArray, int pointPosition)
        {
            
            byte[] extHeaderSizeArray = new byte[4];
            Array.Copy(byteArray, pointPosition, extHeaderSizeArray, 0, 4);
            SynchsafeInteger ssSize = new SynchsafeInteger(extHeaderSizeArray);
            this.size = ssSize.ToInt();
            pointPosition += 4; // Сдвиг после размера
            pointPosition += 1; // 0x01 - Кол-во байт флага
            this.ParseFlagField(byteArray[pointPosition]);
            pointPosition += 1; // Сдвиг после поля флагов
            if (this._isCRC)
            {
                pointPosition += 1; // 0x05 - Кол-во байт флага
                ReadCRC(byteArray, pointPosition);
                pointPosition += 5; // Сдвиг после поля CRC
            }
        }

        private void ReadCRC(byte[] byteArray, int pointPosition)
        {
            byte[] CRCbyte = new byte[5];
            Array.Copy(byteArray, pointPosition, CRCbyte, 0, 5);
            SynchsafeCRC CRCField = new SynchsafeCRC(CRCbyte);
            this._CRC = CRCField.ToInt();
        }

        

        
    }
}
