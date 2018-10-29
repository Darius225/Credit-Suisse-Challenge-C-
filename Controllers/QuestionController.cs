using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using C_Sharp_Challenge_Skeleton.Answers;
using C_Sharp_Challenge_Skeleton.Beans;
using C_Sharp_Challenge_Skeleton.Components;
using Microsoft.AspNetCore.Mvc;

namespace C_Sharp_Challenge_Skeleton.Controllers
{
    [Route("api/Question")]
    public class QuestionController : Controller
    {   
        [HttpPost("/runq1")]
        public async Task<List<Answer>> QuestionNum1([FromBody] Tests<int[]> tests)
        {
            var answers = new List<Answer>();

            foreach (var test in tests.tests)
            {
                var timedAnswer = new TimedAnswer<int>();
                try
                {
                    var cancellationToken = new CancellationTokenSource();
                    cancellationToken.CancelAfter(1000);
                    await Task.Run(() => timedAnswer = getFirstAnwser(test), cancellationToken.Token);
                    var correct = timedAnswer.GetReturnValue() == test.output;
                        answers.Add(new Answer("C#", tests.questionNumber, test.testNumber, correct,
                            timedAnswer.GetDuration()));
                }
                catch (TaskCanceledException _)
                {
                    Console.WriteLine("A test in Question 1 has timed out. Tests must complete within one second.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }

            return answers;
        }

        TimedAnswer<int> getFirstAnwser(Test<int[]> test)
        {
            var timer = new Stopwatch();

            timer.Start();

            var answer = Question1.Answer(test.GetInput());

            timer.Stop();

            var timeTaken = ((double)timer.ElapsedTicks / Stopwatch.Frequency) * 1000000000;

            return new TimedAnswer<int>(answer, timeTaken);
        }

        [HttpPost("/runq2")]
        public async Task<IEnumerable<Answer>> QuestionNum2([FromBody] Tests<Cashflows> tests)
        {
            var answers = new List<Answer>();

            var cancellationToken = new CancellationTokenSource();

            cancellationToken.CancelAfter(1000);

            foreach (var test in tests.tests)
            {
                var timedAnswer = new TimedAnswer<int>();
                try
                {
                    await Task.Run(() => timedAnswer = getSecondAnwser(test), cancellationToken.Token);
                    var correct = timedAnswer.GetReturnValue() == test.output;
                    answers.Add(new Answer("C#", tests.questionNumber, test.testNumber, correct,
                            timedAnswer.GetDuration()));
                }
                catch (TaskCanceledException ex)
                {
                    Console.WriteLine("A test in Question 1 has timed out. Tests must complete within one second.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }

            return answers;
        }

        TimedAnswer<int> getSecondAnwser(Test<Cashflows> test)
        {
            var timer = new Stopwatch();

            Cashflows cashflows = test.GetInput();

            timer.Start();

            var answer = Question2.Answer(cashflows.cashFlowIn, cashflows.cashFlowOut);

            timer.Stop();

            var timeTaken = ((double)timer.ElapsedTicks / Stopwatch.Frequency) * 1000000000;

            return new TimedAnswer<int>(answer, timeTaken);
        }

        [HttpPost("/runq3")]
        public async Task<IEnumerable<Answer>> QuestionNum3([FromBody] Tests<Exchanges> tests)
        {
            var answers = new List<Answer>();

            var cancellationToken = new CancellationTokenSource();

            cancellationToken.CancelAfter(1000);

            foreach (var test in tests.tests)
            {
                var timedAnswer = new TimedAnswer<int>();
                try
                {
                    await Task.Run(() => timedAnswer = getThirdAnwser(test), cancellationToken.Token);
                    var correct = timedAnswer.GetReturnValue() == test.output;
                    answers.Add(new Answer("C#", tests.questionNumber, test.testNumber, correct,
                            timedAnswer.GetDuration()));
                }
                catch (TaskCanceledException ex)
                {
                    Console.WriteLine("A test in Question 1 has timed out. Tests must complete within one second.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }

            return answers;
        }

        TimedAnswer<int> getThirdAnwser(Test<Exchanges> test)
        {
            var timer = new Stopwatch();

            var exchanges = test.GetInput();

            timer.Start();

            var answer = Question3.Answer(exchanges.numNodes, exchanges.edges);

            timer.Stop();

            var timeTaken = ((double)timer.ElapsedTicks / Stopwatch.Frequency) * 1000000000;

            return new TimedAnswer<int>(answer, timeTaken);
        }

        [HttpPost("/runq4")]
        public async Task<IEnumerable<Answer>> QuestionNum4([FromBody] Tests<FixMachines> tests)
        {
            var answers = new List<Answer>();

            var cancellationToken = new CancellationTokenSource();

            cancellationToken.CancelAfter(1000);

            foreach (var test in tests.tests)
            {
                var timedAnswer = new TimedAnswer<int>();
                try
                {
                    await Task.Run(() => timedAnswer = getFourthAnwser(test), cancellationToken.Token);
                    var correct = timedAnswer.GetReturnValue() == test.output;
                    answers.Add(new Answer("C#", tests.questionNumber, test.testNumber, correct,
                            timedAnswer.GetDuration()));
                }
                catch (TaskCanceledException ex)
                {
                    Console.WriteLine("A test in Question 1 has timed out. Tests must complete within one second.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }

            return answers;
        }

        TimedAnswer<int> getFourthAnwser(Test<FixMachines> test)
        {
            var timer = new Stopwatch();

            var fixMachines = test.GetInput();

            timer.Start();

            var answer = Question4.Answer(fixMachines.rows, fixMachines.numberMachines);

            timer.Stop();

            var timeTaken = ((double)timer.ElapsedTicks / Stopwatch.Frequency) * 1000000000;

            return new TimedAnswer<int>(answer, timeTaken);
        }

        [HttpPost("/runq5")]
        public async Task<IEnumerable<Answer>> QuestionNum5([FromBody] Tests<StructuredTrades> tests)
        {
            var answers = new List<Answer>();

            var cancellationToken = new CancellationTokenSource();

            cancellationToken.CancelAfter(1000);

            foreach (var test in tests.tests)
            {
                var timedAnswer = new TimedAnswer<int>();
                try
                {
                    await Task.Run(() => timedAnswer = getFifthAnwser(test), cancellationToken.Token);
                    var correct = timedAnswer.GetReturnValue() == test.output;
                    answers.Add(new Answer("C#", tests.questionNumber, test.testNumber, correct,
                            timedAnswer.GetDuration()));
                }
                catch (TaskCanceledException ex)
                {
                    Console.WriteLine("A test in Question 1 has timed out. Tests must complete within one second.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }

            return answers;
        }

        TimedAnswer<int> getFifthAnwser(Test<StructuredTrades> test)
        {
            var timer = new Stopwatch();

            var structuredTrades = test.GetInput();

            timer.Start();

            var answer = Question5.Answer(structuredTrades.allowedAllocations, structuredTrades.totalValue);

            timer.Stop();

            var timeTaken = ((double)timer.ElapsedTicks / Stopwatch.Frequency) * 1000000000;

            return new TimedAnswer<int>(answer, timeTaken);
        }

        [HttpPost("/runq6")]
        public async Task<IEnumerable<Answer>> QuestionNum6([FromBody] Tests<Server> tests)
        {
            var answers = new List<Answer>();

            var cancellationToken = new CancellationTokenSource();

            cancellationToken.CancelAfter(1000);

            foreach (var test in tests.tests)
            {
                var timedAnswer = new TimedAnswer<int>();
                try
                {
                    await Task.Run(() => timedAnswer = getSixthAnwser(test), cancellationToken.Token);
                    var correct = timedAnswer.GetReturnValue() == test.output;
                    answers.Add(new Answer("C#", tests.questionNumber, test.testNumber, correct,
                            timedAnswer.GetDuration()));
                }
                catch (TaskCanceledException ex)
                {
                    Console.WriteLine("A test in Question 1 has timed out. Tests must complete within one second.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }

            return answers;
        }

        TimedAnswer<int> getSixthAnwser(Test<Server> test)
        {
            var timer = new Stopwatch();

            var server = test.GetInput();

            timer.Start();

            var answer = Question6.Answer(server.numServers, server.target, server.arcs);

            timer.Stop();

            var timeTaken = ((double)timer.ElapsedTicks / Stopwatch.Frequency) * 1000000000;

            return new TimedAnswer<int>(answer, timeTaken);
        }
    }
}
