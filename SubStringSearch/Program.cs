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

            Console.Read();
        }
    }
}
