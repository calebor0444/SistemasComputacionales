using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionALaBaseDeDatos.EjerciciosResueltos
{
    internal class Ejercicio2
    {
        /// <summary>
        /// Canciones que contienen la palabra "feel"
        /// </summary>
        public static void Ejecutar()
        {
            try
            {
                using (var elContextoBd = ConexionABD.ConfigurarLaConexion())
                {
                    //Expresión de metodo
                    var canciones = elContextoBd.Tracks
                        .Where(c => c.Name.Contains("feel"))
                        .ToList();

                    Console.WriteLine("Canciones con la palabra feel:");
                    foreach (var cancion in canciones)
                    {
                        Console.WriteLine($"{cancion.Name}");
                    }
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
