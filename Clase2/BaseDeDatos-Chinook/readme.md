# Base de datos Chinook 
Chinook es una base de datos de ejemplo ampliamente utilizada para practicar consultas SQL y LINQ. Simula una tienda digital de música y contiene información sobre artistas, álbumes, canciones, clientes, facturas y empleados. Su estructura es lo suficientemente realista para aprender consultas intermedias sin ser excesivamente compleja.


## Dominio del negocio
La base de datos representa un sistema de venta de música donde:
- Los artistas publican álbumes.
- Los álbumes contienen canciones.
- Los clientes compran canciones mediante facturas.
- Las facturas tienen detalles de los productos comprados.
- Los empleados atienden a los clientes.

## Tablas principales

### Artist
- Almacena los artistas musicales.
- Relación: un artista puede tener muchos álbumes.

### Album
- Representa los álbumes musicales.
- Relación:
  - Pertenece a un artista.
  - Contiene múltiples canciones (tracks).

### Track
- Contiene las canciones individuales.
- Incluye datos como nombre, duración, tamaño, precio y género.
- Relación:
  - Pertenece a un álbum.
  - Puede aparecer en muchas líneas de factura.

### Genre
- Define el género musical de una canción.
- Relación: un género puede estar asociado a muchas canciones.

### MediaType
- Indica el formato del archivo (MP3, AAC, etc.).
- Relación: un tipo de medio puede aplicarse a muchas canciones.

### Customer
- Representa a los clientes de la tienda.
- Contiene información personal y de contacto.
- Relación:
  - Un cliente puede tener muchas facturas.
  - Puede estar asociado a un empleado de soporte.

### Invoice
- Representa una compra realizada por un cliente.
- Incluye fecha, total y dirección de facturación.
- Relación:
  - Pertenece a un cliente.
  - Tiene múltiples detalles de factura.

### InvoiceLine
- Detalla cada producto comprado en una factura.
- Incluye canción, cantidad y precio unitario.
- Relación:
  - Pertenece a una factura.
  - Hace referencia a una canción.

### Employee
- Representa a los empleados de la empresa.
- Incluye una relación jerárquica (empleado–supervisor).
- Relación:
  - Puede atender a varios clientes.
