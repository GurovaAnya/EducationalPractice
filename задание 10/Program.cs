using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_10
{
    class Program
    {
        static Random rand = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("Даны натуральное число п, действительные числа x1, .., хп. Вычислить: х1хп + x2xn-1 + ... + хпх1");
            int num = InsertNatur("Сколько элементов должно быть в последовательности: ", 5000);
            Point p = new Point(CreateList(num));
            double sum = Point.Function(p, p.GetLastPoint());
            Console.WriteLine("Результат вычисления: " + sum);
            Console.ReadKey();
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
                ok = double.TryParse(temp, out num);
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
                ok = Int32.TryParse(temp, out answ)&&answ>0&&answ<=max;
            } while (!ok);
            return answ;
        }

        static double[] CreateParamsByHand(int num)
        {
            double[] values = new double[num];
            for (int i = 0; i < num; i++)
                values[i] = InsertDouble($"Введите элемент под номером {i+1}: ");
            return values;
        }

        static double[] CreateParamsRandomly(int num)
        {
            double[] values = new double[num];
            for (int i = 0; i < num; i++)
                values[i] = rand.Next(100);
            return values;
        }

        static bool AskForInsertType()
        {
            string message = "Каким способом ввести элементы последовательности? " +
                "Введите 1 для заполнения вручную, 2 для заполнения с помощью датчика случайных чисел.\n";
            int answer = InsertNatur(message);
            do
            {
                switch (answer)
                {
                    case 1:
                        return false;
                    case 2:
                        return true;
                    default:
                        answer = InsertNatur(message);
                        break;
                }
            } while (true);
        }

        static double[] CreateList(int num)
        {
            double[] values = new double[num];
            bool insertRandomly = AskForInsertType();
            if (insertRandomly)
                values = CreateParamsRandomly(num);
            else
                values = CreateParamsByHand(num);
                        
            return values;
        }
    }
}
