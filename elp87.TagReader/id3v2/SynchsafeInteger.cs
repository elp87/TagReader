﻿using System;

namespace elp87.TagReader
{
    namespace id3v2
    {
        public class SynchsafeInteger
        {
            #region Fields
            private byte[] _synchsafeByte;
            #endregion

            #region Constructors
            public SynchsafeInteger()
            {
            }

            public SynchsafeInteger(byte[] synchsafeByte)
            {
                _synchsafeByte = PrepareByte(synchsafeByte);
            }            

            public SynchsafeInteger(int syncsafeInt)
            {
                _synchsafeByte = synchsafeIntToSynchsafeByte(syncsafeInt);
                Array.Reverse(_synchsafeByte);
            }
            #endregion

            #region Properties
            public int SynchSafeInt
            {
                get
                {
                    return BitConverter.ToInt32(_synchsafeByte, 0);
                }
            }
            #endregion

            #region Methods
            #region Public
            public int ToInt()
            {
                return (_synchsafeByte[3] & 0x7f) |
                    (_synchsafeByte[2] & 0x7f) << 7 |
                    (_synchsafeByte[1] & 0x7f) << 14 |
                    (_synchsafeByte[0] & 0x7f) << 21;
            }
            #endregion

            #region Private
            private byte[] synchsafeIntToSynchsafeByte(int syncsafeInt)
            {
                return BitConverter.GetBytes(syncsafeInt);
            }

            private byte[] PrepareByte(byte[] synchsafeByte)
            {
                byte[] returnByteArray = new byte[4];
                int length = synchsafeByte.Length;
                if (length > 4) { throw new Exceptions.InvalidSynchSafeInt32Exception("Invalid Synchsafe Integer Byte Array", "Length of byte array is more then 4 bytes", DateTime.Now); }
                if (length == 0) { throw new Exceptions.InvalidSynchSafeInt32Exception("Invalid Synchsafe Integer Byte Array", "Byte array in NULL", DateTime.Now); }
                else
                {
                    if (length == 1) { returnByteArray = new byte[4] {0, 0, 0, synchsafeByte[0]}; }
                    if (length == 2) { returnByteArray = new byte[4] {0, 0, synchsafeByte[0], synchsafeByte[1]}; }
                    if (length == 3) { returnByteArray = new byte[4] {0, synchsafeByte[0], synchsafeByte[1], synchsafeByte[2] }; }
                    if (length == 4) { returnByteArray = synchsafeByte; }
                }
                return returnByteArray;
            }
            #endregion
            #endregion
        }
    }
}
