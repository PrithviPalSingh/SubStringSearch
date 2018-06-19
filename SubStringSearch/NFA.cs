using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubStringSearch
{
    class NFA
    {
        private char[] re; //match transitions
        private DiaGraphAPI G; // Epsilon transition digraph
        private int M;

        public NFA(string regExp)
        {
            M = regExp.Length;
            re = regExp.ToCharArray();
            G = BuildEpsilonTransitionDiGraph();
        }

        public bool Recongnizes(string txt)
        {
            IList<int> pc = new List<int>();
            DirectedDFS dfs = new DirectedDFS(G, 0);

            for (int v = 0; v < G.V; v++)
            {
                if (dfs.Marked[v])
                {
                    pc.Add(v);
                }
            }

            for (int i = 0; i < txt.Length; i++)
            {
                IList<int> match = new List<int>();
                foreach (var v in pc)
                {
                    if (v == M)
                        continue;

                    if ((re[v] == txt[i]) || re[v] == '.')
                    {
                        match.Add(v + 1);
                    }
                }

                dfs = new DirectedDFS(G, match);
                pc = new List<int>();
                for (int v = 0; v < G.V; v++)
                {
                    if (dfs.Marked[v])
                    {
                        pc.Add(v);
                    }
                }
            }

            foreach (var v in pc)
            {
                if (v == M)
                    return true;
            }

            return false;
        }

        public DiaGraphAPI BuildEpsilonTransitionDiGraph()
        {
            DiaGraphAPI G = new DiaGraphAPI(M + 1);
            Stack<int> ops = new Stack<int>();

            for (int i = 0; i < M; i++)
            {
                int lp = i;

                if (re[i] == '(' || re[i] == '|')
                {
                    ops.Push(i);
                }
                else if (re[i] == ')')
                {
                    int or = ops.Pop();
                    if (re[or] == '|')
                    {
                        lp = ops.Pop();
                        G.AddEdge(lp, or + 1);
                        G.AddEdge(or, i);
                    }
                    else
                    {
                        lp = or;
                    }
                }

                if (i < M - 1 && re[i + 1] == '*')
                {
                    G.AddEdge(lp, i + 1);
                    G.AddEdge(i + 1, lp);
                }

                if (re[i] == '(' || re[i] == '*' || re[i] == ')')
                {
                    G.AddEdge(i, i + 1);
                }
            }

            return G;
        }
    }
}
