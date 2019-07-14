using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Session10.Configuration.Infrastructures
{
    public class UptimeService
    {
        private Stopwatch stopwatch;
        public UptimeService()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        public long GetUptime { get
            {
                return stopwatch.ElapsedTicks;
            }
        }

    }
}
