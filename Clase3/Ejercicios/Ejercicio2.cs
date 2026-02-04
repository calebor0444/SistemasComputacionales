using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionALaBaseDeDatos.EjerciciosResueltos
{
    internal class Ejercicio2
    {
        /*
          Obtiene el nombre de los albums con la suma de la cantidad de canciones que posee y
        el total de duracion de todas sus canciones (Utilizar agrupamient)

            Ejemplo: Album: Big Ones, Total canciones: 15, Duración en minutos del album: 73.52

        -Obtenga la consulta generada desde el SQL Profiler

        ¿Se puede mejorar más la consulta generada?

        */
        public static void Ejecutar()
        {
            try
            {
                using (var elContextoBd = ConexionABD.ConfigurarLaConexion())
                {
                    var losAlbums = elContextoBd.Tracks
                        .GroupBy(t => new
                        {
                            t.Album.AlbumId,
                            t.Album.Title
                        })
                        .Select(g => new
                        {
                            Album = g.Key.Title,
                            TotalCanciones = g.Count(),
                            TotalDuracionEnMinutos = g.Sum(t => (double)t.Milliseconds / 60000)
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

        /*
         Recomendacion: Cuando se necesite agregaciones de una colección,
                        nunca emepzar desde el padre (Album),
                        mejor empezar desde el hijo (Track) y agrupar.
         */
    }
}
