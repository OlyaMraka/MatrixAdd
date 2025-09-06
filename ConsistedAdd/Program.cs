using System.Diagnostics;

namespace ConsistedAdd;
public class MatrixOperations
{
    public int[,] A, B, C;
    public int n, m;
    public MatrixOperations(int n, int m, int k = 4)
    {
        this.n = n;
        this.m = m;

        A = GenerateMatrix(n, m);
        B = GenerateMatrix(n, m);
        C = new int[n, m];
    }

    // Це функція яка додає матриці послідовно, створена для порівняння з паралельним підходом
    public void SequentialAdd()
    {
        for (int i = 0; i < n; i++)
        for (int j = 0; j < m; j++)
            C[i, j] = A[i, j] + B[i, j];
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
        MatrixOperations matrixOps = new MatrixOperations(30000, 30000);
        
        Console.WriteLine("---> Послідовне додавання <---");
        Stopwatch swSequential = Stopwatch.StartNew();
        matrixOps.SequentialAdd();
        swSequential.Stop();
        Console.WriteLine($" - Послідовне обчислення завершено за {swSequential.ElapsedMilliseconds} мс");
    }
}