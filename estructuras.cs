internal class Program
{
    // Definición de la estructura tipopersona para almacenar datos de estudiantes
    struct tipopersona
    {
        public int edad;
        public string Nombre;
        public float Calificacion;
    }

    static void Main(string[] args)
    {
        tipopersona[] estudiante = new tipopersona[10]; // Arreglo para almacenar hasta 10 estudiantes
        int opcion;
        int cantidadEstudiantes = 0; // Para llevar el conteo de estudiantes registrados

        do
        {
            // Menú principal
            Console.WriteLine("----- MENÚ -----");
            Console.WriteLine("1. Agregar estudiantes");
            Console.WriteLine("2. Buscar estudiante");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("cantidad de estudiantes");
                    cantidadEstudiantes= int.Parse(Console.ReadLine());
                    for (int i = 0; i < cantidadEstudiantes; i++)
                    {
                        Console.WriteLine("nombre");
                        estudiante[i].Nombre = Console.ReadLine();
                        Console.WriteLine("edad");
                        estudiante[i].edad = int.Parse(Console.ReadLine());
                        Console.WriteLine("calificacion");
                        estudiante[i].Calificacion = float.Parse(Console.ReadLine());
                    }                    // Muestra los estudiantes registrados
                    for (int i = 0; i < cantidadEstudiantes; i++)
                    {
                        Console.WriteLine("el estudiante " + (i + 1) + " es " + estudiante[i].Nombre + " " + estudiante[i].edad + " " + estudiante[i].Calificacion);
                        Console.WriteLine("-------------------------------");
                    }
                    break;
                case 2:
                    // Búsqueda de estudiante por nombre
                    Console.Write("Ingrese el nombre del estudiante a buscar: ");
                    string nombreBuscar = Console.ReadLine();
                    bool encontrado = false;
                    for (int i = 0; i < cantidadEstudiantes; i++)
                    {
                        // Compara el nombre ignorando mayúsculas/minúsculas
                        if (estudiante[i].Nombre != null && estudiante[i].Nombre.Equals(nombreBuscar, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Estudiante encontrado:");
                            Console.WriteLine("Nombre: " + estudiante[i].Nombre);
                            Console.WriteLine("Edad: " + estudiante[i].edad);
                            Console.WriteLine("Calificación: " + estudiante[i].Calificacion);
                            encontrado = true;
                            Console.ResetColor();
                            break;
                        }
                    }
                    if (!encontrado)
                    {
                        Console.WriteLine("Estudiante no encontrado.");
                    }
                    break;
                case 0:
                    // Opción para salir del programa
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    // Opción inválida
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        } while (opcion != 0); // Repite el menú hasta que el usuario decida salir
    }
}
