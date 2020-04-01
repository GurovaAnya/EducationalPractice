using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_12
{
    class Program
    {
        static Random rand = new Random();
        static void Main(string[] args)
        {
            CompareBySize(100);
            CompareBySize(10000);
            Console.ReadKey();
        }

        static void CompareBySize(int size)
        {
            Console.WriteLine($"Сортировка для {size} элементов:");
            CompareByOrder(size, CreateAscendingArray);
            CompareByOrder(size, CreateDescendingArray);
            CompareByOrder(size, CreateRandomArray);
        }
        
        static void CompareByOrder(int size, CreateArray createArray)
        {
            int[] arr = createArray(size);
            int[] arr2 = new int[size];
            Array.Copy(arr, arr2, size);
            Console.WriteLine("Сортировка простыми вставками... ");
            InsertionSort(arr);
            Console.WriteLine("Поразрядная сортировка... ");
            RadixSort(arr2);
            Console.WriteLine();
        }

        public delegate int[] CreateArray(int size);

        static int [] CreateAscendingArray(int size)
        {
            Console.WriteLine("Возрастающий порядок.");
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = i;
            }
            return arr;
        }

        static int [] CreateDescendingArray(int size)
        {
            Console.WriteLine("Убывающий порядок.");
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = size-i;
            }
            return arr;
        }

        static int [] CreateRandomArray (int size)
        {
            Console.WriteLine("Рандомное заполнение.");
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = rand.Next(-100,100);
            }
            return arr;
        }

        static void InsertionSort(int[] arr)
        {
            long changeInsertionSort = 0,
               compareInsertionSort = 0;
            //Console.WriteLine(string.Join(", ", arr));
            InsertionSort(arr, ref changeInsertionSort, ref compareInsertionSort);
           //Console.WriteLine(string.Join(", ", arr));
            Console.WriteLine($"Количество сравнений: {compareInsertionSort}" +
                $" Количество перемещений:{changeInsertionSort}");
        }

        static void RadixSort(int[] arr)
        {
            int changeRadixSort = 0,
               compareRadixSort = 0;
            //Console.WriteLine(string.Join(", ", arr));
            RadixSort(arr, ref changeRadixSort, ref compareRadixSort);
            //Console.WriteLine(string.Join(", ", arr));
            Console.WriteLine($"Количество сравнений: {compareRadixSort}." +
             $" Количество перемещений: {changeRadixSort}");
        }

        /// <summary>
        /// Сортировка простыми вставками
        /// </summary>
        /// <param name="arr"> Сортируемый массив </param>
        /// <param name="change"> Количество перемещений</param>
        /// <param name="compare"> Количество сравнений</param>
        static void InsertionSort(int[] arr, ref long change, ref long compare)
        {
            int n = arr.Length;
            int x;
            
            for (int i = 1; i < n; i++)
            {
                x = arr[i];
                int j = i;
                while (j > 0 && arr[j - 1] > x)
                    {
                        compare++;
                        arr[j] = arr[j-- - 1];
                        change++;
                    }
                compare++;//последнее сравнение не засчитано в цикле
                arr[j] = x;
            }
        }

        /// <summary>
        /// Поразрядная сортировка массива в его побитовом представлении
        /// </summary>
        /// <param name="arr">сортируемый массив</param>
        /// <param name="change"> Количество перемещений </param>
        /// <param name="compare"> Количество сравнений </param>
        static void RadixSort(int[] arr, ref int change, ref int compare)
        {
            change = 0;
            compare = 0;
            //Переменная для побитового сдвига элементов
            int numLength = 31;
            int i, j;
            int[] tmp = new int[arr.Length];
            for (int shift = numLength; shift > -1; shift--)
            {
                j = 0;
                for (i = 0; i < arr.Length; i++)
                {
                    compare++;
                    //Если проверяемый разряд числа равен 0, то число будет больше 0,
                    //иначе - меньше 0.
                    bool move = (arr[i] << shift) >= 0;
                    //Числа с 0 оставляем в массиве.
                    //При сдвиге на 0 разрядов число (исходное) проверяется наоборот,
                    //так как 1 в начале указывает на отрицательность.
                    if (shift == 0 ^ move)  
                    {
                        arr[i - j] = arr[i];
                        change++;
                    }
                    //Числа с 1 переносим в дополнительный массив
                    else                           
                    {
                        tmp[j++] = arr[i];
                        change++;
                    }
                }
                //Переносим все числа из вспомогательного массива в конец исходного
                Array.Copy(tmp, 0, arr, arr.Length - j, j);
                change += j;
            }
        }  
    }
}
