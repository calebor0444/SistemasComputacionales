using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionALaBaseDeDatos.Ejemplos
{
    internal class ClientesQueMasHanGastado
    {
        public static void Ejecutar()
        {
            try
            {
                //Clientes que más dinero han gastado (suma de todas sus facturas) ordenando primero los que mas gastan.
                using (var elContextoBd = ConexionABD.ConfigurarLaConexion())
                {

                    //Recorrido de entidades entity framework
                    var clientesConMayorGasto = elContextoBd.Customers
                        .Select(c => new
                        {
                            Cliente = c.FirstName + " " + c.LastName,
                            TotalGastado = c.Invoices.Sum(i => i.Total)
                        })
                        .OrderByDescending(x => x.TotalGastado)
                        .ToList();


                    foreach (var cliente in  clientesConMayorGasto)
                    {
                        Console.WriteLine($"{cliente.Cliente}, Total gastado: {cliente.TotalGastado}");
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
