using BenchmarkDotNet.Attributes;

namespace MatrixAdd;

// Тут використано бібліотеку Benchmark для порівняння послідовного і паралельного додавання матриць.

// Для запуску потрібно обов'язков переключити режим з Debug на Release! Також потрібно встановити пакет
// BenchmarkDotNet з NuGet!

// Оскільки тут задано великі числа розмірності матриці і сама бібліотека проганяє не мало ітерацій,
// то аналіз буде відбуватися трішки довго(після кожного тесту видно скільки тестів залишилось,
// і орієновний час завершення тестування).
// Після завершення з'явиться таблиця, де буде видно, який метод працював з якою розмірністю і скільки часу
// це зайняло(кількість часу це стовпець Mean). Сам запуск цих тестів розміщений у файлі Program.cs у функції Main.
// У файлі "Висновки" наведено результати, котрі я отримала під час тестування.
[MemoryDiagnoser]
public class MatrixBenchmark
{
    private MatrixOperations matrixOps;

    [Params(1000, 5000, 10000, 15000)]
    public int Size { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        matrixOps = new MatrixOperations(Size, Size);
    }

    // тестування послідовного додавання
    [Benchmark(Baseline = true)]
    public void SequentialAddBenchmark()
    {
        matrixOps.SequentialAdd();
    }

    // тестування паралельного додавання
    [Benchmark]
    public void ParallelAddBenchmark()
    {
        matrixOps.ParallelAdd();
    }
}