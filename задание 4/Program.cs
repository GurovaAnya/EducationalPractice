using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Найдем корень уранения  х^3—0.2x^2—0.2*x— 1.2 = 0 на отрезке [1, 1.5]; ");
            double e = InsertDouble("\nВведите значение максимальной погрешности: "); 
            double x0 = 1,
                x1 = 1.5,
                f0 = F(x0),
                f1 = F(x1);
            HalfMethod(e, ref x0, ref x1, ref f0, ref f1);
            Console.WriteLine("Решение уравнения с учетом погрешности: x = {0}", x0);
            Console.ReadKey();
        }

        static void HalfMethod(double e, ref double x0, ref double x1, ref double f0, ref double f1)
        { 
            if (x1 - x0 < 2 * e)
                return;
            double x2 = (x0 + x1) / 2;
            double f2 = F(x2);
            if (f0 * f2 < 0)
            {
                x1 = x2;
                f1 = f2;
            }
            else
            {
                x0 = x2;
                f0 = f2;
            }
            HalfMethod(e, ref x0, ref x1, ref f0, ref f1);
        }

        static double F(double x)
        {
            return Math.Pow(x, 3) - 0.2 * x * x - 0.2 * x - 1.2;
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
                ok = double.TryParse(temp, out num) && num >= 0.000000000000001;
            } while (!ok);
            return num;
        }
    }
}
