using System.Collections.Generic;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question2
    {
        static HashSet<int> sumsObtainedWithA = new HashSet<int>();
        static HashSet<int> sumsObtainedWithB = new HashSet<int>();
        private const int upBound = 10000;
        public unsafe static int Answer(int[] cashflowIn, int[] cashflowOut)
        {

            sumsObtainedWithA = flowSums(cashflowIn);
            sumsObtainedWithB = flowSums(cashflowOut);
            int ans = 99;
            ans = findAnswer(sumsObtainedWithA, sumsObtainedWithB, ans);
            return ans;

        }
        private static unsafe HashSet<int> flowSums(int[] flows)
        {
            HashSet<int> sums = new HashSet<int>();
            int n = flows.Length;
            sums.Add(0);
            for (int i = 0; i < n; i++)
            {
                HashSet<int> newSums = new HashSet<int>();
                foreach (int sum in sums)
                {
                    int newSum = sum + flows[i];
                    if (newSum <= upBound)
                    {
                        newSums.Add(newSum);
                    }
                }
                sums.UnionWith(newSums);
            }
            return sums;
        }
        private static unsafe int findAnswer(HashSet<int> firstSet, HashSet<int> secondSet, int ansSoFar)
        {
            for (int i = 1; i <= upBound; i++)
            {
                if (firstSet.Contains(i))
                {
                    for (int j = 0; j < ansSoFar; j++)
                    {
                        if (secondSet.Contains(i - j))
                        {
                            ansSoFar = j;
                            break;
                        }
                    }
                }
            }
            return ansSoFar;
        }
    }
}