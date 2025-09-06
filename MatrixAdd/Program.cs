using BenchmarkDotNet.Running;
using System.Diagnostics;

namespace MatrixAdd;

class Program
{
    // Щоб відтворити аналіз бібліотекою BenchMark потрібно розкоментувати 11, 12 рядки
    static void Main(string[] args)
    {
        // Console.WriteLine("Запуск бенчмарка...");
        // var summary = BenchmarkRunner.Run<MatrixBenchmark>();
        
        MatrixOperations matrixOps = new MatrixOperations(30000, 30000);
        
        // За допомогою бібліотеки System.Diagnostics спробувала порівняти різні підходи на максимальній розмірності,
        // яку витримає комп'ютер.
        Console.WriteLine("---> Паралельне додавання <---");
        Stopwatch swParallel = Stopwatch.StartNew();
        matrixOps.ParallelAdd();
        swParallel.Stop();
        Console.WriteLine($" - Паралельне обчислення завершено за {swParallel.ElapsedMilliseconds} мс\n");
        
        Console.WriteLine("---> Послідовне додавання <---");
        Stopwatch swSequential = Stopwatch.StartNew();
        matrixOps.SequentialAdd();
        swSequential.Stop();
        Console.WriteLine($" - Послідовне обчислення завершено за {swSequential.ElapsedMilliseconds} мс");
    }
}