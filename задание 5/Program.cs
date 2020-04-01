using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_5
{
    public class Program
    {
        static Random rand = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine(@"Дана действительная квадратная матрица порядка 10. В строках с отрицательным элементом на главной диагонали найти сумму всех элементов");
            const int size = 10;
            double[,] matrix = CreateMatrix(size);
            PrintMatrix(matrix);
            FindNegаtive(matrix);
            Console.ReadKey();
        }
        
        public static void FindNegаtive(double[,] matrix)
        {
            bool found = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                double sum = 0;
                if (matrix[i, i] < 0)
                {
                    found = true;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        sum += matrix[i, j];
                    Console.WriteLine($"элемент матрицы matrix[{i + 1},{i + 1}] " +
                        $"= {matrix[i, i]}, сумма элементов строки = {sum}");
                }
            }
            if (!found)
                Console.WriteLine("Таких элементов не найдено");
        }

        static void PrintMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(String.Format("{0,5}", matrix[i, j]));
                Console.WriteLine();
            }
        }

        public static double [,] CreateMatrix(int size)
        {
            double[,] matrix = new double[size, size];
            bool insertRandomly = AskForInsertType();
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (insertRandomly)
                        matrix[i,j] = rand.Next(-1000, 1000) / 10;
                    else
                        matrix[i, j] = InsertDouble($"Введите значение элемента {i+1}:{j+1}: ");
                    return matrix;
        }

        static bool AskForInsertType()
        {
            string message = "Каким способом заполнить таблицу? " +
                "Введите 1 для заполнения вручную, 2 для заполнения с помощью датчика случайных чисел.";
            int answer = InsertInt(message);
            do
            {
                switch (answer)
                {
                    case 1:
                        return false;
                    case 2:
                        return true;
                    default:
                        answer = InsertInt(message);
                        break;
                }
            } while (true);
        }

        static int InsertInt(string message)
        {
            Console.WriteLine(message);
            int answ;
            bool ok = true;
            do
            {
                if (!ok)
                    Console.Write("Вы должны вводить целые числа! Повторите попытку: ");
                string temp = Console.ReadLine();
                ok = Int32.TryParse(temp, out answ);
            } while (!ok);
            return answ;
        }

        static double InsertDouble(string message)
        {
            Console.Write(message);
            double num;
            bool ok = true;
            do
            {
                if (!ok)
                    Console.WriteLine("Вы должны вводить действительные числа!");
                string temp = Console.ReadLine();
                ok = Double.TryParse(temp, out num);
            } while (!ok);
            return num;
        }
    }
}

