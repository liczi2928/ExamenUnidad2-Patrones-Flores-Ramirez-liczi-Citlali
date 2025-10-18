using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EXAMENU2
{
    // PATRÓN: Singleton
    class ServidorImpresion  //Clase 
    {
        //Atributos 
        
        private static ServidorImpresion instancia;   //guardará la única instancia del servidor.
        private static readonly object lockSingleton = new object();  //bloquear el acceso intentan crear valios hilos instancia al mismo tiempo

        private readonly PoolTrabajos pool; //lista de trabajos de impresión

        // Datos del servidor 
        private readonly string modelo = "EPSON ";
        private readonly int velocidadPPM = 50;
        private bool estaEncendida = true;

        public string IP { get; private set; }   //El private solo la propia clase puede modificarlas
        public string Subred { get; private set; }
        public string Gateway { get; private set; }
        public string SSID { get; private set; }

        private ServidorImpresion()
        {
            pool = new PoolTrabajos();

            IP = "192.168.1.100";
            Subred = "255.255.255.0";
            Gateway = "192.168.1.1";
            SSID = "RedEscuela";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" La impresora principal está lista para imprimir.\n");
            Console.ResetColor();
        }
        // Patron Singleton 

        public static ServidorImpresion ObtenerInstancia()
        {
            if (instancia == null)
            {
                lock (lockSingleton)  //evitar que otros hilos la creen al mismo tiempo
                {
                    if (instancia == null)
                        instancia = new ServidorImpresion();   //Crea la instancia una sola vez
                }
            }
            return instancia;  //Devuelve esa misma instancia cada vez que se llame.
        }


        //
        //imprime en pantalla la información
        public void MostrarEstadoImpresora()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("      ESTADO DE LA IMPRESORA       ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Modelo: {modelo}");
            Console.WriteLine($"Velocidad: {velocidadPPM} ppm");
            Console.WriteLine($"Estado: {(estaEncendida ? "Encendida" : "Apagada")}");
            Console.WriteLine($"IP: {IP}");
            Console.WriteLine($"Subred: {Subred}");
            Console.WriteLine($"Gateway: {Gateway}");
            Console.WriteLine($"SSID: {SSID}");
            Console.WriteLine("--------------------------------\n");
            Console.ResetColor();
        }

        //simula enviar un archivo a la impresora
        
        public void EnviarAImprimir(string nombreDocumento)
        {
            TrabajoImpresion trabajo = pool.ObtenerTrabajo(nombreDocumento);

            if (trabajo != null)
            {
                trabajo.Imprimir();
                pool.LiberarTrabajo(trabajo);  //Si el trabajo existe, lo imprime y luego lo libera.
            }
            else
            {
                Thread.Sleep(1000); //Si no hay trabajo disponible, espera un segundo
            }
        }
    }
}




