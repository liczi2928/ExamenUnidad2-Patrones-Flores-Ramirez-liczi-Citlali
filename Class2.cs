using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EXAMENU2
{
    // CLASE: Trabajo de Impresión (objeto reutilizable)
    //objeto reutilizable dentro del patrón Object Pool.

    class TrabajoImpresion
    {

        //propiedad llamada Documento para guardar el nombre del archivo
        public string Documento { get; set; }

        //método Imprimir() 
        public void Imprimir()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n  IMPRIMIENDO Documento: {Documento}...");
            Thread.Sleep(2000); // Simula impresión
            Console.WriteLine($" {Documento} SE IMPRIMIO CORRECTAMENTE : .\n");
            Console.ResetColor();
        }
    }

    // PATRÓN: Object Pool
    // Administra los trabajos de impresión reutilizables
    class PoolTrabajos
    {
        //atributo Disponible lista que guarda los trabajos libres
        private 
            
            
            List<TrabajoImpresion> disponibles = new List<TrabajoImpresion>();

        //tomar trabajos al mismo tiempo.
        private readonly object lockObject = new object();

        //Definimos una capacidad máxima de 3 trabajos
        //(no se pueden tener más a la vez).
        private const int CAPACIDAD_MAXIMA = 3;


        // 3 objetos 
        public PoolTrabajos()
        {
            for (int i = 0; i < CAPACIDAD_MAXIMA; i++)
                disponibles.Add(new TrabajoImpresion());  //y los guarda en la lista de disponibles.

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($" {CAPACIDAD_MAXIMA} Trabajos Disponibles : .\n");
            Console.ResetColor();
        }

        public TrabajoImpresion ObtenerTrabajo(string nombreDocumento)  //Metodo 
        {
            lock (lockObject) //no tomen el mismo trabajo
            {
                if (disponibles.Count > 0)
                {
                    var trabajo = disponibles[0];
                    disponibles.RemoveAt(0);
                    trabajo.Documento = nombreDocumento;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($" '{nombreDocumento}'RESTAN : {disponibles.Count}");
                    Console.ResetColor();

                    return trabajo;
                }
                else
                {
                   
                    return null;  //Si no hay trabajos disponibles, devuelve
                }
            }
        }

        public void LiberarTrabajo(TrabajoImpresion trabajo)
        {
            lock (lockObject)
            {
                trabajo.Documento = null;  //Limpias el nombre del documento
                disponibles.Add(trabajo);  //Lo agrega de nuevo a la lista

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Trabajo devuelto ");
                Console.WriteLine($"Total disponibles: {disponibles.Count}\n");
                Console.ResetColor();
            }
        }
    }
}



