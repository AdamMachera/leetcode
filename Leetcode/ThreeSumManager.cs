using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class ThreeSumManager
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = new System.Collections.Generic.List<System.Collections.Generic.IList<int>>();

            System.Collections.Generic.Dictionary<int, int> pluses = new System.Collections.Generic.Dictionary<int, int>();
            System.Collections.Generic.Dictionary<int, int> minuses = new System.Collections.Generic.Dictionary<int, int>();
            int zerosCount = 0;
            int largestNumber = 0;
            int lowestNumber = 0;

            if (nums.Length < 3)
            {
                return new List<IList<int>>();
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                {
                    if (!minuses.ContainsKey(nums[i]))
                    {
                        minuses.Add(nums[i], 1);
                    }
                    else
                    {
                        minuses[nums[i]]++;
                    }

                    if (nums[i] < lowestNumber)
                    {
                        lowestNumber = nums[i];
                    }
                }
                else if (nums[i] > 0)
                {
                    if (!pluses.ContainsKey(nums[i]))
                    {
                        pluses.Add(nums[i], 1);
                    }
                    else
                    {
                        pluses[nums[i]]++;
                    }
                    if (nums[i] > largestNumber)
                    {
                        largestNumber = nums[i];
                    }
                }
                else
                {
                    zerosCount++;
                }
            }

            if (zerosCount > 0)
            {
                //it means that we need to compare plus with minus
                if (zerosCount >= 3)
                {
                    this.AddIfNotExists(0, 0, 0, result);
                }

                foreach (int i in minuses.Keys)
                {
                    if (pluses.ContainsKey(System.Math.Abs(i)))
                    {
                        this.AddIfNotExists(i, 0, System.Math.Abs(i), result);
                    }
                }
            }

            this.SumTwo(largestNumber, pluses, lowestNumber, minuses, result);

            return result;
        }

        private void AddIfNotExists(int a, int b, int c, System.Collections.Generic.IList<IList<int>> result)
        {
            if (result.Count(x => x[0] == a && x[1] == b && x[2] == c) == 0)
            {
                result.Add(new List<int> { a, b, c });
            }
        }

        private void SumTwo(int largest, System.Collections.Generic.Dictionary<int, int> pluses, int lowest, System.Collections.Generic.Dictionary<int, int> minuses, System.Collections.Generic.IList<IList<int>> result)
        {
            foreach (var item in minuses)
            {
                if (item.Value > 1 && pluses.ContainsKey(Math.Abs(item.Key * 2)))
                {
                    this.AddIfNotExists(item.Key, item.Key, Math.Abs(item.Key * 2), result);
                }

                foreach (var inner in minuses)
                {
                    if (item.Key == inner.Key)
                    {
                        continue;
                    }
                    else
                    {
                        if (pluses.ContainsKey(Math.Abs(item.Key) + Math.Abs(inner.Key)))
                        {
                            this.AddIfNotExists(item.Key < inner.Key ? item.Key : inner.Key, item.Key < inner.Key ? inner.Key : item.Key, Math.Abs(item.Key) + Math.Abs(inner.Key), result);
                        }
                    }
                }
            }

            foreach (var item in pluses)
            {
                if (item.Value > 1 && minuses.ContainsKey(item.Key * -2))
                {
                    this.AddIfNotExists(item.Key * -2, item.Key, item.Key, result);
                }
                foreach (var inner in pluses)
                {
                    if (item.Key == inner.Key)
                    {
                        continue;
                    }
                    else
                    {
                        if (minuses.ContainsKey((item.Key * -1) + (inner.Key * -1)))
                        {
                            this.AddIfNotExists((item.Key + inner.Key)*(-1), item.Key > inner.Key ? inner.Key : item.Key, item.Key > inner.Key ? item.Key : inner.Key, result);
                        }
                    }
                }
            }
        }
    }
}
