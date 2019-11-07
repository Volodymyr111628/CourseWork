using System;
using System.Threading;

namespace CoursesTask10.Common
{
    public class MatrixParallel
    {

        public int ThreadsCount { get; set; }
        public int[,] Matrix { get; set; }

        public MatrixParallel(int threadsCount, int[,] matrix)
        {
            ThreadsCount = threadsCount;
            Matrix = matrix;
        }

        public int GetSumOfElements()
        {
            int sum = 0;

            Thread[] threads = new Thread[ThreadsCount];

            int rowsPerThread = Convert.ToInt32(Math.Round((double)Matrix.GetLength(0) / ThreadsCount));

            for (int i = 0; i < ThreadsCount; i++)
            {
                int startLine = i * rowsPerThread;
                int endLine = 0;

                if (Matrix.GetLength(0) / ThreadsCount < 1)
                {
                    throw new ArgumentException("Threads count is bigger than Rows count");
                }

                if (ThreadsCount-1 == i )
                {
                    endLine = Matrix.GetLength(0);
                }
                else
                {
                    endLine = (i + 1) * rowsPerThread;
                }

                threads[i] = new Thread(() => sum += GetSumOfRows(startLine, endLine));
            }

            foreach (var thread in threads)
            {
                thread.Start();
                thread.Join();
            }

            

            return sum;
        }

        private int GetSumOfRows(int startLine, int endLine)
        {
            int sum = 0;
            for (int i = startLine; i < endLine; i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {

                    sum += Matrix[i, j];
                }
            }
            return sum;
        }
    }
}
