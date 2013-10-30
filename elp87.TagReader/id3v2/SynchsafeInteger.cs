using System;

namespace elp87.TagReader.id3v2
{
    /// <summary>
    /// An abstract base class that provides functionality for synchsafe integers
    /// </summary>
    /// <remarks>
    /// <para>In a synchsafe integer, the most significant bit of each byte is zero, making seven bits out of eight available. 
    /// So, for example, a 32-bit synchsafe integer can only store 28 bits of information.</para>
    /// <para>Examples:</para>
    /// <para>(%11111111) is encoded as a 16-bit synchsafe integer (%00000001 01111111).</para>
    /// <para>(%11111111 11111111) is encoded as a 24-bit synchsafe integer (%00000011 01111111 01111111).</para>
    /// </remarks>
    public abstract class Synchsafe
    {
        #region Fields
        /// <summary>
        /// Synchsafe integer represented as byte array
        /// </summary>
        protected byte[] _synchsafeByte;
        #endregion

        /// <summary>
        /// Inheritable constructor for <see cref="elp87.TagReader.id3v2.Synchsafe"/> class
        /// </summary>
        public Synchsafe() { }

        /// <summary>
        /// Inheritable constructor for <see cref="elp87.TagReader.id3v2.Synchsafe"/> class with reading synchsafe byte array
        /// </summary>
        /// <param name="synchsafeByte">Synchsafe integer represented as byte array</param>
        public Synchsafe(byte[] synchsafeByte)
        {
            this._synchsafeByte = synchsafeByte;
        }

        #region Properties
        /// <summary>
        /// Gets Syncsafe value.
        /// </summary>
        public int SynchSafeInt
        {
            get
            {

                return BitConverter.ToInt32(ByteArray.Reverse(_synchsafeByte), 0);
            }
        }
        #endregion

        /// <summary>
        /// Returns converted value.
        /// </summary>
        /// <returns></returns>
        public abstract int ToInt();

        /// <summary>
        /// Returns byte array respective synchsafe from synchsafe integer.
        /// </summary>
        /// <param name="syncsafeInt">Syncsafe value.</param>
        /// <returns>byte array respective synchsafe</returns>
        /// <overloads>Returns Byte array respective synchsafe from synchsafe value</overloads>
        protected byte[] synchsafeIntToSynchsafeByte(int syncsafeInt)
        {
            return BitConverter.GetBytes(syncsafeInt);
        }

        /// <summary>
        /// Returns byte array respective synchsafe from synchsafe long integer.
        /// </summary>
        /// <param name="syncsafeLong">Syncsafe value.</param>
        /// <returns>Byte array respective synchsafe</returns>
        protected byte[] synchsafeIntToSynchsafeByte(long syncsafeLong)
        {
            return BitConverter.GetBytes(syncsafeLong);
        }

    }

