using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubStringSearch
{
    class BruteForceWay
    {
        public int FirstSearchImplementation(string text, string pattern)
        {
            int N = text.Length;
            int M = pattern.Length;

            for (int i = 0; i < N - M; i++)
            {
                int j;
                for (j = 0; j < M; j++)
                {
                    if (text[i + j] != pattern[j])
                        break;
                }

                if (j == M)
                    return i;
            }

            return N;
        }

        public int SecondSearchImplentation(string text, string pattern)
        {
            int N = text.Length;
            int M = pattern.Length;
            int i, j;

            for (i = 0, j = 0; i < N - M; i++)
            {
                if (text[i] == pattern[j])
                {
                    j++;
                }
                else
                {
                    i -= j; // Backup is happening here
                    j = 0;
                }
            }

            if (j == M)
            {
                return i - M;
            }

            return N;
        }
    }
}
