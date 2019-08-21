using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private List<FormulaCodificada> lista = new List<FormulaCodificada>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Genera los datos
            DataGenerator dataGeneratorLocal = new DataGenerator();
            //Genera lotes
            BatchGenerator batchesManager = new BatchGenerator(dataGeneratorLocal);

            lista = dataGeneratorLocal.GenerarTablaConMilRegistros;
            dataGridView1.DataSource = lista;



        }

        private void DisplayProgress(FormulaCodificada i)
        {
            

            dataGridView1.Rows[i.IdFormulaCodificada - 1].Cells[1].Value = i.Celda;




        }

        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Prueba1FactoryconParallelForeachPorFila();
            Prueba2ForCorriente();
            //Prueba3FactoryconParallelForeachPorBloque();
            Prueba4();

        }

        private void Prueba2ForCorriente()
        {
            // Define two dates.
            DateTime date1 = DateTime.Now;
            dataGridView1.SuspendLayout();
            foreach (var item in lista)
            {

                DisplayProgress(item);
            }
            //dataGridView1.ResumeLayout(true);
            DateTime date2 = DateTime.Now;
            // Calculate the interval between the two dates.
            TimeSpan interval = date2 - date1;

            MessageBox.Show(interval.TotalSeconds.ToString());
        }

        private void Prueba1FactoryconParallelForeachPorFila()
        {
            //var ui = TaskScheduler.FromCurrentSynchronizationContext();



            dataGridView1.SuspendLayout();
            Task.Factory.StartNew(() =>
                    Parallel.ForEach(lista, (item) =>
                    {
                        // do work for i
                        this.Invoke((Action)delegate { DisplayProgress(item); });
                    })
         );

            dataGridView1.ResumeLayout(true);
        }

        private void Prueba3FactoryconParallelForeachPorBloque()
        {
            //var ui = TaskScheduler.FromCurrentSynchronizationContext();

            var lista1 = lista.Take(500000);
            var lista2 = lista.Skip(500000).Take(500000);
            //var lista3 = lista.Skip(200000).Take(100000);
            //var lista4 = lista.Skip(300000).Take(100000);
            //var lista5 = lista.Skip(400000).Take(100000);
            //var lista6 = lista.Skip(500000).Take(100000);
            //var lista7 = lista.Skip(600000).Take(100000);
            //var lista8 = lista.Skip(700000).Take(100000);
            //var lista9 = lista.Skip(800000).Take(100000);
            //var lista10 = lista.Skip(900000).Take(100000);

            dataGridView1.SuspendLayout();
            Task.Factory.StartNew(() =>
            {
                foreach (var item in lista1)
                {

                    DisplayProgress(item);
                }
            }

         );
            Task.Factory.StartNew(() =>
            {
                foreach (var item in lista2)
                {

                    DisplayProgress(item);
                }
            }

     );
            //       Task.Factory.StartNew(() =>
            //       {
            //           foreach (var item in lista3)
            //           {

            //               DisplayProgress(item);
            //           }
            //       }


            //);

            //       Task.Factory.StartNew(() => {
            //           foreach (var item in lista4)
            //           {
            //               DisplayProgress(item);
            //           }
            //       });
            //       Task.Factory.StartNew(() => {
            //           foreach (var item in lista5)
            //           {
            //               DisplayProgress(item);
            //           }
            //       });
            //       Task.Factory.StartNew(() => {
            //           foreach (var item in lista6)
            //           {
            //               DisplayProgress(item);
            //           }
            //       });
            //       Task.Factory.StartNew(() => {
            //           foreach (var item in lista7)
            //           {
            //               DisplayProgress(item);
            //           }
            //       });
            //       Task.Factory.StartNew(() => {
            //           foreach (var item in lista8)
            //           {
            //               DisplayProgress(item);
            //           }
            //       });

            //       Task.Factory.StartNew(() => {
            //           foreach (var item in lista9)
            //           {
            //               DisplayProgress(item);
            //           }
            //       });
            //       Task.Factory.StartNew(() => {
            //           foreach (var item in lista10)
            //           {
            //               DisplayProgress(item);
            //           }
            //       });


            //dataGridView1.ResumeLayout(true);
        }



        private Task<string> GenerarTaskProcesaLote(List<FormulaCodificada> listaFormulas)
        {

            return Task.Run(() => {
                string result = "exitoso";                

                foreach (var item in listaFormulas)
                {

                    DisplayProgress(item);
                }
                return result;
            });


        }

      

        
        private void Prueba4()
        {
            var ui = TaskScheduler.FromCurrentSynchronizationContext();
            DateTime date1 = DateTime.Now;
            //Genera los datos
            DataGenerator dataGeneratorLocal = new DataGenerator();

            //Genera lotes
            BatchGenerator batchesManager = new BatchGenerator(dataGeneratorLocal);


            ///Genera los task
            List<Task<string>> tasks = new List<Task<string>>();

            List<FormulaCodificada> lista1 = lista.Take(50000).ToList();
            List<FormulaCodificada> lista2 = lista.Skip(50000).Take(50000).ToList();
            //var lista3 = lista.Skip(200000).Take(100000);
            //var lista4 = lista.Skip(300000).Take(100000);
            //var lista5 = lista.Skip(400000).Take(100000);
            //var lista6 = lista.Skip(500000).Take(100000);
            //var lista7 = lista.Skip(600000).Take(100000);
            //var lista8 = lista.Skip(700000).Take(100000);
            //var lista9 = lista.Skip(800000).Take(100000);
            //var lista10 = lista.Skip(900000).Take(100000

            tasks.Add(GenerarTaskProcesaLote(lista1));
            tasks.Add(GenerarTaskProcesaLote(lista2));








            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            // Ignore exceptions here.
            catch (AggregateException)
            {


            }

            for (int ctr = 0; ctr < tasks.Count; ctr++)
            {
                if (tasks[ctr].Status == TaskStatus.RanToCompletion)
                {
                    //dataGridView1.ResumeLayout(true);
                    DateTime date2 = DateTime.Now;
                    // Calculate the interval between the two dates.
                    TimeSpan interval = date2 - date1;

                    Console.WriteLine(interval.TotalSeconds.ToString());
                    Console.WriteLine(tasks[ctr].Result.ToString());
                }
                else
                    Console.WriteLine("Ocurrio un error");
            }

        }
    }
}
