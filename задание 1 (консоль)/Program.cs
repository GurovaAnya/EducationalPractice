using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_1__консоль_
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c, radius;
            string triangle = Console.ReadLine();
            string rad = Console.ReadLine();
            char[] split = new char[] { ' ' };
            string[] sides = triangle.Split(split, StringSplitOptions.RemoveEmptyEntries);

            if (Check(sides) && Int32.TryParse(rad, out radius))
            {
                WriteSides(out a, out b, out c, sides);
                double maxRadius = Radius(a, b, c);
                if (radius <= maxRadius)
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
            }
            else
                Console.WriteLine("NO");

        }

        public static double Radius(int a, int b, int c)
        {
            return Math.Sqrt((-a + b + c) * (-b + a + c) * (a + b - c) / (4 * (a + b + c)));
        }

        public static void WriteSides(out int a, out int b, out int c, string[] sides)
        {
            a = Convert.ToInt32(sides[0]);
            b = Convert.ToInt32(sides[1]);
            c = Convert.ToInt32(sides[2]);
        }

        public static bool Check(string[] sides)
        {
            bool givenIsInt = true;
            givenIsInt &= sides.Length == 3;
            foreach (string side in sides)
                givenIsInt &= Int32.TryParse(side, out int x);
            return givenIsInt;
        }
    }
}

