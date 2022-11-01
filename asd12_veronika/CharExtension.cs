using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asd12_veronika
{
    internal static class CharExtension
    {
        public static bool IsVowel(this char ch) => (ch > 64) && ((VowelMask & (1 << ((ch | 0x20) % 32))) != 0);


        private const int VowelMask = (1 << 1) | (1 << 5) | (1 << 9) | (1 << 15) | (1 << 21);
    }
}
