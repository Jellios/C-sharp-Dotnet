using System;
using System.Diagnostics;

class Program
{
    static void Ding()
    {
        int[] numbers = Enumerable.Range(1, 10000).ToArray();
        foreach (int number in numbers)
        {
            int sumOfSquares = number * number;
            Console.WriteLine($"Sum of squares of {number} is {sumOfSquares}");
        }
    }
    static void Main()
    {

  Stopwatch stopwatch2 = Stopwatch.StartNew();
        Task taskA = Task.Run(Ding);
        stopwatch2.Stop();
        Stopwatch stopwatch = Stopwatch.StartNew();
       Ding();
        stopwatch.Stop();
        Task.WaitAll(taskA);
        Console.WriteLine($"Time taken without threading\t: {stopwatch.ElapsedMilliseconds} ms");
          Console.WriteLine($"Time taken with threading\t: {stopwatch2.ElapsedMilliseconds} ms");
    }
}
