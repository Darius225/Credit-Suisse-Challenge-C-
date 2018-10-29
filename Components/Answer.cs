using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Sharp_Challenge_Skeleton.Components
{
    public class Answer
    {
        public string contestantName { get; set; }
        public string questionNumber { get; set; }
        public int testNumber { get; set; }
        public bool correct { get; set; }
        public double speed { get; set; }

        public Answer(string contestantName, string questionNumber, int testNumber, bool correct, double speed)
        {
            this.contestantName = contestantName;
            this.questionNumber = questionNumber;
            this.testNumber = testNumber;
            this.correct = correct;
            this.speed = speed;
        }

        public Answer()
        {

        }

    }
}
