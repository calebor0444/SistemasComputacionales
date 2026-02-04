using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionALaBaseDeDatos.EjerciciosResueltos
{
    internal class Ejercicio4
    {
        //Busqueda de cliente por correo, similar al ejemplo 3 pero con objetos de entity framework
        public static void Ejecutar()
        {
            try
            {
                using (var elContextoBd = ConexionABD.ConfigurarLaConexion())
                {
                    string emailBuscado = "fralston@gmail.com";

                    var elCliente = elContextoBd.Customers.Where(c => c.Email == emailBuscado).FirstOrDefault();
                    if (elCliente != null)
                    {
                        Console.Write($"{elCliente.FirstName} {elCliente.LastName} {elCliente.Email}");
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
