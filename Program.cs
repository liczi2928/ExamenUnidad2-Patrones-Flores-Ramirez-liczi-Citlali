using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EXAMENU2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            {
                Console.WriteLine("   GESTIÓN DE COLAS DE IMPRESIÓN EN RED :  \n");

                // 1 Obtener la única instancia del servidor para que no crea un nuevo servidor
                ServidorImpresion impresora = ServidorImpresion.ObtenerInstancia();
                ServidorImpresion servidor = ServidorImpresion.ObtenerInstancia();

                // 2️ Mostrar el estado de la impresora
                servidor.MostrarEstadoImpresora();

                // 3️ bucle principal de impresión 
                while (true)
                {
                    Console.Write("  Ingresa el nombre del documento a imprimir : ");
                    string nombre = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(nombre))
                    {
                        Console.WriteLine("\n Saliendo del sistema de impresión..");
                        break;
                    }

                    servidor.EnviarAImprimir(nombre);

                    //Aquí llama al método del servidor para simular la impresión del documento.
                    //El servidor toma el documento del pool de trabajos, lo imprime y luego lo libera
                }
            }
        }

    }
}
