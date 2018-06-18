using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubStringSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            BruteForceWay bfw = new BruteForceWay();
            int startIndex = bfw.FirstSearchImplementation("AABBCCDD", "CCD");
            if (startIndex == "AABBCCDD".Length)
                Console.WriteLine("Not found");
            else
                Console.WriteLine($"Start Index: {startIndex} <<>> End Index: {startIndex + "CCD".Length}");

            int stIndex = bfw.FirstSearchImplementation("AABBCCDD", "CCD");
            if (stIndex == "AABBCCDD".Length)
                Console.WriteLine("Not found");
            else
                Console.WriteLine($"Start Index: {stIndex} <<>> End Index: {stIndex + "CCD".Length}");

            KnuthMorrisPatt kmp = new KnuthMorrisPatt("CCD");
            int kmpStIndex = kmp.Search("AABBCCDD");
            if (kmpStIndex == "AABBCCDD".Length)
                Console.WriteLine("Not found");
            else
                Console.WriteLine($"Start Index: {kmpStIndex} <<>> End Index: {kmpStIndex + "CCD".Length}");

            BoyreMooreSearchAlgo bm = new BoyreMooreSearchAlgo();
            int bmIndex = bm.Search("AABBCCDD", "CCD");
            if (bmIndex == "AABBCCDD".Length)
                Console.WriteLine("Not found");
            else
                Console.WriteLine($"Start Index: {bmIndex} <<>> End Index: {bmIndex + "CCD".Length}");

            RabinKarp rk = new RabinKarp("CCD");
            int rkIndex = rk.Search("AABBCCDD");
            if (rkIndex == "AABBCCDD".Length)
                Console.WriteLine("Not found");
            else
                Console.WriteLine($"Start Index: {rkIndex} <<>> End Index: {rkIndex + "CCD".Length}");

            Console.Read();
        }
    }
}
