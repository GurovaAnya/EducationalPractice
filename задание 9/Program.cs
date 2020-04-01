using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_9
{
    class Program
    {
        static Random rand = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("В программе построен линейный список. Напишите функцию подсчета суммы всех значений, занесенных в информационные поля его элементов (рекурсивный и нерекурсивный варианты).");
            int num = InsertNatur("Введите количество членов последовательности: ");
            Point list = CreateList(num);
            Console.WriteLine("Новый список: "+ list);
            Console.Write("Сумма членов последовательности, найденная с помощью НЕрекурсивного метода: ");
            Console.WriteLine(list.SumNonRec());
            Console.Write("Сумма членов последовательности, найденная с помощью рекурсивного метода: ");
            Console.WriteLine(Point.SumRec(list));
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
                    Console.WriteLine("Вы должны вводить действительные положительные числа!");
                string temp = Console.ReadLine();
                ok = double.TryParse(temp, out num) && num > 0;
            } while (!ok);
            return num;
        }

        static int InsertNatur(string message)
        {
            Console.Write(message);
            int answ;
            bool ok = true;
            do
            {
                if (!ok)
                    Console.Write("Вы должны вводить натуральные числа ! Повторите попытку: ");
                string temp = Console.ReadLine();
                ok = Int32.TryParse(temp, out answ)&&answ>0&&answ<15000;
            } while (!ok);
            return answ;
        }

        static Point CreateParamsByHand(int num)
        {
            Point values = new Point();
            for (int i = 0; i < num; i++)
                values.Add(InsertDouble($"Введите элемент под номером {i}: "));
            return values;
        }

        static Point CreateParamsRandomly(int num)
        {
            Point values = new Point();
            for (int i = 0; i < num; i++)
                values.Add(rand.Next(100));
            return values;
        }

        static bool AskForInsertType()
        {
            string message = "Каким способом ввести элементы последовательности? " +
                "Введите 1 для заполнения вручную, 2 для заполнения с помощью датчика случайных чисел.";
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

        static Point CreateList(int num)
        {
            Point values = new Point();
            bool insertRandomly = AskForInsertType();
            if (insertRandomly)
                values = CreateParamsRandomly(num);
            else
                values = CreateParamsByHand(num);

            return values;
        }
    }
}
