using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Sharp_Challenge_Skeleton.Components
{
    public class Tests<T>
    {
        public string questionNumber { get; set; }
        public Test<T>[] tests { get; set; }

        public Tests()
        {
        }

    }
}
