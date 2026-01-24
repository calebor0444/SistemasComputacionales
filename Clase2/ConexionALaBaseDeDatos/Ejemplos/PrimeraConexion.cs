using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionALaBaseDeDatos.Ejemplos
{
    internal class PrimeraConexion
    {
        public static void Ejecutar()
        {
            try
            {
                using (var elContextoBd = ConexionABD.ConfigurarLaConexion())
                {
                    var laCantidadDeArtistas = elContextoBd.Artists.Count();

                    Console.WriteLine($"La conexión fue satisfactoria!!, Artistas en la base chinook: {laCantidadDeArtistas}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
                Environment.Exit(1);
            }
        }
    }
}
