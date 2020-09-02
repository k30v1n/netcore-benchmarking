# netcore-benchmarking

Repository to hold some benchmark tests using the https://github.com/dotnet/BenchmarkDotNet library.

## Content

1. [x] Perform benchmark of some code
2. [ ] Perform some unit tests over performance
3. [ ] Add docker support and run benchmarks over benchmark classes
    ```console
    dotnet tool install -g BenchmarkDotNet.Tool
    dotnet benchmark MyAssemblyWithBenchmarks.dll --filter *
    ```

## 1. Perform benchmark of some code

Testing the following methods, where N is the size of `Data` list.
```csharp
void LinqWhereAndCount() => Data.Where(x => x % 2 == 0).Count();
void LinqCount() => Data.Count(x => x % 2 == 0);
```

This code is on `Benchmark_Code.Program`. The results are the following:

`N = 10`
|            Method |     Mean |   Error |  StdDev |
|------------------ |---------:|--------:|--------:|
| LinqWhereAndCount | 108.6 ns | 1.77 ns | 1.66 ns |
|         LinqCount | 184.6 ns | 3.64 ns | 4.86 ns |


`N = 100`
|            Method |       Mean |    Error |   StdDev |
|------------------ |-----------:|---------:|---------:|
| LinqWhereAndCount |   504.2 ns |  9.35 ns | 13.70 ns |
|         LinqCount | 1,867.5 ns | 35.35 ns | 33.07 ns |


`N = 10,000`
|            Method |      Mean |    Error |   StdDev |
|------------------ |----------:|---------:|---------:|
| LinqWhereAndCount |  99.48 us | 1.928 us | 2.295 us |
|         LinqCount | 197.62 us | 3.847 us | 5.393 us |


`N = 50,000`
|            Method |     Mean |    Error |   StdDev |
|------------------ |---------:|---------:|---------:|
| LinqWhereAndCount | 497.7 us |  8.80 us |  8.23 us |
|         LinqCount | 982.3 us | 13.70 us | 12.81 us |


`N = 100,000`
|            Method |       Mean |    Error |   StdDev |
|------------------ |-----------:|---------:|---------:|
| LinqWhereAndCount |   974.1 us | 19.27 us | 18.02 us |
|         LinqCount | 1,937.9 us | 38.37 us | 53.79 us |

### Conclusion
This shows that is better use a `.Where(...).Count()` instead of `.Count(...)` as the second option has a increase on the processing time when the list size increases.


## Legends
- Mean   : Arithmetic mean of all measurements
- Error  : Half of 99.9% confidence interval
- StdDev : Standard deviation of all measurements
- 1 ns   : 1 Nanosecond (0.000000001 sec)
- 1 us   : 1 Microsecond (0.000001 sec)