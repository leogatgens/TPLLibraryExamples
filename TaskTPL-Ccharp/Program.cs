using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTPL_Ccharp
{
    class Program
    {
        static void Main(string[] args)
        {

            DataGenerator dataGeneratorLocal = new DataGenerator();

            BatchGenerator batchesManager = new BatchGenerator(dataGeneratorLocal.TableOneThousandItems );

            List<Task<List<string>>> tasks = new List<Task<List<string> >>();


            for (int i = 0; i < 10; i++)
            {
                List<FormulaCodificada> actualBatch = new List<FormulaCodificada>();
                
               actualBatch = batchesManager.batches[i] ;

                tasks.Add(FindAllCatalogs(actualBatch));
            }

            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            // Ignore exceptions here.
            catch (AggregateException) {


            }

            for (int ctr = 0; ctr < tasks.Count; ctr++)
            {
                if (tasks[ctr].Status == TaskStatus.RanToCompletion)
                {
                    
                    Console.WriteLine(tasks[ctr].Result.Count.ToString());
                }
                else
                    Console.WriteLine("Ocurrio un error");
            }







        }

        private static Task<List<string>> FindAllCatalogs(List<FormulaCodificada> codeInBatchList)
        {      
            return Task.Run(() => {
                List<string> result = new List<string>();


                result = codeInBatchList.Select(x => x.Codigo1.Substring(0, 2)).Distinct().ToList();
                return result;
            });
        }
    }
}
