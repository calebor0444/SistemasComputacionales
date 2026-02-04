using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionALaBaseDeDatos.Ejemplos
{
    internal class ClientesQueMasHanGastadoConAgrupamiento
    {
        public static void Ejecutar()
        {
            try
            {
                //Clientes que más dinero han gastado (suma de todas sus facturas) ordenando primero los que mas gastan.
                using (var elContextoBd = ConexionABD.ConfigurarLaConexion())
                {
                    var ClientesQueMasGastan = elContextoBd.Invoices
                        .GroupBy(i => i.Customer)
                        .Select(g => new
                        {
                            Cliente = g.Key.FirstName + " " + g.Key.LastName,
                            TotalGastado = g.Sum(i => i.Total)
                        })
                        .OrderByDescending(x => x.TotalGastado)
                        .ToList();

                    foreach (var cliente in ClientesQueMasGastan)
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
