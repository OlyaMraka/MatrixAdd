using MatrixAdd;

namespace MatrixAddTests
{
    public class MatrixOperationsTests
    {
        [Fact]
        public void SequentialAdd_Should_AddMatricesCorrectly()
        {
            int[,] A = new int[,]
            {
                {1, 2},
                {3, 4}
            };
            int[,] B = new int[,]
            {
                {5, 6},
                {7, 8}
            };
            var expected = new int[,]
            {
                {6, 8},
                {10, 12}
            };
            
            var matrixOps = new MatrixOperations(2, 2);
            matrixOps.A = A;
            matrixOps.B = B;
            
            matrixOps.SequentialAdd();
            
            Assert.Equal(expected, matrixOps.C);
        }

        [Fact]
        public void ParallelAdd_Should_AddMatricesCorrectly()
        {
            int[,] A = new int[,]
            {
                {1, 2},
                {3, 4}
            };
            int[,] B = new int[,]
            {
                {5, 6},
                {7, 8}
            };
            var expected = new int[,]
            {
                {6, 8},
                {10, 12}
            };
            
            var matrixOps = new MatrixOperations(2, 2, k: 2);
            matrixOps.A = A;
            matrixOps.B = B;
            
            matrixOps.ParallelAdd();
            
            Assert.Equal(expected, matrixOps.C);
        }

        [Fact]
        public void SequentialAndParallel_Should_GiveSameResult()
        {
            int n = 5, m = 5;
            var matrixOpsSeq = new MatrixOperations(n, m);
            var matrixOpsPar = new MatrixOperations(n, m, k: 3);
            
            matrixOpsPar.A = matrixOpsSeq.A;
            matrixOpsPar.B = matrixOpsSeq.B;
            
            matrixOpsSeq.SequentialAdd();
            matrixOpsPar.ParallelAdd();
            
            Assert.Equal(matrixOpsSeq.C, matrixOpsPar.C);
        }
    }
}
