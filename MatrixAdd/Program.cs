using BenchmarkDotNet.Running;

namespace MatrixAdd;

class Program
{
    // Щоб відтворити аналіз бібліотекою BenchMark потрібно розкоментувати 11, 12 рядки
    static void Main(string[] args)
    {
        Console.WriteLine("Запуск бенчмарка...");
        var summary = BenchmarkRunner.Run<MatrixBenchmark>();
    }
}