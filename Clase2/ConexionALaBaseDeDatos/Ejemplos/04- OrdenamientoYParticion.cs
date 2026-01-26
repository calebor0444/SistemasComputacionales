using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionALaBaseDeDatos.Ejemplos
{
    internal class OrdenamientoYParticion
    {
        public static void Ejecutar()
        {
            try
            {
                using (var elContextoBd = ConexionABD.ConfigurarLaConexion())
                {
                    //Obtención de las primeras 10 canciones ordenadas alfabeticamente

                    //Expresión de consulta
                    var clientes = (from cliente in elContextoBd.Customers
                                    where cliente.Country == "Argentina"
                                    select cliente).Take(10).ToList();


                    //Expresión de metodo
                    var lasCanciones = elContextoBd.Tracks
                        .OrderBy(c => c.Name)
                        .Select(c => c.Name)
                        .Take(10)
                        .ToList();

                    Console.WriteLine("Primeras 10 canciones en orden alfabetico:");
                    foreach (var cancion in lasCanciones)
                    {
                        Console.WriteLine($"{cancion}");
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
