using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubStringSearch
{
    class RabinKarp
    {
        private long patHash;
        private int M;
        private long Q;
        private int R;
        private long RM;

        public RabinKarp(string pattern)
        {
            M = pattern.Length;
            R = 256;
            Q = 997;

            RM = 1;

            for (int i = 1; i <= M - 1; i++)
            {
                RM = (R * RM) % Q;
            }

            patHash = Hash(pattern, M);
        }

        public int Search(string txt)
        {
            int N = txt.Length;
            long txtHash = Hash(txt, M);
            if (patHash == txtHash)
                return 0;

            for (int i = M; i < N; i++)
            {
                txtHash = (txtHash + Q - ((RM * txt[i - M]) % Q)) % Q;
                txtHash = (txtHash * R + txt[i]) % Q;

                if (patHash == txtHash)
                    return i - M + 1;
            }

            return N;
        }

        private long Hash(string key, int M)
        {
            long h = 0;

            for (int j = 0; j < M; j++)
            {
                h = (R * h + key[j]) % Q;
            }

            return h;
        }
    }
}
