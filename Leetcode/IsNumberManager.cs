using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class IsNumberManager
    {
        static char[] validIntegers = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        static char[] forbidden = new char[] { 'a', 'b', 'c', 'd', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o',
        'p','r','s','t','u','w','x','y','z',
        'A', 'B', 'C', 'D', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O',
        'P','R','S','T','U','W','X','Y','Z', '-', ' ', ':', '\\', '{', };

        public bool IsNumber(string s)
        {
            char[] chars = s.ToCharArray();
            char[] withoutWhiteSpace = this.RemoveWhitespaces(chars);

            char[] withoutPlusMinusSign = null;
            if (withoutWhiteSpace[0] == '-' || withoutWhiteSpace[0] == '+')
            {
                withoutPlusMinusSign = new char[withoutWhiteSpace.Length - 1];
                this.CopyChars(withoutWhiteSpace, 1, ref withoutPlusMinusSign);
            }

            char[] current = withoutPlusMinusSign != null ? withoutPlusMinusSign : withoutWhiteSpace;

            var containsForbidden = this.ContainsForbidden(current);
            if (containsForbidden)
            {
                return false;
            }

            return true;
        }

        private bool ContainsForbidden(char[] items)
        {
            int dotCounter = 0;
            int epsilonCounter = 0;

            for (int i = 0; i < items.Length; i++)
            {
                if (forbidden.Contains(items[i]))
                {
                    return true;
                }

                if (items[i] == 'e' || items[i] == 'E')
                {
                    epsilonCounter++;
                    if (epsilonCounter > 1)
                    {
                        return true;
                    }
                }

                if (items[i] == '.')
                {
                    dotCounter++;
                    if (dotCounter > 1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private char[] RemoveWhitespaces(char[] items)
        {
            int counter = 0;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == ' ')
                {
                    counter++;
                }
                else
                {
                    break;
                }
            }

            if (counter > 0)
            {
                char[] withoutWhitespaces = new char[items.Length - counter];
                this.CopyChars(items, counter, ref withoutWhitespaces);
                return withoutWhitespaces;
            }

            return items;
        }

        private void CopyChars(char[] items, int itemsToSkip, ref char[] result)
        {
            int position = 0;
            for (int i = itemsToSkip; i < items.Length; i++)
            {
                result[position] = items[i];
                position++;
            }
        }
    }
}
