using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionALaBaseDeDatos.EjerciciosResueltos
{
    internal class Ejercicio4
    {
        /// <summary>
        /// Obtiene clientes y su dirección que son de USA y ademas del estado de California(CA)
        /// </summary>
        public static void Ejecutar()
        {
            try
            {
                using (var elContextoBd = ConexionABD.ConfigurarLaConexion())
                {
                    
                    var clientes = elContextoBd.Customers
                        .Where(c => c.Country == "USA" && c.State == "CA");
   
                    foreach(var cliente in clientes)
                    {
                        Console.WriteLine($"{cliente.FirstName} {cliente.LastName} | {cliente.Address}");
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
