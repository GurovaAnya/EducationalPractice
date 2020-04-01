using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Diagnostics;

namespace задание_6
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ввести а1, а2, а3, М, N. Построить последовательность чисел ак = 2 * | ак–1 – ак-2 | + ак–3. Построить N элементов последовательности, либо найти первые M ее элементов, кратных трем (в зависимости от того, что выполнится раньше). Напечатать последовательность и причину остановки.");
            int a1, a2, a3, M, N;

            a1 = InsertInt("Введите 1 элемент последовательности: ");
            a2 = InsertInt("Введите 2 элемент последовательности: ");
            a3 = InsertInt("Введите 3 элемент последовательности: ");
            M = InsertNatur("Введите ограничение на число чисел, кратных 3: ",7000);
            N = InsertNatur("Введите ограничение на общее число чисел: ", 7000);
            Console.WriteLine();

            Dictionary<int, BigInteger> numbers = new Dictionary<int, BigInteger>(N)
            {
                { 1, a1 },
                { 2, a2 },
                { 3, a3 }
            };

            
            ConductRecursion(numbers, N, M);
            Console.ReadKey();

        }

        public static void ConductRecursion(Dictionary<int, BigInteger> numbers, int N, int M)
        {
            int countMultiple = 0;
            foreach (int num in numbers.Values)
                if (num % 3 == 0)
                    countMultiple++;
            try
            {
                A(N, numbers, ref countMultiple, M);
                WriteNumbers(numbers);
            }

            catch (AllMultiplesReadyException)
            {
                WriteMultiple(M, numbers);
            }
        }

        static BigInteger A(int num, Dictionary<int, BigInteger> numbers, ref int countMultiple, int M)
        {
            try
            {
                return numbers[num];
            }
            catch (Exception)
            {
                numbers.Add(num, A(num - 3, numbers, ref countMultiple, M)
                    + 2 * BigInteger.Abs(A(num - 2, numbers, ref countMultiple, M)
                    - A(num - 1, numbers, ref countMultiple, M)));
                
                if (numbers[num] % 3 == 0)
                    countMultiple++;
                if (countMultiple == M) throw new AllMultiplesReadyException();
                return numbers[num];

            }
        }

        static void WriteMultiple(int M, Dictionary<int, BigInteger> numbers)
        {
            Console.WriteLine($"Найдено {M} первых чисел, кратных 3");
            int i = 0;
            foreach (BigInteger number in numbers.Values)
                if (number % 3 == 0)
                {
                    Console.WriteLine(i + 1 + " " + number);
                    i++;
                    if (i == M)
                        break;
                }
        }

        static void WriteNumbers(Dictionary<int, BigInteger> numbers)
        {
            Console.WriteLine($"Найдено {numbers.Count} первых элементов последовательности:");
            foreach (KeyValuePair<int, BigInteger> number in numbers)
                Console.WriteLine(number.Key+ " "+number.Value);
        }

        static int InsertInt(string message)
        {
            Console.Write(message);
            int num;
            bool ok = true;
            do
            {
                if (!ok)
                    Console.WriteLine("Вы должны вводить целые числа!");
                string temp = Console.ReadLine();
                ok = int.TryParse(temp, out num);
            } while (!ok);
            return num;
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
