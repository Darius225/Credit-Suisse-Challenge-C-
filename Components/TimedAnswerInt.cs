using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Sharp_Challenge_Skeleton.Components
{
    public class TimedAnswer<T>
    {
        private readonly T _returnValue;
        private readonly double _duration;

        public TimedAnswer()
        {
        }

        public TimedAnswer(T returnValue, double duration)
        {
            _returnValue = returnValue;
            _duration = duration;
        }

        public T GetReturnValue()
        {
            return _returnValue;
        }

        public double GetDuration()
        {
            return _duration;
        }
    }
}
