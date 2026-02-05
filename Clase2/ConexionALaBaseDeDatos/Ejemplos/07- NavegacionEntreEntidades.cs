using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionALaBaseDeDatos.Ejemplos
{
    internal class NavegacionEntreEntidades
    {
        public static void Ejecutar()
        {
            try
            {
                using (var elContextoBd = ConexionABD.ConfigurarLaConexion())
                {
                    var facturas = elContextoBd.Invoices
                           .Select(Invoices => new
                           {
                               Invoices.InvoiceId,
                               Cliente = Invoices.Customer.FirstName + " " + Invoices.Customer.LastName,
                               Invoices.Total
                           })
                           .Take(10);

                    foreach (var factura in facturas)
                    {
                        Console.WriteLine($"ID Factura {factura.InvoiceId}, Cliente: {factura.Cliente} monto: ${factura.Total}");
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
