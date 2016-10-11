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
        'p','q','r','s','t','u', 'v', 'w','x','y','z',
        'A', 'B', 'C', 'D', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O',
        'P','Q','R','S','T','U', 'V', 'W','X','Y','Z', '-', ' ', ':', '\\', '{', '-', '+'};

        public bool IsNumber(string s)
        {
            char[] chars = s.ToCharArray();
            char[] withoutWhiteSpace = this.RemoveWhitespaces(chars);
            withoutWhiteSpace = this.RemoveWhitespacesOnEnd(withoutWhiteSpace);

            if (withoutWhiteSpace.Length == 0)
            {
                return false;
            }

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

            int epsilonPosition = 0;
            int dotPosition = 0;

            if (items[0] == '.' && items.Length == 1)
            {
                return true;
            }

            if (items.Length > 1 && items[0] == '.' && (items[1] == 'e' || items[1] == 'E'))
            {
                return true;
            }

            if (items[0] == 'e' || items[0] == 'E' || items[items.Length - 1] == 'e' || items[items.Length - 1] == 'E')
            {
                return true;
            }

            for (int i = 0; i < items.Length; i++)
            {
                if (forbidden.Contains(items[i]) && !this.IsPartOfEpsilon(items[i], items, i))
                {
                    return true;
                }

                if (items[i] == 'e' || items[i] == 'E')
                {
                    epsilonPosition = i;
                    epsilonCounter++;
                    if (epsilonCounter > 1)
                    {
                        return true;
                    }
                }

                if (items[i] == '.')
                {
                    dotPosition = i;
                    dotCounter++;
                    if (dotCounter > 1)
                    {
                        return true;
                    }
                }
            }

            if (epsilonCounter == 1 && dotCounter == 1)
            {
                if (dotPosition < epsilonPosition && 
                    ((dotPosition != 0 && validIntegers.Contains(items[dotPosition - 1])) || dotPosition == 0)
                    && ((epsilonPosition < items.Length - 1 && validIntegers.Contains(items[epsilonPosition + 1]) || items[epsilonPosition + 1] == '-' || items[epsilonPosition + 1] == '+'))
                    )
                {
                    return false;
                }
                else
                {
                    return true;
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

        private char[] RemoveWhitespacesOnEnd(char[] items)
        {
            int counter = items.Length;
            for (int i = items.Length - 1; i >= 0; i--)
            {
                if (items[i] == ' ')
                {
                    counter--;
                }
                else
                {
                    break;
                }
            }

            if (counter < items.Length)
            {
                char[] withoutWhitespaces = new char[counter];
                this.CopyCharsFromBegining(items, counter, ref withoutWhitespaces);
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

        private void CopyCharsFromBegining(char[] items, int counter, ref char[] result)
        {
            int position = 0;
            for (int i = 0; i < counter; i++)
            {
                result[position] = items[i];
                position++;
            }
        }

        private bool IsPartOfEpsilon(char c, char[] items, int index)
        {
            if (c != 'e' && c != 'E' && c != '+' && c != '-')
            {
                return false;
            }

            if ((items[index] == 'e' || items[index] == 'E') && index + 1 < items.Length && (items[index + 1] == '+' || items[index + 1] == '-'))
            {
                return true;
            }

            if ((items[index] == '+' || items[index] == '-') && index - 1 >= 0 && (items[index - 1] == 'e' || items[index - 1] == 'E') && index + 1 < items.Length)
            {
                return true;
            }


            return false;
        }
    }
}
