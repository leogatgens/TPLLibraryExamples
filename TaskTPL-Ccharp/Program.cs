using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTPL_Ccharp
{
    class Program
    {
        static void Main(string[] args)
        {

            DataGenerator dataGeneratorLocal = new DataGenerator();

            BatchGenerator batchGeneratorLocal = new BatchGenerator(dataGeneratorLocal.TableOneThousandItems );

            foreach (var batch in batchGeneratorLocal.batches)
            {
                var tasks = new Task<long>[10];
                for (int ctr = 1; ctr <= 10; ctr++)
                {
                    int delayInterval = 18 * ctr;
                    tasks[ctr - 1] = Task.Run(CalculateSomething(delayInterval));
                }
                var continuation = Task.WhenAll(tasks);
                DoAfterAllFinish(tasks, continuation);

            }

        }

        private static void DoAfterAllFinish(Task<long>[] tasks, Task<long[]> continuation)
        {
            try
            {
                continuation.Wait();
            }
            catch (AggregateException)
            { }

            if (continuation.Status == TaskStatus.RanToCompletion)
            {
                long grandTotal = 0;
                foreach (var result in continuation.Result)
                {
                    grandTotal += result;
                    Console.WriteLine("Mean: {0:N2}, n = 1,000", result / 1000.0);
                }

                Console.WriteLine("\nMean of Means: {0:N2}, n = 10,000",
                                  grandTotal / 10000);
            }
            // Display information on faulted tasks.
            else
            {
                foreach (var t in tasks)
                    Console.WriteLine("Task {0}: {1}", t.Id, t.Status);
            }
        }

        private static Func<Task<long>> CalculateSomething(int delayInterval)
        {
            return async () =>
            {
                long total = 0;
                await Task.Delay(delayInterval);
                var rnd = new Random();
                // Generate 1,000 random numbers.
                for (int n = 1; n <= 1000; n++)
                    total += rnd.Next(0, 1000);

                return total;
            };
        }
    }
}
