using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class DivideTwoIntegersManager
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

            if (divisor == dividend)
            {
                return 1;
            }

            if (divisor == 1)
            {
                return dividend;
            }

            if (divisor == int.MinValue)
            {
                return 0;
            }

            return this.Execute(dividend, divisor);
        }
        private int Execute(int dividend, int divisor)
        {
            string dividendStringified = dividend.ToString();
            string divisorStringified = divisor.ToString();
            int multiplication = 1;

            if ((dividendStringified.StartsWith("-") && !divisorStringified.StartsWith("-")) ||
                (!dividendStringified.StartsWith("-") && divisorStringified.StartsWith("-")))
            {
                multiplication = -1;
            }

            string dividentSign = dividendStringified.StartsWith("-") ? "-" : "";
            dividendStringified = dividendStringified.Replace("-", string.Empty);
            divisorStringified = divisorStringified.Replace("-", string.Empty);

            int length = divisorStringified.Length;

            divisor = Math.Abs(divisor);

            int tmpDivident = dividend == Int32.MinValue ? Int32.MaxValue : Math.Abs(dividend);
            if (divisor > tmpDivident)
            {
                return 0;
            }

            string partOfDivident = dividendStringified.Substring(0, divisor.ToString().Length);
            var stringRes = this.DivideHelper(dividendStringified, partOfDivident, dividentSign, divisor, divisor.ToString().Length);
            int res = int.Parse(stringRes);

            if (multiplication > 0)
            {
                return res;
            }
            else
            {
                return 0 - res;
            }
        }

        private int DivideBySum(int partialDivident, int divisor, out int difference)
        {
            int counter = 0;
            int pointer = 0;
            bool wasMaxMinus = false;

            if (partialDivident < 0)
            {
                if (partialDivident == int.MinValue)
                {
                    wasMaxMinus = true;
                    counter++;
                    pointer += divisor;
                    partialDivident += divisor;
                }
                partialDivident = Math.Abs(partialDivident);
            }

            if (!wasMaxMinus)
            {
                while (partialDivident - pointer >= divisor)
                {
                    counter++;
                    pointer += divisor;
                }
            }
            else
            {
                while (partialDivident - pointer >= 0)
                {
                    counter++;
                    pointer += divisor;
                }
            }

            difference = partialDivident - pointer;

            return counter;
        }

        private string DivideHelper(string dividentStringified, string partOfDivident, string partOfDividentSign, int divisor, int divisorLenght)
        {
            int difference = 0;
            string value;

            int result = this.DivideBySum(int.Parse(partOfDividentSign + partOfDivident), divisor, out difference);
            value = result.ToString();

            if (difference != 0)
            {
                if (dividentStringified.Length > 0 && dividentStringified.Length >= divisorLenght && !string.Equals(dividentStringified, partOfDivident))
                {
                    string partial = string.Empty;
                    if (dividentStringified.Length > divisorLenght)
                    {
                        partial = difference.ToString() + dividentStringified.Substring(divisorLenght, 1);
                        dividentStringified = dividentStringified.Substring(1, dividentStringified.Length - 1);
                        string innerRes = this.DivideHelper(dividentStringified, partial, partOfDividentSign, divisor, divisorLenght);
                        value += innerRes;
                    }
                }
            }
            else
            {
                dividentStringified = dividentStringified.Substring(divisorLenght, dividentStringified.Length - divisorLenght);
                if (dividentStringified.Length > 0)
                {
                    string partial = dividentStringified.Substring(0, divisorLenght);
                    string innerRes = this.DivideHelper(dividentStringified, partial, partOfDividentSign, divisor, divisorLenght);
                    value += innerRes;
                }
            }

            return value;
        }
    }
}
