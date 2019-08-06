using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session16.Filters.Infrastructures
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string input)
        {
            Console.WriteLine("---------------------------Log Start---------------------------");
            Console.WriteLine(input);
            Console.WriteLine("---------------------------Log End---------------------------");

        }
    }
}
