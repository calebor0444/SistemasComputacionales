namespace Ejercicio2_PromedioDeCalificaciones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lasCalificaciones = new List<int>();

            var elRandomizador = new Random();
            int laSuma = 0;
            double elPromedio = 0;

            for (int i = 0; i < 20; i++)
            {
                var elValorRandom = elRandomizador.Next(100);

                lasCalificaciones.Add(elValorRandom);

                laSuma += elValorRandom;
            }

            var laNotaMayor = lasCalificaciones.Max();
            var laNotaMenor = lasCalificaciones.Min();

            elPromedio = laSuma / lasCalificaciones.Count;

            Console.WriteLine($"La nota mayor: {laNotaMayor}");
            Console.WriteLine($"La nota menor: {laNotaMenor}");
            Console.WriteLine($"El promedio de las notas {elPromedio}");
        }
    }
}
