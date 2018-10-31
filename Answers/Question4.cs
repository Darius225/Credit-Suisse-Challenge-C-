namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question4
    {
        public static int Answer(string[,] machineToBeFixed, int numOfConsecutiveMachines)
        {
            int n = machineToBeFixed.GetLength(0);
            int m = machineToBeFixed.GetLength(1);
            int ans = 2147483647;
            for (int i = 0; i < n; i++)
            {
                int[] rowValues = new int[m];
                int counter = 0;
                int sum = 0;
                for (int j = 0; j < m; j++)
                {
                    rowValues[j] = StringIntValue(machineToBeFixed[i, j]);
                    if (rowValues[j] >= 0)
                    {
                        counter++;
                        sum += rowValues[j];
                        if (counter >= numOfConsecutiveMachines)
                        {
                            if (sum <= ans)
                            {
                                ans = sum;
                            }
                            sum -= rowValues[j - numOfConsecutiveMachines + 1];
                        }
                    }
                    else
                    {
                        counter = 0;
                        sum = 0;
                    }
                }
            }
            if (ans == 2147483647)
            {
                return 0;
            }
            return ans;
        }
        private static int StringIntValue(string s)
        {

            int ans = -1;
            if (s[0] != 'X')
            {
                ans = 0;
                int n = s.Length;
                for (int i = 0; i < n; i++)
                {
                    ans = ans * 10 + (s[i] - '0');
                }
            }
            return ans;
        }
    }
}