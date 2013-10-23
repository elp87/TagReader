using System;

namespace elp87.TagReader
{
    /// <summary>
    /// Provides static methods for operations with bytes.
    /// </summary>
    public static class ByteOperation
    {
        /// <summary>
        /// Returns value of bit within byte.
        /// </summary>
        /// <param name="initByte">Byte</param>
        /// <param name="bitPosition">The zero-based index position of bit within byte. Position 0 is the least significant bit, position 7 is the most significant bit</param>
        /// <returns>Boolean value of bit</returns>
        /// <example>
        /// <code lang="C#">
        /// using elp87.TagReader;
        /// using System;
        /// namespace Example
        /// {
        ///     class Program
        ///     {
        ///         static void Main(string[] args)
        ///         {
        ///             byte init = 35; // 0010 0011
        ///             for (int i = 0; i &lt;= 8; i++)
        ///             {
        ///                 bool result = ByteOperation.GetBit(init, i);
        ///                 Console.WriteLine(result);
        ///             }
        ///         }
        ///     }
        /// }
        /// // The example displays the following output:
        /// // True
        /// // True
        /// // False
        /// // False
        /// // False
        /// // True
        /// // False
        /// // False
        /// </code>
        /// </example>
        /// <remarks>
        /// If bit position is out of byte, method returns "false".
        /// <code lang="C#">
        /// bool result = ByteOperation.GetBit(init, 9);
        /// </code>
        /// </remarks>
        public static bool GetBit(byte initByte, int bitPosition)
        {
            double order = Convert.ToDouble(bitPosition);
            int mask = (int)Math.Pow(2, order);
            return Convert.ToBoolean((initByte & mask) >> bitPosition);
        }
    }
}
