using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter1.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SimpleParserTests.TestReturnsZeroWhenEmptyString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
