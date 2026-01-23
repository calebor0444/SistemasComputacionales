namespace Ejercicio4_TurnosDeAtencion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> fila = new Queue<string>();

            Console.WriteLine("=== Sistema de turnos de atención ===\n");
            Console.WriteLine("Comandos disponibles:");
            Console.WriteLine("1 Agregar persona a la fila");
            Console.WriteLine("2 Atender a la siguiente persona");
            Console.WriteLine("3 Ver estado actual de la fila");
            Console.WriteLine("0 Salir\n");

            while (true)
            {
                Console.Write("Ingrese opción (0-3): ");
                string opcion = Console.ReadLine()?.Trim();

                switch (opcion)
                {
                    case "1":
                        AgregarPersona(fila);
                        break;

                    case "2":
                        AtenderPersona(fila);
                        break;

                    case "3":
                        MostrarFila(fila);
                        break;

                    case "0":
                        Console.WriteLine("\n¡Gracias por usar el sistema! Hasta luego.");
                        return;

                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.\n");
                        break;
                }

                Console.WriteLine();
            }

        }
        static void AgregarPersona(Queue<string> fila)
        {
            Console.Write("Nombre de la persona: ");
            string? nombre = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("Nombre no válido. Intente nuevamente.");
                return;
            }

            fila.Enqueue(nombre);
            Console.WriteLine($"> {nombre} se ha agregado a la fila. Posición actual: {fila.Count}");
        }

        static void AtenderPersona(Queue<string> fila)
        {
            if (fila.Count == 0)
            {
                Console.WriteLine("No hay nadie en la fila.");
                return;
            }

            string atendido = fila.Dequeue();
            Console.WriteLine($"→ Atendiendo a: {atendido}");
            Console.WriteLine($"Personas restantes en fila: {fila.Count}");
        }

        static void MostrarFila(Queue<string> fila)
        {
            if (fila.Count == 0)
            {
                Console.WriteLine("La fila está vacía.");
                return;
            }

            Console.WriteLine("\nEstado actual de la fila (orden de atención):");
            int posicion = 1;
            foreach (string persona in fila)
            {
                Console.WriteLine($"  {posicion}. {persona}");
                posicion++;
            }
        }
    }
}