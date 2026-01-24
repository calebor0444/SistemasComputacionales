using System;
using System.Linq;

namespace ConexionALaBaseDeDatos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using var elContextoBd = ConexionABD.ConfigurarLaConexion();

                var laCantidadDeArtistas = elContextoBd.Artists.Count();
                Console.WriteLine($"Artistas en la base: {laCantidadDeArtistas}");

                var primerArtista = elContextoBd.Artists.First();
                Console.WriteLine($"Primer artista: {primerArtista.Name}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
                Environment.Exit(1);
            }
        }

       
    }
}