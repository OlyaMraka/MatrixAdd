using System.Diagnostics;

namespace ParallelAdd;

public class ParallelAddMatrix
{
    public int[,] A, B, C;
    public int n, m;
    private int currentRow;
    private object locker;
    private int k;

    public ParallelAddMatrix(int n, int m, int k = 4)
    {
        this.n = n;
        this.m = m;
        this.k = k;
        A = GenerateMatrix(n, m);
        B = GenerateMatrix(n, m);
        C = new int[n, m];
        currentRow = 0;
        locker = new object();
    }

    // Фцнкція, яка додає паралельно 
    public void ParallelAdd()
    {
        currentRow = 0;
        Thread[] threads = new Thread[k];

        // Створюємо k потоків у кожному з яких буде виконуватися функція ProcessRows
        for (int t = 0; t < k; t++)
        {
            threads[t] = new Thread(ProcessRows);
            threads[t].Start();
        }
        
        // тут для кожного потоку викликається метод Join, це потрібно для того щоб головний потік не закінчив роботу
        // швидше ніж якийсь з потоків для додавання. 
        for (int t = 0; t < k; t++)
            threads[t].Join();
    }

    // У цій функції береться наступний вільний рядок і додається.
    private void ProcessRows()
    {
        while (true)
        {
            int row;
            
            // У цьому моменті locker потрібний для того, щоб два потоки не захопили одночасно
            // один і той самий рядок!
            lock (locker)
            {
                if (currentRow >= n) return;
                row = currentRow;
                currentRow++;
            }

            // у цьому циклі обробляється рядок який захопив потік.
            for (int j = 0; j < m; j++)
                C[row, j] = A[row, j] + B[row, j];
        }
    }

    // Допоміжна функція призначена для генерації матриці
    private int[,] GenerateMatrix(int n, int m)
    {
        Random rnd = new Random();
        int[,] mat = new int[n, m];
        for (int i = 0; i < n; i++)
        for (int j = 0; j < m; j++)
            mat[i, j] = rnd.Next(1, 10);
        return mat;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(" -> Введіть кількість потоків: ");
        int k = int.Parse(Console.ReadLine()!);
        
        // За допомогою бібліотеки System.Diagnostics спробувала порівняти різні підходи на максимальній розмірності,
        // яку витримає комп'ютер.
        
        ParallelAddMatrix matrixOps = new ParallelAddMatrix(10000, 10000, k);
        Console.WriteLine("---> Паралельне додавання <---");
        Stopwatch swParallel = Stopwatch.StartNew();
        matrixOps.ParallelAdd();
        swParallel.Stop();
        Console.WriteLine($" - {k} Потоків: паралельне обчислення завершено за {swParallel.ElapsedMilliseconds} мс\n");
        
        matrixOps = new ParallelAddMatrix(10000, 10000, 2);
        Console.WriteLine("---> Паралельне додавання <---");
        swParallel = Stopwatch.StartNew();
        matrixOps.ParallelAdd();
        swParallel.Stop();
        Console.WriteLine($" - 2 Потоки: паралельне обчислення завершено за {swParallel.ElapsedMilliseconds} мс\n");
        
        matrixOps = new ParallelAddMatrix(10000, 10000, 8);
        Console.WriteLine("---> Паралельне додавання <---");
        swParallel = Stopwatch.StartNew();
        matrixOps.ParallelAdd();
        swParallel.Stop();
        Console.WriteLine($" - 8 Потоків: паралельне обчислення завершено за {swParallel.ElapsedMilliseconds} мс\n");
        
        matrixOps = new ParallelAddMatrix(10000, 10000, 13);
        Console.WriteLine("---> Паралельне додавання <---");
        swParallel = Stopwatch.StartNew();
        matrixOps.ParallelAdd();
        swParallel.Stop();
        Console.WriteLine($" - 13 Потоків: паралельне обчислення завершено за {swParallel.ElapsedMilliseconds} мс\n");
    }
}