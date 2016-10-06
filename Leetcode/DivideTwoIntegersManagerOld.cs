using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class DivideTwoIntegersManagerOld
    {
        public int Divide(int dividend, int divisor)
        {
            
            if (divisor == 0)
            {
                throw new DivideByZeroException();
            }

            if (dividend == 0)
            {
                return 0;
            }

            if (dividend == Int32.MinValue && divisor == -1)
            {
                return Int32.MaxValue;
            }

            if (divisor == 1)
            {
                return dividend;
            }
            
            int multiplication = 1;
            if ((dividend < 0 && divisor > 0) || (dividend > 0 && divisor < 0))
            {
                multiplication = -1;
            }
            
            dividend = Math.Abs(dividend);
            divisor = Math.Abs(divisor);

            int counterMultiplication = 1;
            for (int i = 2; i < Math.Log(Int32.MaxValue, 2); i++)
            {
                var ctr = Math.Pow(divisor, i);
                if (ctr < dividend)
                {
                    counterMultiplication = i;
                }
                else
                {
                    break;
                }
            }

            int counter = 0;
            int pointer = 0;
            int increment = 0;
            for (int i = 0; i < counterMultiplication; i++)
            {
                increment += divisor;
            }

            while (dividend >= pointer + increment)
            {
                pointer += increment;
                if (pointer <= dividend)
                {
                    counter += counterMultiplication;
                }
            }

            if (pointer + divisor <= dividend)
            {
                counter++;
            }

            if (multiplication > 0)
            {
                return counter;
            }
            else
            {
                return 0 - counter;
            }
        }
    }
}
