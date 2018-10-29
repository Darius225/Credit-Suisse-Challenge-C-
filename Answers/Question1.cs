using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question1
    {
        public static int Answer(int[] portfolios)
        {
            int n = portfolios.Length;
            int ans = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int value = portfolios[i] ^ portfolios[j];
                    ans = Math.Max(ans, value);
                }
            }
            return ans;
        }
    }
}
