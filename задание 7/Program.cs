using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_7
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Доопределить заданную булеву функцию всеми возможными способами так, чтобы она была линейной. Выписать все вектора в лексикографическом порядке.");
            Console.WriteLine("Программа распознает только значения 0 и 1. Остальные знаки воспринимаются как неизвестные.\n" +
                "Введите вектор для распознавания: ");
            string temp = Console.ReadLine();
            if (temp.Length > 0)
                DoTask(temp);
            else Console.WriteLine("Введена пустая строка");
            Console.ReadKey();
        }
        
        public static void DoTask(string temp)
        {
            int numOfParams;
            CheckLengthError(ref temp, out numOfParams);
            int[] vector = Transform(temp);
            int[,] table = CreateTable(numOfParams, vector.Length);
            int[] coeff = new int[numOfParams + 1];
            InputInfo(vector);
            Console.WriteLine("\n\nВсе возможные варанты доопределения:");
            List<string> answers = ApplyVariations(vector, coeff.Length);
            PrintAnswers(answers);
        }

        public static void PrintAnswers(List<string> answers)
        {
            if (answers.Count == 0)
                Console.WriteLine("Невозможно доопределить введенный вектор до линейного");
            foreach (string answ in answers)
                Console.WriteLine(answ);
        }

        static bool CheckLength(string temp, out int numOfParams)
        {
            double pow = Math.Log(temp.Length) / Math.Log(2);
            numOfParams = (int)pow;
            if (pow==numOfParams)
                return true;
            return false;
        }

        static void CheckLengthError(ref string temp, out int numOfParams)
        {
            if (!CheckLength(temp, out numOfParams))
            {
                temp = temp.Substring(0, (int)Math.Pow(2, numOfParams));
                Console.WriteLine("Длина вектора не является степенью двойки. Обрабатываем строку:\n" + temp);
            }
        }

        static void InputInfo(int [] vector)
        {
            Console.WriteLine("\nВы ввели вектор: ");
            foreach (int i in vector)
                if (i == 1 || i == 0)
                    Console.Write(i);
                else
                    Console.Write("*");
        }

        static int [] Transform(string input)
        {
            int[] output = new int[input.Length];
            for (int i =0;i<output.Length;i++)
            {
                output[i] = ParseCharToInt(input[i]);
            }
            return output;
        }

        static int ParseCharToInt(char sym)
        {
            if (sym == '0')
                return 0;
            if (sym == '1')
                return 1;
            return 2;
        }



        public static List<string> ApplyVariations(int[] vector, int size)
        {
            List<string> answers = new List<string>();
            int[] coeffs = new int[size];
            int variations= (int)Math.Pow(2, size);
            int width = size - 1,
                length = vector.Length;
            int[,] table = CreateTable(width, length);
            for (int i = 0; i <variations;  i++)
            {
                for (int j = 0; j < size; j++)
                    coeffs[j] = ((int)(Math.Pow(2, j + 1) * i / variations)) % 2;
                int[] vectorCopy = new int[vector.Length];
                Array.Copy(vector, vectorCopy, vector.Length);

                if (CheckVariation(vectorCopy, coeffs, table))
                    answers.Add(string.Join(string.Empty, vectorCopy));
            }
            answers.Sort();
            return answers;
        }

        static bool CheckVariation(int[] vector, int[] coeffs, int [,] table)
        {
            
            for (int i = 0; i < vector.Length; i++)
            {
                int variationOk = coeffs[0];
                for (int j = 0; j < table.GetLength(0); j++)
                    variationOk += coeffs[j + 1] * table[j, i];
                variationOk %= 2;
                if (vector[i] == 1 || vector[i] == 0)
                {
                    if (!(variationOk == vector[i]))
                        return false;
                }
                else
                    vector[i] = variationOk;
            }
            return true;
        }

        static int [,] CreateTable(int width, int length)
        {
            int[,] table = new int[width, length];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                    table[i, j] = ((int)(Math.Pow(2, i+1) * j / length)) % 2;
            }
            return table;
        }

        static void PrintTable(int [,] table)
        {
            for (int j = 0; j < table.GetLength(1); j++)
            {
                for (int i = 0; i < table.GetLength(0); i++)
                    Console.Write(table[i, j] + " ");
                Console.WriteLine();
            }
        }
    }
}
