using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MemoryTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            p.CompareAndAddToResults_UsesLotsMemory();
        }

        public void CompareAndAddToResults_UsesLotsMemory()
        {
            Console.WriteLine("Go!");
            Thread.Sleep(5000);
            var resultsList = new List<Tuple<int, bool>>();
            string strVal1 = "This is my string that may or may not have the same caseness";
            string strVal2 = "This is my string that may or may not have the same casenesS";

            for (int i = 0; i < 10000000; i++)
            {
                var isEqual = strVal1.ToLower().Equals(strVal2.ToLower());
                resultsList.Add(new Tuple<int, bool>(i, isEqual));
            }
        }

        public void CompareAndAddToResultsBetter()
        {
            Console.WriteLine("Go!");
            Thread.Sleep(5000);
            var resultsList = new List<Tuple<int, bool>>();
            string strVal1 = "This is my string that may or may not have the same caseness";
            string strVal2 = "This is my string that may or may not have the same casenesS";

            for (int i = 0; i < 10000000; i++)
            {
                var isEqual = strVal1.Equals(strVal2, StringComparison.InvariantCultureIgnoreCase);
                resultsList.Add(new Tuple<int, bool>(i, isEqual));
            }
        }
    }
}
