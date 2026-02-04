using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionALaBaseDeDatos.EjerciciosResueltos
{
    internal class Ejercicio1
    {
        /*
           Obtiene el nombre de los albums con la suma de la cantidad de canciones que posee y
         el total de duracion de todas sus canciones

             Ejemplo: Album: Big Ones, Total canciones: 15, Duración en minutos del album: 54


         ¿Qué problema ven en la consulta final generada?
         */
        public static void Ejecutar()
        {
            try
            {
                using (var elContextoBd = ConexionABD.ConfigurarLaConexion())
                {
                    var losAlbums = elContextoBd.Albums
                        .Select(a => new
                        {
                            Album = a.Title,
                            TotalCanciones = a.Tracks.Count(),
                            TotalDuracionEnMinutos = a.Tracks.Sum(t=> ((double)t.Milliseconds / 1000 / 60))
                        })
                        .ToList();

                    foreach (var album in losAlbums)
                    {
                        Console.WriteLine($"{album.Album}, Total canciones: {album.TotalCanciones}, Duración: {album.TotalDuracionEnMinutos}");
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