    /// <summary>
    /// This class represents 32bit synchsafe integer value
    /// </summary>
    public class SynchsafeInteger
        : Synchsafe
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="elp87.TagReader.id3v2.SynchsafeInteger"/> class.
        /// </summary>
        public SynchsafeInteger()
            : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="elp87.TagReader.id3v2.SynchsafeInteger"/> class from synchsafe byte array.
        /// </summary>
        /// <param name="synchsafeByte">Synchsafe byte array</param>
        /// <exception cref="elp87.TagReader.id3v2.Exceptions.InvalidSynchSafeInt32Exception">Byte array is 0 length or more then 4.</exception>
        /// <remarks>
        /// Byte array should be 4 byte length or less, but more then 0 byte.
        /// If first bytes are 0, it could be omited. I.e. byte array <c>{0, 0, 63, 17}</c> is equal <c>{63, 17}</c>
        /// <code lang="C#">
        /// byte[] ssByte0 = { 0, 0, 63, 17 };
        /// byte[] ssByte1 = { 63, 17 };
        /// SynchsafeInteger ssInt0 = new SynchsafeInteger(ssByte0);
        /// SynchsafeInteger ssInt1 = new SynchsafeInteger(ssByte1);
        /// int value0 = ssInt0.ToInt();
        /// int value1 = ssInt1.ToInt();
        /// Console.WriteLine("value0 = {0}", value0);
        /// Console.WriteLine("value1 = {0}", value1);
        /// // value0 = 8081
        /// // value1 = 8081
        /// </code>
        /// </remarks>
        public SynchsafeInteger(byte[] synchsafeByte)
        {
            _synchsafeByte = PrepareByte(synchsafeByte);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="elp87.TagReader.id3v2.SynchsafeInteger"/> class from 32bit synchsafe integer value.
        /// </summary>
        /// <param name="syncsafeInt">32bit synchsafe integer value.</param>
        public SynchsafeInteger(int syncsafeInt)
        {
            _synchsafeByte = ByteArray.Reverse(synchsafeIntToSynchsafeByte(syncsafeInt));
        }
        #endregion

        #region Methods
        #region Public
        /// <summary>
        /// Convert syncsafe value of current instance to 32bit integer and returns this value.
        /// </summary>
        /// <returns>Simple 32bit integer value</returns>
        /// <example>
        /// <code lang="C#">
        /// byte[] ssByte = { 0, 9, 63, 17 };
        /// SynchsafeInteger ssInt = new SynchsafeInteger(ssByte);
        /// int value = ssInt.ToInt();
        /// Console.WriteLine("value = {0}", value);
        /// // value = 155537;
        /// </code>
        /// <para>In this example synchsafe byte array is converted to 32bit integer value.
        /// Syncsafe byte array is 0, 9, 63, 17.</para>
        /// <para>In bit representation it is</para>
        /// <para>0 - 0 0000000</para>
        /// <para>9 - 0 0001001</para>
        /// <para>63 - 0 0111111</para>
        /// <para>17 - 0 0010001</para>
        /// <para>Excluding first bits of each value it will be mean 0000000 0001001 0111111 0010001.
        /// In decimal representation this value is 155537.</para>
        /// </example>
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

    /// <summary>
    /// This class represents 32bit CRC value stored as 35 bit synchsafe integer
    /// </summary>
    public class SynchsafeCRC
        : Synchsafe
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="elp87.TagReader.id3v2.SynchsafeCRC"/> class.
        /// </summary>
        public SynchsafeCRC()
            : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="elp87.TagReader.id3v2.SynchsafeCRC"/> class from synchsafe byte array.
        /// </summary>
        /// <param name="synchsafeByte">Synchsafe byte array</param>
        /// <exception cref="elp87.TagReader.id3v2.Exceptions.InvalidSynchSafeInt32Exception">Synchsafe byte array length should be 5 byte</exception>
        /// <remarks>Length of synchsafe byte array should be 5 byte. First 5 bit should be zeroed.</remarks>
        public SynchsafeCRC(byte[] synchsafeByte)
            : base(synchsafeByte)
        {
            if (synchsafeByte.Length != 5) throw new Exceptions.InvalidSynchSafeInt32Exception("Invalid Synchsafe CRC Byte Array", "Length of byte array should be 5 bytes", DateTime.Now);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="elp87.TagReader.id3v2.SynchsafeCRC"/> class from 64-bit synchsafe integer value.
        /// </summary>
        /// <param name="SyncsafeLong">64bit synchsafe integer value.</param>
        public SynchsafeCRC(long SyncsafeLong)
        {
            _synchsafeByte = ByteArray.Reverse(synchsafeIntToSynchsafeByte(SyncsafeLong));
        }

        /// <summary>
        /// Convert syncsafe value of current instance to 32bit integer and returns this value.
        /// </summary>
        /// <returns>Simple 32bit integer value</returns>
        /// <seealso cref="elp87.TagReader.id3v2.SynchsafeInteger.ToInt()">SynchsafeInteger.ToInt()</seealso>
        public override int ToInt()
        {
            return (_synchsafeByte[4] & 0x7f) |
                (_synchsafeByte[3] & 0x7f) << 7 |
                (_synchsafeByte[2] & 0x7f) << 14 |
                (_synchsafeByte[1] & 0x7f) << 21 |
                (_synchsafeByte[0] & 0x7f) << 28;
        }

        /// <summary>
        /// Convert syncsafe value of current instance to byte array.
        /// </summary>
        /// <returns>Byte array.</returns>
        public byte[] ToByte()
        {
            int cleanInt = this.ToInt();
            return ByteArray.Reverse(BitConverter.GetBytes(cleanInt));
        }
    }

}
