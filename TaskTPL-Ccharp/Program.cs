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


            }

        }
    }
}
