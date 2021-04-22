using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareasAsincronicas
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcesoSincrono();
            
            ProcesoAsincrono();
            Console.WriteLine("Presione una tecla para salir");
        }

        private static void ProcesoAsincrono()
        {
            System.Diagnostics.Stopwatch medirTiempo = new System.Diagnostics.Stopwatch();
            medirTiempo.Start();
            Console.WriteLine(string.Format("ASINCRONICO - Preparando el desayuno: {0}", DateTime.Now.ToLongTimeString()));
            Task.WaitAll(PrepararCafe_Asincrono(10), FreirHuevos_Asincrono(5), HacerJugo_Asincrono(5), TostarPan_Asincrono(3), UntarDulceDeLeche_Asincrono(1));

            medirTiempo.Stop();
            Console.WriteLine(string.Format("ASINCRONICO - Desayuno finalizado a las: {0}, en un total de {1} segundos", DateTime.Now.ToLongTimeString(), medirTiempo.Elapsed.TotalSeconds));

            Console.ReadKey();
        }
        
        private static void ProcesoSincrono()
        {
            System.Diagnostics.Stopwatch medirTiempo = new System.Diagnostics.Stopwatch();
            medirTiempo.Start();
            Console.WriteLine(string.Format("Preparando el desayuno: {0}", DateTime.Now.ToLongTimeString()));

            PrepararCafe_Sincrono(10);
            FreirHuevos_Sincrono(5);
            HacerJugo_Sincrono(5);
            TostarPan_Sincrono(3);
            UntarDulceDeLeche_Sincrono(1);

            medirTiempo.Stop();

            Console.WriteLine(string.Format("Desayuno finalizado a las: {0}, tardo un total de: {1} segundos", DateTime.Now.ToLongTimeString(), medirTiempo.Elapsed.TotalSeconds));


            Console.WriteLine("Presione una tecla para empezar el modo ASINCRONICO");
            Console.ReadKey();
        }

        private static void UntarDulceDeLeche_Sincrono(int pSegundos)
        {
            Console.WriteLine(string.Format("\tPoniendo dulce de leche a las tostadas.. a las {0}", DateTime.Now.ToLongTimeString()));
            System.Threading.Thread.Sleep(pSegundos * 1000);
            Console.WriteLine(string.Format("\tTostadas con dulces de leche... finalizado a las {0}", DateTime.Now.ToLongTimeString()));
        }

        private static void TostarPan_Sincrono(int pSegundos)
        {
            Console.WriteLine(string.Format("\tTostando panes lactales.. a las {0}", DateTime.Now.ToLongTimeString()));
            System.Threading.Thread.Sleep(pSegundos * 1000);
            Console.WriteLine(string.Format("\tPanes lactales tostados... finalizado a las {0}", DateTime.Now.ToLongTimeString()));
        }

        static void PrepararCafe_Sincrono(int pSegundos)
        {
            Console.WriteLine(string.Format("\tPreparando cafe.. a las {0}", DateTime.Now.ToLongTimeString()));
            System.Threading.Thread.Sleep(pSegundos*1000);
            Console.WriteLine(string.Format("\tCafe finalizado a las {0}", DateTime.Now.ToLongTimeString()));
        }

        static void FreirHuevos_Sincrono(int pSegundos)
        {
            Console.WriteLine(string.Format("\tHaciendo huevos fritos... ({0})", DateTime.Now.ToLongTimeString()));
            System.Threading.Thread.Sleep(pSegundos * 1000);
            Console.WriteLine(string.Format("\tHuevos fritos finalizados ({0})", DateTime.Now.ToLongTimeString()));
        }

        static void HacerJugo_Sincrono(int pSegundos)
        {
            Console.WriteLine(string.Format("\tPreparando exprimidos de naranja... ({0})", DateTime.Now.ToLongTimeString()));
            System.Threading.Thread.Sleep(pSegundos * 1000);
            Console.WriteLine(string.Format("\tJugo de naranja exprimido finalizado ({0})", DateTime.Now.ToLongTimeString()));
        }

        private static async Task<int> HacerJugo_Asincrono(int pSegundos)
        {

            await Task.Run( () =>
            {
                Console.WriteLine(string.Format("\tPreparando exprimidos de naranja... ({0})", DateTime.Now.ToLongTimeString()));
                System.Threading.Thread.Sleep(pSegundos * 1000);
                Console.WriteLine(string.Format("\tJugo de naranja exprimido finalizado ({0})", DateTime.Now.ToLongTimeString()));
            });

            return 1;
        }

        private static async Task<int> FreirHuevos_Asincrono(int pSegundos)
        {
            await Task.Run(() =>
            {
                Console.WriteLine(string.Format("\tHaciendo huevos fritos... ({0})", DateTime.Now.ToLongTimeString()));
                System.Threading.Thread.Sleep(pSegundos * 1000);
                Console.WriteLine(string.Format("\tHuevos fritos finalizados ({0})", DateTime.Now.ToLongTimeString()));
            });

            return 1;
        }

        private static async Task<int> PrepararCafe_Asincrono(int pSegundos)
        {
            int i = 0;
            await Task.Run(() =>
            {
                Console.WriteLine(string.Format("\tPreparando cafe.. a las {0}", DateTime.Now.ToLongTimeString()));
                System.Threading.Thread.Sleep(pSegundos * 1000);
                Console.WriteLine(string.Format("\tCafe finalizado a las {0}", DateTime.Now.ToLongTimeString()));
                i = 1;
            });
            return i;
        }

        private static async Task<int> UntarDulceDeLeche_Asincrono(int pSegundos)
        {
            await Task.Run(() => {
                Console.WriteLine(string.Format("\tPoniendo dulce de leche a las tostadas.. a las {0}", DateTime.Now.ToLongTimeString()));
                System.Threading.Thread.Sleep(pSegundos * 1000);
                Console.WriteLine(string.Format("\tTostadas con dulces de leche... finalizado a las {0}", DateTime.Now.ToLongTimeString()));
            });
            return 1;
        }

        private static async Task<int> TostarPan_Asincrono(int pSegundos)
        {
            await Task.Run(() => {
                Console.WriteLine(string.Format("\tTostando panes lactales.. a las {0}", DateTime.Now.ToLongTimeString()));
                System.Threading.Thread.Sleep(pSegundos * 1000);
                Console.WriteLine(string.Format("\tPanes lactales tostados... finalizado a las {0}", DateTime.Now.ToLongTimeString()));
            });

            return 1;
        }
    }
}
