using System;
using System.Diagnostics;

namespace Program
{

    public static class Ding
    {
        static Stopwatch stopWatch = new Stopwatch();
        static void MethodA()
        {
            Console.WriteLine("Starting Method A...");
            Thread.Sleep(3000); // simulate three seconds of work
            Console.WriteLine("Finished Method A.");
        }
        static void MethodB()
        {
            Console.WriteLine("Starting Method B...");
            Thread.Sleep(2000); // simulate two seconds of work
            Console.WriteLine("Finished Method B.");
        }
        static void MethodC()
        {
            Console.WriteLine("Starting Method C...");
            Thread.Sleep(1000); // simulate one second of work
            Console.WriteLine("Finished Method C.");
        }
        public static void Main()
        {
            {
                stopWatch.Start();
                Task taskA = new Task(MethodA);
                taskA.Start();
                Task taskB = Task.Run(MethodB);
                Task taskC = Task.Factory.StartNew(MethodC);
                Task[] tasks = { taskA, taskB, taskC };
                Task.WaitAll(tasks);
                Console.WriteLine("Time elapsed: {0}", stopWatch.ElapsedMilliseconds);
            }
        }
    }
}