using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionALaBaseDeDatos.EjerciciosResueltos
{
    internal class Ejercicio3
    {
        /*
          Obtenga los artistas con mas canciones vendidas

        Pista: Utilice agrupamiento, empieza desde objeto detalle (desde donde ocurre la venta)

        Tablas: 
        InvoiceLine
        Track
        Album
        Artist

        */
        public static void Ejecutar()
        {
            try
            {
                using (var elContextoBd = ConexionABD.ConfigurarLaConexion())
                {
                    var artistaMasVendido = elContextoBd.InvoiceLines
                        .GroupBy(il => new
                        {
                            il.Track.Album.Artist.ArtistId,
                            il.Track.Album.Artist.Name
                        })
                        .Select(g => new
                        {
                            Artista = g.Key.Name,
                            CancionesVendidas = g.Count()
                        })
                        .OrderByDescending(x => x.CancionesVendidas)
                        .FirstOrDefault();

                        Console.WriteLine($"Artista: {artistaMasVendido.Artista}, Canciones vendidas: {artistaMasVendido.CancionesVendidas}");

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
