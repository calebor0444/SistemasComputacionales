using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionALaBaseDeDatos.Ejemplos
{
    internal class BusquedaPorCondicion
    {
        public static void Ejecutar()
        {
            try
            {
                using (var elContextoBd = ConexionABD.ConfigurarLaConexion())
                {
                    //Obtención de cliente por correo
                    var cliente = elContextoBd.Customers
                        .FirstOrDefault(c => c.Email == "eduardo@woodstock.com.br");

                    if (cliente != null)
                        Console.WriteLine(cliente.FirstName);
                
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
