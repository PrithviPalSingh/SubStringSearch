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
                Console.WriteLine($"Start Index: {stIndex} <<>> End Index: {startIndex + "CCD".Length}");

            Console.Read();
        }
    }
}
