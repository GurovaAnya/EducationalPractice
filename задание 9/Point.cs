using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_9
{
     public class Point
        
    {
        public double Value { get; private set; }
        public Point Next{ get; private set; }
        public int Count { get; private set; }

        public Point(double value = 0)
        {
            this.Value = value;
            this.Next = null;
            Count = 1;
        }

        public void Add(double value)
        {
            Point p = new Point(value);
            Point temp = this;
            while (temp.Next != null)
                temp = temp.Next;
            temp.Next = p;
            Count++;
        }

        public override string ToString()
        {
            string result = string.Empty;
            if (this.Next == null)
                return "Список пустой";
            else
            {
                Point p = this.Next;
                do
                {
                    result += p.Value+ " ";
                    p = p.Next;
                } while (p != null);
                return result;
            }
        }

        public double SumNonRec()
        {
            Point p = this;
            double sum = 0;
            while(p!=null)
            {
                sum += p.Value;
                p = p.Next;
            }
            return sum;
        }

        public static double SumRec(Point p)
        {
            if (p == null)
                return 0;
            else
                return p.Value + SumRec(p.Next);
        }

    }
}
