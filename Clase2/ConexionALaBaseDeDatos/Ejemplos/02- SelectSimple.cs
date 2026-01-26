using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionALaBaseDeDatos.Ejemplos
{
    internal class SelectSimple
    {
        public static void Ejecutar()
        {
            try
            {
                using (var elContextoBd = ConexionABD.ConfigurarLaConexion())
                {

                    //Sintaxis de consulta
                    var clientes = (from cliente in elContextoBd.Customers
                                    select new
                                    {
                                        cliente.FirstName,
                                        cliente.LastName
                                    }).ToList();

                    //Sintaxis de metodo
                    var losClientes = elContextoBd.Customers
                        .Select(c => new
                        {
                            c.FirstName,
                            c.LastName
                        }).ToList();

                    Console.WriteLine("Clientes actuales:");
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
