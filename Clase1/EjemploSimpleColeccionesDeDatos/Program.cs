using System.Collections;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declara una lista generica con varios valores de entrada
            var colores = new List<string>() { "rojo", "morado" };
            colores.Add("azul");

            //Pinta colores en pantalla
            MostrarColores(colores);
            Console.WriteLine("Indique color:");
            string? elColorPorAgregar = Console.ReadLine();

            //Agrega un color si lo que digitó el usuario no es nulo
            if (elColorPorAgregar != null)
                colores.Add(elColorPorAgregar);

            Console.Clear();

            //Ordena lista de manera ascendente
            colores.Sort();

            //Inserte un elemento en indice 0
            colores.Insert(0, "verde");

            //Elimina una o varias ocurrencias
            colores.Remove("rojo");

            MostrarColores(colores);


            var laPila = new Stack<string>();
            laPila.Push("borrar");



        }

        private static void MostrarColores(List<string> colores)
        {
            //Recorrer una lista y muestra los valores
            foreach (var color in colores)
            {
                Console.WriteLine($"Color: {color}");
            }
        }

    }
}
