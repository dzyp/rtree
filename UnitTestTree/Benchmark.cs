using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestTree
{
    class Benchmark
    {
        public static void Profile(string description, int iterations, Action func)
        {
            // warm up 
            func();

            var watch = new Stopwatch();

            // clean up
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            watch.Start();
            for (int i = 0; i < iterations; i++)
            {
                func();
            }
            watch.Stop();
            Debug.Write(description);
            Debug.WriteLine(" Iteration: {0}, Time: {1} ms", iterations, watch.Elapsed.TotalMilliseconds / iterations);
        }
    }
}
