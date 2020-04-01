using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"Даны действительные числа х, у. Определить, принадлежит ли точка с координатами х, у заштрихованной части плоскости

(Область ограничена прямыми x=1,x=-1,y=1,y=-1)
");
            double x = InsertDouble("Введите значение координаты x: ");
            double y = InsertDouble("Введите значение координаты y: ");

            if (CheckArea(x, y))
                Console.WriteLine("Данная точка ВХОДИТ в заданную часть плоскости");
            else
                Console.WriteLine("Данная точка НЕ ВХОДИТ в заданную часть плоскости");
            Console.ReadKey();
        }

        static bool CheckArea(double x, double y)
        {
            return x >= -1 && x <= 1 && y >= -1 && y <= 1;
        }

        static double InsertDouble(string message)
        {
            Console.Write(message);
            double num;
            bool ok = true;
            do
            {
                if (!ok)
                    Console.Write("Вы должны вводить действительные числа! Повторите попытку: ");
                string temp = Console.ReadLine();
                ok = Double.TryParse(temp, out num);
            } while (!ok);
            return num;
        }
    }
}
