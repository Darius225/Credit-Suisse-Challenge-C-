namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question6
    {

        public static int Answer(int numOfServers, int targetServer, int[,] connectionTimeMatrix)
        {
            int n = connectionTimeMatrix.GetLength(0);
            int[] bestDistances = new int[n];
            for (int i = 0; i < n; i++)
            {
                bestDistances[i] = connectionTimeMatrix[0, targetServer];
            }
            if (targetServer == 0)
            {
                return 0;
            }
            Heap paths = new Heap(numOfServers);
            paths.insert(0, 0);
       
            int ans = bestDistances[targetServer];
            bestDistances[0] = 0;
            while (!paths.isEmpty())
            {
                int[] pair = paths.extractMin();
                if (pair[1] == targetServer)
                {
                    ans = pair[0];
                }
                for (int i = 0; i < n; i++)
                {
                    if (bestDistances[i] > pair[0] + connectionTimeMatrix[pair[1], i])
                    {
                        bestDistances[i] = pair[0] + connectionTimeMatrix[pair[1], i];
                        paths.insert(i, pair[0] + connectionTimeMatrix[pair[1], i]);
                     
                    }
                }

            }
            return ans;
        }
    }
    public class Heap
    {
        int filled = 0;

        int[] values;
        int[] serverIndexes;
        int[] representationIndexes;

        public Heap(int n)
        {
            values = new int[n];
            serverIndexes = new int[n];
            representationIndexes = new int[n];
            for (int i = 0; i < n; i++)
            {
                serverIndexes[i] = -1;
            }
        }
        public bool isEmpty()
        {
            return filled == 0;
        }
        public void insert(int index, int val)
        {
            int position;
            if (serverIndexes[index] == -1)
            {
                values[filled] = val;
                serverIndexes[index] = filled;
                representationIndexes[filled] = index;
                position = filled;
                filled++;
            }
            else
            {
                if (values[serverIndexes[index]] > val)
                {
                    values[serverIndexes[index]] = val;
                }
                position = serverIndexes[index];
            }
            bottomUpMove(position);
        }
        public int[] extractMin()
        {
            int[] pair = new int[2];
            pair[0] = values[0];
            pair[1] = representationIndexes[0];
            serverIndexes[pair[1]] = -1;
            if (filled > 1)
            {
                values[0] = values[filled - 1];
                representationIndexes[0] = representationIndexes[filled - 1];
                serverIndexes[representationIndexes[0]] = 0;
                topDownMove(0);
            }
            filled--;
            return pair;
        }
        private void bottomUpMove(int indexRep)
        {
            while (values[indexRep] < values[getParent(indexRep)])
            {
                swapIndexes(indexRep, getParent(indexRep));
                indexRep = getParent(indexRep);
            }
        }
        private void topDownMove(int indexRep)
        {
            int leftCh = leftChild(indexRep);
            int rightCh = rightChild(indexRep);
            int next = indexRep;
            if (leftCh < filled)
            {
                if (values[leftCh] < values[next])
                {
                    next = leftCh;
                }
            }
            if (rightCh < filled)
            {
                if (values[rightCh] < values[next])
                {
                    next = rightCh;
                }
            }
            if (next != indexRep)
            {
                swapIndexes(next, indexRep);
                topDownMove(next);
            }
        }
        public void swapValues(int[] a, int repIndex1, int repIndex2)
        {
            a[repIndex1] = a[repIndex1] ^ a[repIndex2];
            a[repIndex2] = a[repIndex1] ^ a[repIndex2];
            a[repIndex1] = a[repIndex1] ^ a[repIndex2];
        }
        public void swapIndexes(int repIndex1, int repIndex2)
        {
            swapValues(representationIndexes, repIndex1, repIndex2);
            swapValues(values, repIndex1, repIndex2);
            serverIndexes[representationIndexes[repIndex1]] = repIndex1;
            serverIndexes[representationIndexes[repIndex2]] = repIndex2;
        }
        public int getParent(int indexRep)
        {
            return indexRep / 2;
        }
        public int leftChild(int indexRep)
        {
            return 2 * indexRep + 1;
        }
        public int rightChild(int indexRep)
        {
            return 2 * indexRep + 2;
        }
        public void displayHeap()
        {
            displayNode(0);
        }
       
    }
}