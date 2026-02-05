using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionALaBaseDeDatos.Ejemplos
{
    internal class JoinSimple
    {
        public static void Ejecutar()
        {
            try
            {
                using (var elContextoBd = ConexionABD.ConfigurarLaConexion())
                {
                    var facturas = elContextoBd.Invoices
                        .Join(elContextoBd.Customers,
                            i => i.CustomerId,
                            c => c.CustomerId,
                            (i, c) => new
                            {
                                i.InvoiceId,
                                Cliente = c.FirstName + " " + c.LastName,
                                i.Total
                            })
                        .Take(10)
                        .ToList();

                    foreach (var factura in facturas)
                    {
                        Console.WriteLine($"ID Factura {factura.InvoiceId}, Cliente: {factura.Cliente} monto: ${factura.Total}");
                    }


                    //Consulta de expresion
                    var facturas2 = (from invoices in elContextoBd.Invoices
                                    join customers in elContextoBd.Customers on invoices.CustomerId equals customers.CustomerId
                                    select new
                                    {
                                        invoices.InvoiceId,
                                        Cliente = customers.FirstName + " " + customers.LastName,
                                        invoices.Total
                                    })
                                    .Take(10)
                                    .ToList();

                    
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
