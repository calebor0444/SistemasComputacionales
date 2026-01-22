internal class Program
{
    static void Main(string[] args)
    {
        var losEstudiantes = new List<string>();
        bool seDebeSalir = false;
        while (seDebeSalir == false)
        {
            MuestreLasOpciones();

            var laOpcion = Console.ReadKey(true);

            switch (laOpcion.KeyChar)
            {
                case '1':
                    Console.WriteLine("Digite el Nombre:");
                    var elValorDigitado = Console.ReadLine();
                    if (elValorDigitado != null)
                    {
                        losEstudiantes.Add(elValorDigitado);
                    }
                    Console.WriteLine("Se agregó el nombre!, digite cualquier tecla para continuar");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;

                case '2':
                    Console.Clear();
                    PinteLosEstudiantes(losEstudiantes);

                    break;
                case '3':
                    Console.WriteLine("Indique nombre a buscar:");
                    string? elNombre = Console.ReadLine();
                    if (elNombre != null)
                    {
                        bool existe = losEstudiantes.Exists(n => n == elNombre);
                        if (existe)
                            Console.WriteLine("El nombre ya existe en la lista");
                        else
                            Console.WriteLine("El nombre no existe!");

                        Console.WriteLine("Indique cualquier tecla para continuar");
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                    }
                    break;

                default:
                    seDebeSalir = true;
                    break;
            }

        }
    }

    private static void MuestreLasOpciones()
    {

        Console.WriteLine("Indique una opción:");
        Console.WriteLine("1. Agregar nombre");
        Console.WriteLine("2. Mostrar nombres");
        Console.WriteLine("3. Consultar por nombre");
    }

    private static void PinteLosEstudiantes(List<string> losEstudiantes)
    {
        Console.WriteLine("****************Estudiantes actuales*******************");
        if (losEstudiantes.Count > 0)
        {
            foreach (var item in losEstudiantes)
            {
                Console.WriteLine(item);
            }
        }
        else
            Console.WriteLine("No hay estudiantes");
    }
}
