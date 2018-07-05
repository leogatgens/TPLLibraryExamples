using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//namespace TaskTPL_Ccharp
//{
////    class Program1
//    {
//        static void Main(string[] args)
//        {

//            DataGenerator dataGeneratorLocal = new DataGenerator();

//            BatchGenerator batchesManager = new BatchGenerator(dataGeneratorLocal.TableOneThousandItems );

//            Task[] tasks = new Task[batchesManager.BatchCount];

//            for (int i = 0; i < 10; i++)
//            {
//                List<FormulaCodificada> actualBatch = new List<FormulaCodificada>();
                
//               actualBatch = batchesManager.batches[i] ;           

//                tasks[i] = Task<List<string>>.Factory.StartNew(() => 
//                              TrySolution1(actualBatch)
//                );
//            }
//            Console.WriteLine(tasks[0].Status.ToString()); 
//            Console.ReadKey();
//        }

//        private static List<string> TrySolution1(List<FormulaCodificada> codeList)
//        {
//            List<string> result = new List<string>();


//          result=  codeList.Select(x => x.Codigo1.Substring(0,2)).Distinct().ToList();
//            Console.WriteLine("Count :"+  result.Count.ToString());

//          return result;
//        }
//    }
//}
