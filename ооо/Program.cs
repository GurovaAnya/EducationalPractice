using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание2
{
    class Program
    {
        public static void Find(ulong[] arr, ulong number)
        {
            if (number < 288474407370955160)
            {
                arr[position++] = number;
                if (Array.IndexOf(arr, number * 2) == -1)
                    Find(arr, number * 2); 
                if (Array.IndexOf(arr, number * 3) == -1)
                    Find(arr, number * 3);
                if (Array.IndexOf(arr, number * 5) == -1)
                    Find(arr, number * 5);
            }
        }

        public static ulong position = 0;
        static void Main()
        {
            Console.WriteLine(@"Найдите n-й элемент строго возрастающей последовательности, которая описывается следующими правилами:
1)  число 1 является элементом последовательности;
2)  если a – элемент последовательности, то 2a, 3a, 5a тоже являются элементами последовательности;
3)  последовательности принадлежат только элементы, заданные правилами 1 и 2.
Входной файл INPUT.TXT содержит одно натуральное число n (n ≤ 10000).
В выходной файл OUTPUT.TXT выведите одно число – n-й элемент последовательности.
");
            try
            {
                int input = Convert.ToInt32(Console.ReadLine());
                int num = 10000;
                ulong[] sequence = new ulong[num];
                for (int i = 0; i < sequence.Length; i++)
                    sequence[i] = ulong.MaxValue;

                Find(sequence, 1);
                Array.Sort(sequence);
                Console.WriteLine(sequence[input - 1]);
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка!");
            }
            Console.ReadKey();
        }
    }
}
