using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using System;
using System.Text;

namespace BenchmarkerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var results = BenchmarkRunner.Run<Demo>();
        }
    }

    [SimpleJob(RuntimeMoniker.Net50, baseline:true)]
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [SimpleJob(RuntimeMoniker.Net472)]
    [MemoryDiagnoser]
    public class Demo
    {
        [Benchmark(Baseline =true)]
        public string GetFullStringNormally()
        {
            string output = "";
            for (int i = 0; i < 100; i++)
            {
                output += i;
            }

            return output;
        }


        [Benchmark]
        public string GetFullStringNormally2()
        {
            var output = new StringBuilder();
            for (int i = 0; i < 100; i++)
            {
                output.Append(i);
            }

            return output.ToString();
        }
    }
}
