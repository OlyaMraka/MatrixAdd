```

BenchmarkDotNet v0.15.2, Windows 10 (10.0.19045.6216/22H2/2022Update)
Intel Core i5-4300U CPU 1.90GHz (Max: 2.49GHz) (Haswell), 1 CPU, 4 logical and 2 physical cores
.NET SDK 9.0.201
  [Host]     : .NET 9.0.3 (9.0.325.11113), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.3 (9.0.325.11113), X64 RyuJIT AVX2


```
| Method                 | Size  | Mean         | Error      | StdDev     | Median       | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|----------:|------------:|
| **SequentialAddBenchmark** | **1000**  |     **5.193 ms** |  **0.1055 ms** |  **0.2994 ms** |     **5.108 ms** |  **1.00** |    **0.08** |         **-** |          **NA** |
| ParallelAddBenchmark   | 1000  |     3.476 ms |  0.0687 ms |  0.0643 ms |     3.472 ms |  0.67 |    0.04 |     856 B |          NA |
|                        |       |              |            |            |              |       |         |           |             |
| **SequentialAddBenchmark** | **5000**  |   **127.020 ms** |  **2.5356 ms** |  **3.0184 ms** |   **126.818 ms** |  **1.00** |    **0.03** |         **-** |          **NA** |
| ParallelAddBenchmark   | 5000  |    82.583 ms |  1.1675 ms |  1.0350 ms |    82.423 ms |  0.65 |    0.02 |     856 B |          NA |
|                        |       |              |            |            |              |       |         |           |             |
| **SequentialAddBenchmark** | **10000** |   **515.428 ms** | **10.1939 ms** | **24.2269 ms** |   **508.993 ms** |  **1.00** |    **0.06** |         **-** |          **NA** |
| ParallelAddBenchmark   | 10000 |   329.629 ms |  6.5898 ms | 10.4521 ms |   328.370 ms |  0.64 |    0.04 |     856 B |          NA |
|                        |       |              |            |            |              |       |         |           |             |
| **SequentialAddBenchmark** | **15000** | **1,219.765 ms** | **30.4982 ms** | **88.4807 ms** | **1,207.522 ms** |  **1.01** |    **0.10** |         **-** |          **NA** |
| ParallelAddBenchmark   | 15000 |   725.297 ms | 13.9339 ms | 17.6219 ms |   719.311 ms |  0.60 |    0.04 |     856 B |          NA |
