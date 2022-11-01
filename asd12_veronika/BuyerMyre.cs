using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asd12_veronika
{
    public class BoyerMoore
    {
        public static int[] SearchString(string str, string pat)
        {
            var retVal = new List<int>();
            int m = pat.Length;
            int n = str.Length;

            var badChar = new int[256];

            BadCharHeuristic(pat, m, ref badChar);

            int s = 0;
            while (s <= n - m)
            {
                int j = m - 1;

                while (j >= 0 && pat[j] == str[s + j])
                {
                    --j;
                }

                if (j < 0)
                {
                    retVal.Add(s);
                    s += s + m < n ? m - badChar[str[s + m]] : 1;
                    continue;
                }

                s += Math.Max(1, j - badChar[str[s + j]]);
            }

            return retVal.ToArray();
        }
        private static void BadCharHeuristic(string str, int size, ref int[] badChar)
        {
            int i;

            for (i = 0; i < 256; i++)
                badChar[i] = -1;

            for (i = 0; i < size; i++)
                badChar[str[i]] = i;
        }
    }
}
