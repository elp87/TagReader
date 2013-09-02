
namespace elp87.TagReader
{
    public static class ByteArray
    {
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
                    for (int j = 1; j < maskLength; j++)
                    {
                        if (byteArray[i + j] == mask[j]) { equityFullness++; }
                        if (equityFullness == maskLength) { return index; }                        
                    }
                }
            }
            return -1;
        }

        
    }
}
