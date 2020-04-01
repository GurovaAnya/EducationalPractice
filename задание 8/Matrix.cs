using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_8
{
    static class Matrix
    {
        public static void ConductDFS(int[,] matrix)
        {
            if (!CheckMatrix(matrix))
                return;
            if (matrix.Length == 0)
            {
                Console.WriteLine("В графе нет вершин и ребер");
                return;
            }
            PrintMatrix(matrix);
            int[] s = CreateMinusValueVector(matrix.GetLength(1));
            int[] up = CreateMinusValueVector(matrix.GetLength(1));
            int time = 0;
            bool[] res = new bool[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (s[i] == -1)
                    DFS(matrix, i, -1, s, up, res, ref time);
            }
            ShowVertices(res);
        }

        static void DFS(int[,] matrix, int k, int p, int[] s, int[] up, bool[] res, ref int time)
        {
            int countSubPoints = 0;
            s[k] = time++;
            up[k] = s[k];
            List<int> subPoints = FindSubPoints(k, matrix);
            foreach (int subPoint in subPoints)
            {
                if (s[subPoint] == -1)
                {
                    countSubPoints++;
                    DFS(matrix, subPoint, k, s, up, res, ref time);
                    up[k] = Math.Min(up[k], up[subPoint]);
                    if (up[subPoint] >= s[k])
                        res[k] = true;
                }
                //Если возвращаемся не в родителя
                else if (subPoint != p)
                    up[k] = Math.Min(up[k], s[subPoint]);
                //Если k - корень
                if (p == -1)
                    res[k] = countSubPoints > 1;
            }
        }

        static List<int> FindSubPoints(int k, int[,] matrix)
        {
            List<int> subPoints = new List<int>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, k] == 1)
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        if (j != k && matrix[i, j] == 1)
                            subPoints.Add(j);
            }
            return subPoints;
        }

        static Random rand = new Random();

        public static int[,] CreateRandomMatrix(int numOfVertices, int numOfEdges)
        {
            if (!CheckVerticesAndEdges(numOfVertices, numOfEdges))
                numOfEdges = numOfVertices * (numOfVertices - 1) / 2;
            int[,] matrix = new int[numOfEdges, numOfVertices];
            for (int i = 0; i < numOfEdges; i++)
            {
                int beg;
                int end;
                do
                {
                    beg = rand.Next(0, numOfVertices);
                    do
                    {
                        end = rand.Next(0, numOfVertices);
                    } while (beg == end);
                } while (!NoParallelEdges(beg, end, i, matrix));
                matrix[i, beg] = 1;
                matrix[i, end] = 1;
            }
            return matrix;
        }

        static bool NoParallelEdges(int beg, int end, int edgeNum, int[,] matrix)
        {
            for (int i = 0; i < edgeNum; i++)
            {
                if (matrix[i, beg] == 1 && matrix[i, end] == 1)
                    return false;
            }
            return true;
        }

        public static int[,] CutParallelEdges(int[,] matrix)
        {
            int parallelEdges = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int j = 0;
                while (matrix[i, j] == 0)
                    j++;
                int beg = j++;
                while (matrix[i, j] == 0)
                    j++;
                int end = j;
                if (!NoParallelEdges(beg, end, i, matrix))
                {
                    parallelEdges++;
                    matrix[i, 0] = -1;
                    Console.WriteLine($"Удалена параллельная грань {i + 1}");
                }
            }
            int[,] newMatrix =
                new int[matrix.GetLength(0) - parallelEdges, matrix.GetLength(1)];
            int k = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, 0] != -1)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        newMatrix[k, j] = matrix[i, j];
                    k++;
                }
            }
            return newMatrix;
        }

        static int[,] CreateMatrix(int numOfVertices, int numOfEdges)
        {
            int[,] matrix = new int[numOfEdges, numOfVertices];
            do
            {
                Console.WriteLine("Введите матрицу инциденций по строкам");
                for (int i = 0; i < numOfVertices; i++)
                {
                    int[] temp = null;
                    Console.Write("Вершина " + string.Format("{0, 2}", i + 1) + ": ");
                    do
                    {
                        try
                        {
                            temp = ParseStringIntoIntArray(Console.ReadLine(), numOfEdges);
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    } while (temp == null);
                    for (int j = 0; j < numOfEdges; j++)
                        matrix[j, i] = temp[j];
                }
            } while (!CheckMatrix(matrix));

            matrix = CutParallelEdges(matrix);
            return matrix;
        }

        public static bool CheckVerticesAndEdges(int numOfVertices, int numOfEdges)
        {
            if (numOfEdges > numOfVertices * (numOfVertices - 1) / 2)
                return false;
            else
                return true;
        }

        static void PrintMatrix(int[,] matrix)
        {
            int numOfEdges = matrix.GetLength(0);
            int numOfVertices = matrix.GetLength(1);
            if (numOfEdges > 50)
            {
                Console.WriteLine("Невозможно распечатать матрицу с количеством ребер больше 50! Обрабатываем матрицу без печати...");
                return;
            }
            Console.Write("   ");
            for (int i = 1; i <= numOfEdges; i++)
                Console.Write(String.Format("{0,2}", i) + " ");
            Console.WriteLine();

            for (int i = 0; i < numOfVertices; i++)
            {
                Console.Write(String.Format("{0,2}", i + 1) + "  ");
                for (int j = 0; j < numOfEdges; j++)
                    Console.Write(matrix[j, i] + "  ");
                Console.WriteLine();
            }
        }

        static bool CheckMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                    sum += matrix[i, j];
                if (sum != 2)
                {
                    Console.WriteLine("Заданная матрица не является матрицей инциденций. Каждой грани должны принадлежать ровно 2 вершины.");
                    return false;
                }
            }
            return true;
        }

        static void ShowVertices(bool[] res)
        {
            if (!res.Contains(true))
            {
                Console.WriteLine("Точек сочленения нет.");
                return;
            }
            Console.WriteLine("Точки сочленения: ");
            for (int i = 0; i < res.Length; i++)
                if (res[i])
                    Console.Write((i + 1) + " ");
            Console.WriteLine();
        }

        static int[] CreateMinusValueVector(int length)
        {
            int[] vector = new int[length];
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = -1;
            }
            return vector;
        }


        static int[] ParseStringIntoIntArray(string input, int numOfEdges)
        {
            if (input.Length != numOfEdges)
                throw new ArgumentException($"Длина строки должна быть {numOfEdges} символов!");
            int[] output = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != '1' && input[i] != '0')
                    throw new ArgumentException("Матрица инциденций может содержать только символы 0 и 1!");
                output[i] = Int16.Parse(input[i].ToString());
            }
            return output;
        }
        
    }
}
