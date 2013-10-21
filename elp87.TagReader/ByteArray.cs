namespace elp87.TagReader
{
    public static class ByteArray
    {
        public const byte Terminator = 0x00;
        public static readonly byte[] TerminatorArray = new byte[] { 0x00, 0x00 };

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
