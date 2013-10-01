using System;

namespace elp87.TagReader.id3v2
{
    public abstract class Synchsafe
    {
        #region Fields
        protected byte[] _synchsafeByte;
        #endregion

        public Synchsafe() { }
        public Synchsafe(byte[] synchsafeByte) 
        {
            this._synchsafeByte = synchsafeByte;
        }

        #region Properties
        public int SynchSafeInt
        {
            get
            {

                return BitConverter.ToInt32(ByteArray.Reverse(_synchsafeByte), 0);
            }
        }
        #endregion

        public abstract int ToInt();

        protected byte[] synchsafeIntToSynchsafeByte(int syncsafeInt)
        {
            return BitConverter.GetBytes(syncsafeInt);
        }

        protected byte[] synchsafeIntToSynchsafeByte(long syncsafeLong)
        {
            return BitConverter.GetBytes(syncsafeLong);
        }

    }

    public class SynchsafeInteger
        : Synchsafe
    {
        #region Constructors
        public SynchsafeInteger()
            : base() { }

        public SynchsafeInteger(byte[] synchsafeByte)            
        {
            _synchsafeByte = PrepareByte(synchsafeByte);
        }

        public SynchsafeInteger(int syncsafeInt)
        {
            _synchsafeByte = ByteArray.Reverse(synchsafeIntToSynchsafeByte(syncsafeInt));
        }
        #endregion

        #region Methods
        #region Public
        public override int ToInt()
        {
            int val = (_synchsafeByte[3] & 0x7f) |
                (_synchsafeByte[2] & 0x7f) << 7 |
                (_synchsafeByte[1] & 0x7f) << 14 |
                (_synchsafeByte[0] & 0x7f) << 21;
            return val;
        }
        #endregion

        #region Private
        

        private byte[] PrepareByte(byte[] synchsafeByte)
        {
            byte[] returnByteArray = new byte[4];
            int length = synchsafeByte.Length;
            if (length > 4) { throw new Exceptions.InvalidSynchSafeInt32Exception("Invalid Synchsafe Integer Byte Array", "Length of byte array is more then 4 bytes", DateTime.Now); }
            if (length == 0) { throw new Exceptions.InvalidSynchSafeInt32Exception("Invalid Synchsafe Integer Byte Array", "Byte array in NULL", DateTime.Now); }
            else
            {
                if (length == 1) { returnByteArray = new byte[4] { 0, 0, 0, synchsafeByte[0] }; }
                if (length == 2) { returnByteArray = new byte[4] { 0, 0, synchsafeByte[0], synchsafeByte[1] }; }
                if (length == 3) { returnByteArray = new byte[4] { 0, synchsafeByte[0], synchsafeByte[1], synchsafeByte[2] }; }
                if (length == 4) { returnByteArray = synchsafeByte; }
            }
            return returnByteArray;
        }
        #endregion
        #endregion
    }

    public class SynchsafeCRC
        : Synchsafe
    {
        public SynchsafeCRC()
            : base() { }

        public SynchsafeCRC(byte[] synchsafeByte)
            : base(synchsafeByte)
        {
            if (synchsafeByte.Length != 5) throw new Exceptions.InvalidSynchSafeInt32Exception("Invalid Synchsafe CRC Byte Array", "Length of byte array should be 5 bytes", DateTime.Now);
        }

        public SynchsafeCRC(long SyncsafeLong)
        {
            _synchsafeByte = ByteArray.Reverse(synchsafeIntToSynchsafeByte(SyncsafeLong));
        }

        public override int ToInt()
        {
            return (_synchsafeByte[4] & 0x7f) |
                (_synchsafeByte[3] & 0x7f) << 7 |
                (_synchsafeByte[2] & 0x7f) << 14 |
                (_synchsafeByte[1] & 0x7f) << 21 |
                (_synchsafeByte[0] & 0x7f) << 28;
        }

        public byte[] ToByte()
        {            
            int cleanInt = this.ToInt();
            return ByteArray.Reverse(BitConverter.GetBytes(cleanInt));
        }
    }

}
