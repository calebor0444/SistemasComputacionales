\## Objetivo de la clase 1



El objetivo de esta clase es \*\*comprender y aplicar el uso de las principales colecciones de datos en .NET\*\*, analizando su comportamiento, operaciones más comunes y casos de uso típicos dentro de una aplicación de consola.



A través de estos ejercicios, el estudiante aprenderá a:

\- Declarar y manipular colecciones genéricas

\- Insertar, eliminar y ordenar elementos

\- Recorrer colecciones y mostrar información en consola

\- Comprender las diferencias entre las colecciones mas utilizadas





---



\## ¿Qué son las colecciones en .NET? (Resumen)



Las \*\*colecciones\*\* en .NET son estructuras de datos que permiten almacenar y manipular conjuntos de elementos en memoria. A diferencia de los arreglos tradicionales, las colecciones suelen ser \*\*dinámicas\*\*, es decir, pueden crecer o reducir su tamaño en tiempo de ejecución.



\### 🔹 Colecciones genéricas (`System.Collections.Generic`)

Son las más utilizadas en aplicaciones modernas. Ofrecen \*\*seguridad de tipos\*\*, mejor rendimiento y evitan errores en tiempo de ejecución.



Ejemplos comunes:

\- `List<T>` → Listas dinámicas

\- `Stack<T>` → Pilas (LIFO)

\- `Queue<T>` → Colas (FIFO)

\- `Dictionary<TKey, TValue>` → Pares clave-valor



\### 🔹 Colecciones no genéricas (`System.Collections`)

Son más antiguas y almacenan datos como `object`. Su uso no es recomendado en código nuevo.



Ejemplos:

\- `ArrayList`

\- `Hashtable`





