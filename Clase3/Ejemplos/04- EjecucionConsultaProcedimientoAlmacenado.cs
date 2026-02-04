using ConexionALaBaseDeDatos;
using ConexionALaBaseDeDatos.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase3.Ejemplos
{
    internal class EjecucionProcedimientoAlmacenado
    {
        //Ejecución de procedimiento almacenado
        //Busqueda de cliente por correo
        public static void Ejecutar()
        {
            try
            {
                using (var elContextoBd = ConexionABD.ConfigurarLaConexion())
                {
                    string emailBuscado = "fralston@gmail.com";

                    var cliente = elContextoBd.Database
                    .SqlQuery<ClienteResultado>(
                        $"EXEC BusquePorCorreo @Email = {emailBuscado}")
                    .ToList().FirstOrDefault();

                    if (cliente != null)
                    {
                        Console.Write($"{cliente.Nombre} {cliente.Apellido} {cliente.Correo}");
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
    public class ClienteResultado
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
    }
}
