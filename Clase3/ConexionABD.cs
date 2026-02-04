using ConexionALaBaseDeDatos.ContextoBD;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace ConexionALaBaseDeDatos
{
    internal static class ConexionABD
    {
        /// <summary>
        /// Configura la conexión a la base de datos.
        /// </summary>
        internal static ChinookContext ConfigurarLaConexion()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var conn = config.GetConnectionString("Chinook");

            if (string.IsNullOrWhiteSpace(conn))
            {
                throw new InvalidOperationException("No se encontró la cadena de conexión 'Chinook' en appsettings.json");
            }

            var optionsBuilder = new DbContextOptionsBuilder<ChinookContext>();
            optionsBuilder.UseSqlServer(conn);

            return new ChinookContext(optionsBuilder.Options);
        }
    }
}
