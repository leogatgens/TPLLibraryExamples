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

            //Genera los datos
            DataGenerator dataGeneratorLocal = new DataGenerator();

            //Genera lotes
            BatchGenerator batchesManager = new BatchGenerator(dataGeneratorLocal);


            ///Genera los task
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



            Console.ReadKey();



        }

        private static Task<List<string>> FindAllCatalogs(List<FormulaCodificada> codeInBatchList)
        {      
            return Task.Run(() => {
                List<string> result = new List<string>();

                var quantity = codeInBatchList[0].Codes.Count - 1;

                for (int index = 0; index < quantity; index++)
                {

                    var tempValue = codeInBatchList.Select(x => x.Codes[index].Substring(0, 2)).Distinct().ToList();
                    result.AddRange(tempValue);
                }
                return result.Distinct().ToList();
            });
        }
    }
}
