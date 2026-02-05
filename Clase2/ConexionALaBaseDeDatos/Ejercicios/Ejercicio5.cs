using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionALaBaseDeDatos.EjerciciosResueltos
{
    internal class Ejercicio5
    {
        /// <summary>
        /// Obtiene 10 facturas y sus respectivos detalles
        /// </summary>
        public static void Ejecutar()
        {
            try
            {
                using (var elContextoBd = ConexionABD.ConfigurarLaConexion())
                {

                    var facturas = elContextoBd.Invoices
                        .Include(I => I.InvoiceLines)
                        .Take(10)
                        .ToList();

                    //var facturas2 = elContextoBd.Invoices
                    //    .Take(10)
                    //    .Select(I => new { I.InvoiceId, I.InvoiceLines })
                    //    .ToList();


                    foreach (var factura in facturas)
                    {
                        Console.WriteLine($"Invoice id: { factura.InvoiceId}");
                        Console.WriteLine("Detalle:");
                        foreach (var linea in factura.InvoiceLines)
                        {
                            Console.WriteLine($"Track id: {linea.TrackId}, Cantidad: {linea.Quantity}, " +
                                $"precio {linea.UnitPrice}, Total {linea.UnitPrice * linea.Quantity} ");
                        }
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
