using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubStringSearch
{
    class KnuthMorrisPatt
    {
        private int[,] dfa;
        private string pattern;
        private int M;
        private int R = 256;

        public KnuthMorrisPatt(string pattern)
        {
            this.pattern = pattern;
            M = pattern.Length;
            dfa = new int[R, M];
            dfa[pattern[0], 0] = 1;
            for (int X = 0, j = 1; j < M; j++)
            {
                for (int c = 0; c < R; c++)
                {
                    dfa[c, j] = dfa[X, j]; // Copy mismatch
                }

                dfa[pattern[j], j] = j + 1; // Set match case

                X = dfa[pattern[j], X]; // Update restart state
            }
        }

        public int Search(string text)
        {
            int N = text.Length;
            int i, j;

            for (i = 0, j = 0; i < N && j < M; i++)
            {
                j = dfa[text[i], j];              
            }

            if (j == M)
            {
                return i - M;
            }

            return N;
        }
    }
}
