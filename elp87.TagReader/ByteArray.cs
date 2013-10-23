namespace elp87.TagReader
{
    /// <summary>
    /// Provides static methods for byte arrays
    /// </summary>
    public static class ByteArray
    {
        /// <summary>
        /// String terminator for one-byte char encodings
        /// </summary>
        public const byte Terminator = 0x00;

        /// <summary>
        /// String terminator for double-byte char encodings
        /// </summary>
        public static readonly byte[] TerminatorArray = new byte[] { 0x00, 0x00 };

        /// <summary>
        /// Returns the zero-based index of the first occurrence of a byte-array mask within a byte-array. The method returns -1 if mask is not found in byte-array.
        /// </summary>
        /// <param name="byteArray">The byte array where the search is conducted.</param>
        /// <param name="mask">The byte array which is searched in the array.</param>
        /// <returns>The zero-based index position of first byte of mask in the byte-array.</returns>
        /// <remarks>
        /// <para>Index numbering starts from zero.</para>
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// using elp87.TagReader;
        /// using System;
        ///
        /// namespace Example
        /// {
        ///     class Program
        ///     {
        ///         static void Main(string[] args)
        ///         {            
        ///             byte[] array = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C };
        ///             byte[] mask = new byte[] { 0x03, 0x04, 0x05 };
        /// 
        ///             int index = ByteArray.FindSubArray(array, mask);
        /// 
        ///             Console.WriteLine(index);
        ///         }
        ///     }
        /// }
        /// // The example displays the following output: 
        /// //       3
        /// </code>
        /// </example>
        public static int FindSubArray(byte[] byteArray, byte[] mask)
        {
            int index = -1;
            int maskLength = mask.Length;
            int arrayLength = byteArray.Length;

            for (int i = 0; i < arrayLength; i++)
            {
                if (byteArray[i] == mask[0])
                {
                    int equityFullness = 1;
                    index = i;
                    while (equityFullness > 0)
                    {
                        if (i + equityFullness >= arrayLength) { return -1; }
                        if (byteArray[i + equityFullness] == mask[equityFullness]) { equityFullness++; }
                        else { equityFullness = -1; }
                        if (equityFullness == maskLength) { return index; }
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// Returns reverse copy of byte-array.
        /// </summary>
        /// <param name="byteArray">Original array.</param>
        /// <returns>Reverse copy of byte-array</returns>
        /// <remarks>
        /// This method returns new instance of <see cref="System.Byte"/> array, it does not reverse original instance as <see cref="M:System.Array.Reverse(System.Array)"/>
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// using elp87.TagReader;
        /// using System;
        ///
        /// namespace Example
        /// {
        ///     class Program
        ///     {
        ///         static void Main(string[] args)
        ///         {
        ///             byte[] array = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        ///             byte[] reverse = ByteArray.Reverse(array);
        ///
        ///             foreach (byte b in reverse)
        ///             {
        ///                 Console.Write("{0}, ", b);
        ///             }
        ///         }
        ///     }
        /// }
        /// // The example displays the following output:
        /// // 9, 8, 7, 6, 5, 4, 3, 2, 1, 0,
        /// </code>
        /// </example>
        /// <seealso cref="M:System.Array.Reverse(System.Array)"/>
        /// <seealso cref="O:System.Array.Reverse"/>
        public static byte[] Reverse(byte[] byteArray)
        {
            int length = byteArray.Length;
            byte[] reverseArray = new byte[length];
            int index = 0;
            for (int i = length - 1; i >= 0; i--)
            {
                reverseArray[index] = byteArray[i];
                index++;
            }
            return reverseArray;
        }


    }
}
