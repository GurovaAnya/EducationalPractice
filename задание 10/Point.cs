using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_10
{
    class Point
    {
        public double Value { get; private set; }
        public Point Next { get; private set; }
        public Point Prev { get; private set; }
        public int Count { get; private set; }

        public Point(double value = default(double))
        {
            this.Value = value;
            this.Next = null;
            this.Prev = null;
            Count = 1;
        }
        public Point(IEnumerable<double> values)
        {
            foreach (double value in values)
                Add(value);
        }

        public Point(params double [] values)
        {
            foreach (double value in values)
                Add(value);
        }

        public void Add(double value)
        {
            Point p = new Point(value);
            if (this.Count != 0)
            {
                Point temp = this;
                while (temp.Next != null)
                    temp = temp.Next;
                temp.Next = p;
                p.Prev = temp;
                Count++;
            }
            else
            {
                this.Value = value;
                this.Next = null;
                this.Prev = null;
                this.Count = 1;
            }
        }

        public override string ToString()
        {
            string result = string.Empty;
            if (this == null)
                return "Список пустой";
            else
            {
                Point p = this;
                do
                {
                    result += p.Value + " ";
                    p = p.Next;
                } while (p != null);
                return result;
            }
        }

        public Point GetLastPoint()
        {
            Point p = this;
            while (p.Next != null)
                p = p.Next;
            return p;
        }

        public static double Function(Point beg, Point end)
        {
            if (beg == end) return beg.Value * end.Value;
            if (beg.Next == end)
                return 2 * beg.Value * end.Value;
            return 2*beg.Value * end.Value + Function(beg.Next, end.Prev);
        }
    }
}
