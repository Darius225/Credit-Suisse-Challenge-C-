namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question2
    {
        public unsafe static int Answer(int[] cashflowIn, int[] cashflowOut)
        {
            int ans = 99;
            bool[] aSums = ObtainableSums(cashflowIn);
            bool[] bSums = ObtainableSums(cashflowOut);
            ans = checkDifference(aSums, bSums, ans);
            ans = checkDifference(bSums, aSums, ans);
            return ans;
        }
        private unsafe static int min(int a, int b)
        {
            if (a < b)
            {
                return a;
            }
            return b;
        }
        private unsafe static int checkDifference(bool[] firstSums, bool[] secondSums, int ans)
        {
            int firstSum = firstSums.Length;
            int secondSum = secondSums.Length;
            for (int i = 1; i <= min(firstSum, secondSum) - 1; i++)
            {
                if (firstSums[i] == true)
                {
                    for (int j = 0; j < ans && j <= i; j++)
                    {
                        if (secondSums[i - j] == true)
                        {
                            ans = j;
                        }
                    }
                }
            }
            return ans;
        }
        private unsafe static bool[] ObtainableSums(int[] flows)
        {
            int n = flows.Length;
            int totalSum = Sum(flows);
            bool[,] obtainableSums = new bool[2, totalSum + 1];
            obtainableSums[0, 0] = true;
            obtainableSums[1, 0] = true;
            int ind = 1;
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i <= totalSum; i++)
                {
                    if (i + flows[j] <= totalSum)
                    {
                        obtainableSums[ind, i + flows[j]] |= obtainableSums[1 - ind, i];
                    }
                    obtainableSums[ind, i] |= obtainableSums[1 - ind, i];
                }
                ind = 1 - ind;
            }
            bool[] lastRow = new bool[totalSum + 1];
            for (int i = 0; i <= totalSum; i++)
            {
                lastRow[i] = obtainableSums[1 - ind, i];
            }
            return lastRow;
        }
        private unsafe static int Sum(int[] flows)
        {
            int sum = 0;
            int n = flows.Length;
            for (int i = 0; i < n; i++)
            {
                sum += flows[i];
            }
            return sum;
        }
    }
}