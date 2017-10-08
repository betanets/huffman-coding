using System.Collections.Generic;

namespace Huffman
{
    public static class Helpers
    {
        public static byte[] PackBoolsInByteArray(List<bool> bools)
        {
            int len = bools.Count;
            int bytes = len >> 3;
            if ((len & 0x07) != 0) ++bytes;
            byte[] arr = new byte[bytes];
            for (int i = 0; i < bools.Count; i++)
            {
                if (bools[i])
                    arr[i >> 3] |= (byte)(1 << (i & 0x07));
            }
            return arr;
        }

        public static IEnumerable<bool> GetBitsStartingFromLSB(byte b)
        {
            for (int i = 0; i < 8; i++)
            {
                yield return (b % 2 == 0) ? false : true;
                b = (byte)(b >> 1);
            }
        }
    }
}
