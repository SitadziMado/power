using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power
{
    class BigInt
    {
        BigInt(long value)
        {
            if (value < 0)
                sign = true;
            else
                sign = false;

            Add(value);
        }

        void Add(long rhs, int index = 0)
        {
            ExpandIfNecessary(index);

            digits[index] += rhs;

            while (digits[index] > Radix)
            {
                var temp = digits[index] - Radix;
                ExpandIfNecessary(index + 1);
                digits[index + 1] += temp;
                digits[index] -= Radix;
                ++index;
            }
        }

        void ExpandIfNecessary(int index)
        {
            if (digits.Count < index + 1)
                digits.Add(0);
        }

        public static BigInt operator+(BigInt lhs, long rhs)
        {
            throw new NotImplementedException();
        }

        private const long Radix = 1000000;

        private bool sign;
        private List<long> digits = new List<long>();
    }
}
