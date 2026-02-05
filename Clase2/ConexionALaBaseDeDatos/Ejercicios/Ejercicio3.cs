using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionALaBaseDeDatos.EjerciciosResueltos
{
    internal class Ejercicio3
    {
        /// <summary>
        /// Obtiene todas las canciones(Nombre y tamaño en bytes) que posean un tamaño mayor a 9 Megabytes
        /// </summary>
        public static void Ejecutar()
        {
            try
            {
                using (var elContextoBd = ConexionABD.ConfigurarLaConexion())
                {
                    var tamañoenBytesRequerido = 9 * 1024 * 1024;
                    //Expresión de metodo
                    var lasCanciones = elContextoBd.Tracks
                        .Select(c => new { c.Name, c.Bytes})
                        .Where(c=> c.Bytes > tamañoenBytesRequerido)
                        .ToList();

                    Console.WriteLine("Canciones que pesan mas de 9 Megabytes:");
                    foreach (var cancion in lasCanciones)
                    {
                        Console.WriteLine($"Nombre: {cancion.Name} Tamaño:{cancion.Bytes}");
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
