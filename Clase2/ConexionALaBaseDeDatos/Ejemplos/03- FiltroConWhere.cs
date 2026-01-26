using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionALaBaseDeDatos.Ejemplos
{
    internal class FiltroConWhere
    {
        public static void Ejecutar()
        {
            try
            {
                using (var elContextoBd = ConexionABD.ConfigurarLaConexion())
                {
                    //Obtención de clientes que son del país de Argentina

                    //Expresión de consulta
                    var clientes = (from cliente in elContextoBd.Customers
                                    where cliente.Country == "Argentina"
                                    select cliente).ToList();


                    //Expresión de metodo
                    var losClientes = elContextoBd.Customers
                        .Where(c => c.Country == "Argentina")
                        .ToList();

                    Console.WriteLine("Clientes de argentina:");
                    foreach (var cliente in losClientes)
                    {
                        Console.WriteLine($"{cliente.FirstName} {cliente.LastName}");
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
