using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubStringSearch
{
    class BoyreMooreSearchAlgo
    {
        int[] Right;

        int R = 256;


        public int Search(string txt, string pattern)
        {
            int N = txt.Length;
            int M = pattern.Length;
            int skip;

            PreComputeMismatch(pattern, M);

            for (int i = 0; i < N - M; i += skip)
            {
                skip = 0;

                for (int j = M - 1; j >= 0; j--)
                {
                    if (pattern[j] != txt[i + j])
                    {
                        skip = Math.Max(1, j - Right[txt[i + j]]);
                        break;
                    }
                }

                if (skip == 0)
                    return i;
            }

            return N;
        }

        /// <summary>
        /// Heart of this algorithm
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="M"></param>
        private void PreComputeMismatch(string pattern, int M)
        {
            Right = new int[R];
            for (int c = 0; c < R; c++)
            {
                Right[c] = -1;
            }

            for (int j = 0; j < M; j++)
            {
                Right[pattern[j]] = j;
            }
        }
    }
}
