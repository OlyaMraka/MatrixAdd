```

BenchmarkDotNet v0.15.2, Windows 10 (10.0.19045.6216/22H2/2022Update)
Intel Core i5-4300U CPU 1.90GHz (Max: 2.49GHz) (Haswell), 1 CPU, 4 logical and 2 physical cores
.NET SDK 9.0.201
  [Host]     : .NET 9.0.3 (9.0.325.11113), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.3 (9.0.325.11113), X64 RyuJIT AVX2


```
| Method                 | Size  | Mean         | Error      | StdDev      | Median       | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------- |------ |-------------:|-----------:|------------:|-------------:|------:|--------:|----------:|------------:|
| **SequentialAddBenchmark** | **1000**  |     **5.511 ms** |  **0.1890 ms** |   **0.5238 ms** |     **5.318 ms** |  **1.01** |    **0.13** |         **-** |          **NA** |
| ParallelAddBenchmark   | 1000  |     4.250 ms |  0.2705 ms |   0.7847 ms |     3.980 ms |  0.78 |    0.16 |     856 B |          NA |
|                        |       |              |            |             |              |       |         |           |             |
| **SequentialAddBenchmark** | **5000**  |   **146.413 ms** |  **7.2299 ms** |  **20.8599 ms** |   **138.164 ms** |  **1.02** |    **0.19** |         **-** |          **NA** |
| ParallelAddBenchmark   | 5000  |    84.056 ms |  1.6796 ms |   2.1242 ms |    83.707 ms |  0.58 |    0.07 |     856 B |          NA |
|                        |       |              |            |             |              |       |         |           |             |
| **SequentialAddBenchmark** | **10000** |   **588.148 ms** | **29.4406 ms** |  **85.4125 ms** |   **561.089 ms** |  **1.02** |    **0.20** |         **-** |          **NA** |
| ParallelAddBenchmark   | 10000 |   372.365 ms | 21.8891 ms |  63.5043 ms |   346.288 ms |  0.64 |    0.14 |     856 B |          NA |
|                        |       |              |            |             |              |       |         |           |             |
| **SequentialAddBenchmark** | **15000** | **1,594.786 ms** | **80.7819 ms** | **236.9192 ms** | **1,595.365 ms** |  **1.02** |    **0.21** |         **-** |          **NA** |
| ParallelAddBenchmark   | 15000 |   709.857 ms |  5.1306 ms |   4.0056 ms |   711.421 ms |  0.45 |    0.07 |     856 B |          NA |
