using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_8
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Граф задан матрицей инциденций. Найти все его точки сочленения.");
            TestGenerator();
            CustomTests();
            Console.ReadKey();
        }

        public static void TestGenerator()
        {
            Console.WriteLine("Тест 1. Пустая матрица:");
            int[,] emptyMatrix = Matrix.CreateRandomMatrix(0,0);
            Matrix.ConductDFS(emptyMatrix);
            Console.WriteLine("\nТест 2. Введена не матрица инциденций:");
            int[,] notMatrix = new int[,] { { 1, 1, 1, }, { 0, 1, 1 } };
            Matrix.ConductDFS(notMatrix);
            Console.WriteLine("\nТест 3. Нет точек сочленения:");
            int[,] noBiconnectedElementsMatrix = 
                new int[,] { { 1, 1, 0,}, { 0, 1, 1 }, { 1, 0, 1 } };
            Matrix.ConductDFS(noBiconnectedElementsMatrix);
            Console.WriteLine("\nТест 4. 1 точка сочленения:");
            int[,] singleBiconnectedElementsMatrix =
                new int[,] { { 1, 1, 0, }, { 0, 1, 1 } };
            Matrix.ConductDFS(singleBiconnectedElementsMatrix);
            Console.WriteLine("\nТест 5. 2 точки сочленения:");
            int[,] doubleBiconnectedElementsMatrix =
                new int[,] { { 1, 1, 0,0 }, { 0, 1, 1,0 },{ 0,0,1,1} };
            Matrix.ConductDFS(doubleBiconnectedElementsMatrix);
            Console.WriteLine("\nТест 6. Случайная матрица:");
            int[,] RandomMatrix = Matrix.CreateRandomMatrix(rand.Next(2,6), rand.Next(10));
            Matrix.ConductDFS(RandomMatrix);
            Console.WriteLine("\nТест 7. Введено число вершин - 3, число ребер - 4:");
            int[,] Random2Matrix = Matrix.CreateRandomMatrix(3,4);
            Matrix.ConductDFS(Random2Matrix);
            Console.WriteLine("\nТест 8. Введены параллельные грани:");
            int[,] ParallelMatrix = new int[,] { { 1,0,1,0}, { 1,0,1,0} };
            ParallelMatrix = Matrix.CutParallelEdges(ParallelMatrix);
            Matrix.ConductDFS(ParallelMatrix);
        }
        static Random rand = new Random();

        public static void CustomTests()
        {
            Console.WriteLine("\nТест 9. Пользовательские данные, рандомная матрица:");

            GetVerticesAndEdges(out int numOfVertices, out int numOfEdges);
            int[,] matrix = Matrix.CreateRandomMatrix(numOfVertices, numOfEdges);
            Matrix.ConductDFS(matrix);
        }

        static void GetVerticesAndEdges(out int numOfVertices, out int numOfEdges)
        {
            bool numbersMatch = true;
            do
            {
                if (!numbersMatch)
                    Console.WriteLine("Невозможно составить граф с заданным количеством ребер и вершин!");
                numOfVertices = InsertNatur("Введите количество вершин: ", 5000);
                numOfEdges = InsertNatur("Введите количество граней: ", 5000);
                numbersMatch = Matrix.CheckVerticesAndEdges(numOfVertices, numOfEdges);
            } while (!numbersMatch);
        }

        static int InsertNatur(string message, int max = Int32.MaxValue)
        {
            Console.Write(message);
            int answ;
            bool ok = true;
            do
            {
                if (!ok)
                    Console.Write($"Вы должны вводить натуральные числа, меньше {max}! Повторите попытку: ");
                string temp = Console.ReadLine();
                ok = Int32.TryParse(temp, out answ) && answ > 0 && answ <= max;
            } while (!ok);
            return answ;
        }


    }
}
