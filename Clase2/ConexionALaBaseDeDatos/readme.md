# Generación automática de DbContext en .NET 8 (Entity Framework Core)

## Objetivo
Generar automáticamente el `DbContext` y las entidades de una aplicación C# a partir de una base de datos existente utilizando Entity Framework Core en .NET

---

## Requisitos previos
- Base de datos ya creada (ejemplo: Chinook)
- Motor de base de datos configurado (SQL Server en este caso)
- Proyecto de tipo Console, Web o API en C#

---

## Paso 1: Instalar los paquetes necesarios
Desde la terminal, ubicados en la carpeta del proyecto, ejecutar:

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
```

## Paso 2: Instalar la herramienta de Entity Framework

```bash
dotnet tool install --global dotnet-ef
dotnet ef --version
```


## Paso 3: Generar el DbContext y las entidades (Scaffold)


```bash
dotnet ef dbcontext scaffold "Server=NombreDeTuServidorDeSQLServer;Database=Chinook;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Entidades -c ChinookContext --use-database-names --no-onconfiguring

```

## Paso 4: Generar el DbContext y las entidades (Scaffold)

Crear o editar el archivo appsettings.json en la raíz del proyecto:

```json
{
  "ConnectionStrings": {
    "Chinook": "Server=.;Database=Chinook;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

#Importante:

En caso de que se desee volver a generar, debido a alguna modificación en la base de datos se puede
utilizar el siguiente comando con la salvedad de que todo las entidades serán reemplazadas:

```bash
dotnet ef dbcontext scaffold \
"Server=CALEBPC\SQLEXPRESS;Database=Chinook;Trusted_Connection=True;TrustServerCertificate=True;" \
Microsoft.EntityFrameworkCore.SqlServer \
-o Entidades \
-c ChinookContext \
--use-database-names \
--no-onconfiguring \
--force
```
¿Qué hace --force?

- Sobrescribe las clases existentes
- Incluye tablas nuevas
- Actualiza columnas y relaciones

Si se qusiera solo actualizar, por ejemplo agregando una tabla nueva podemos ejecutar el siguiente comando(prestar atención en -t (Nombre de la tabla):

```bash
dotnet ef dbcontext scaffold \
"Server=CALEBPC\SQLEXPRESS;Database=Chinook;Trusted_Connection=True;TrustServerCertificate=True;" \
Microsoft.EntityFrameworkCore.SqlServer \
-o Entidades \
-c ChinookContext \
--use-database-names \
--no-onconfiguring \
-t PlaylistLog

```