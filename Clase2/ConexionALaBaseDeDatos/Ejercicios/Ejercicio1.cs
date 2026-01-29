using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionALaBaseDeDatos.EjerciciosResueltos
{
    internal class Ejercicio1
    {
        /// <summary>
        /// Obtiene los artistas en la base de datos
        /// </summary>
        public static void Ejecutar()
        {
            try
            {
                using (var elContextoBd = ConexionABD.ConfigurarLaConexion())
                {

                    //Sintaxis de consulta
                    var artistas = (from cliente in elContextoBd.Artists
                                    select new
                                    {
                                        cliente.Name,
                                    }).ToList();

                    //Sintaxis de metodo
                    var artistas2 = elContextoBd.Artists.OrderBy(artistas=> artistas.Name)
                        .Select(c => new
                        {
                            c.Name
                        }).ToList();

                    //artistas2.Order();

                    Console.WriteLine("Artistas actuales:");
                    foreach (var artista in artistas2)
                    {
                        Console.WriteLine($"{artista.Name}");
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
