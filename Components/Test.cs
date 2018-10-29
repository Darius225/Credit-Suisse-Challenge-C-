using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Sharp_Challenge_Skeleton.Components
{
    public class Test<T>
    {
        public int testNumber { get; set; }
        public T input { get; set; }
        public int output { get; set; }

        public Test()
        {
        }

        public T GetInput()
        {
            return input;
        }

    }
}
