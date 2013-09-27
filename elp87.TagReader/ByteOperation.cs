using System;

namespace elp87.TagReader
{
    public static class ByteOperation
    {
        public static bool GetBit(byte initByte, int bitPosition)
        {
            double order = Convert.ToDouble(bitPosition);
            int mask = (int)Math.Pow(2, order);
            return Convert.ToBoolean((initByte & mask) >> bitPosition);
        }        
    }
}
