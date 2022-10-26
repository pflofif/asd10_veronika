using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD10_Veronika
{
    internal class Lab10
    {
        public List<double> Numbers { get; }
        public int Count { get; }

        public Lab10(int size)
        {
            Numbers  = Enumerable.Range(0, Convert.ToInt32(size))
                .Select(n => (double)Random.Shared.Next(-50, 50))
                .OrderBy(i => i)
                .ToList();

            Count = size;
        }

        public double this[int index] => Numbers[index];

        public void SwapBehindMin()
        {
            (Numbers[1], Numbers[2]) = (Numbers[2], Numbers[1]);
        }
        public void DevideMax()
        {
            double absSumOfNeg = Math.Abs(Numbers.TakeWhile(x => x < 0).Sum());
            Numbers[Count - 1] = Numbers.Last() / absSumOfNeg;
        }

        public int IndexOfSearcheble(int number)
        {
            var (min, max) = (0, Numbers.Count - 1);

            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (Math.Abs(number - Numbers[mid]) < 0.001)
                {
                    return mid;
                }

                if (number < Numbers[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }
    }
}
