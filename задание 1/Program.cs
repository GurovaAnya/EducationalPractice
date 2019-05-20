using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace задание_1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            StreamWriter sw = new StreamWriter("output.txt");

            int a, b, c, radius;
            string triangle = sr.ReadLine();
            string rad = sr.ReadLine();
            char[] split = new char[] { ' ' };
            string[] sides = triangle.Split(split, StringSplitOptions.RemoveEmptyEntries);

            if (Check(sides) && Int32.TryParse(rad, out radius))
            {
                WriteSides(out a, out b, out c, sides);
                double maxRadius = Radius(a, b, c);
                if (radius <= maxRadius)
                    sw.WriteLine("YES");
                else
                    sw.WriteLine("NO");
            }
            else
                sw.WriteLine("NO");

            sr.Close();
            sw.Close();
        }

        public static double Radius(int a, int b, int c)
        {
            return Math.Sqrt((-a + b + c) * (-b + a + c) * (a + b - c) / (4 * (a + b + c)));
        }

        public static void WriteSides( out int a, out int b, out int c, string []sides)
        {
            a = Convert.ToInt32(sides[0]);
            b = Convert.ToInt32(sides[1]);
            c = Convert.ToInt32(sides[2]);
        }

        public static bool Check(string [] sides)
        {
            bool givenIsInt = true;
            givenIsInt &= sides.Length == 3;
            foreach (string side in sides)
                givenIsInt &= Int32.TryParse(side, out int x);
            return givenIsInt;
        } 
    }
}
