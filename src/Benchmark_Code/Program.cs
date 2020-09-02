using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Benchmark_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running benchmark...");
            var summary = BenchmarkRunner.Run<LinqBenchmark>();
            Console.WriteLine("Finished.");

            Console.WriteLine(summary.ToString());
        }
    }

    public class LinqBenchmark
    {
        private const int CommonSeed = 1;
        private const int N = 50000;

        private readonly List<int> Data = new List<int>();

        public LinqBenchmark()
        {
            Random random = new Random(CommonSeed);

            while (Data.Count < N)
            {
                Data.Add(random.Next());
            }
        }

        [Benchmark]
        public void LinqWhereAndCount() => Data.Where(x => x % 2 == 0).Count();

        [Benchmark]
        public void LinqCount() => Data.Count(x => x % 2 == 0);
    }
}