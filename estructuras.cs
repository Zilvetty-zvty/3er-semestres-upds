internal class Program
{
    // definicion de la estructura tipopersona para almacenar datos de estudiantes
    struct TipoPersona
    {
        public int edad;
        public string Nombre;
        public float Calificacion;
    }

    static void Main(string[] args)
    {
        TipoPersona[] estudiante = new TipoPersona[10]; // arreglo para almacenar hasta 10 estudiantes
        int opcion;
        int cantidadEstudiantes = 0; // para llevar el conteo de estudiantes registrados

        // variables auxiliares para intercambio
        string aux1 = "";
        int aux2 = 0;
        float aux3 = 0;

        do
        {
            // menu principal
            Console.WriteLine("----- menu -----");
            Console.WriteLine("1. agregar estudiantes");
            Console.WriteLine("2. buscar estudiante");
            Console.WriteLine("3. estudiante con mayor calificacion");
            Console.WriteLine("4. listar todos los estudiantes");
            Console.WriteLine("0. salir");
            Console.Write("seleccione una opcion: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("cantidad de estudiantes");
                    cantidadEstudiantes = int.Parse(Console.ReadLine());
                    for (int i = 0; i < cantidadEstudiantes; i++)
                    {
                        Console.WriteLine("nombre");
                        estudiante[i].Nombre = Console.ReadLine();
                        Console.WriteLine("edad");
                        estudiante[i].edad = int.Parse(Console.ReadLine());
                        Console.WriteLine("calificacion");
                        estudiante[i].Calificacion = float.Parse(Console.ReadLine());
                    }
                    // muestra los estudiantes registrados
                    for (int i = 0; i < cantidadEstudiantes; i++)
                    {
                        Console.WriteLine("el estudiante " + (i + 1) + " es " + estudiante[i].Nombre + " " + estudiante[i].edad + " " + estudiante[i].Calificacion);
                        Console.WriteLine("-------------------------------");
                    }
                    break;
                case 2:
                    // busqueda de estudiante por nombre
                    Console.Write("ingrese el nombre del estudiante a buscar: ");
                    string nombreBuscar = Console.ReadLine();
                    bool encontrado = false;
                    for (int i = 0; i < cantidadEstudiantes; i++)
                    {
                        // compara el nombre ignorando mayusculas/minusculas
                        if (estudiante[i].Nombre != null && estudiante[i].Nombre.Equals(nombreBuscar, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("estudiante encontrado:");
                            Console.WriteLine("nombre: " + estudiante[i].Nombre);
                            Console.WriteLine("edad: " + estudiante[i].edad);
                            Console.WriteLine("calificacion: " + estudiante[i].Calificacion);
                            encontrado = true;
                            Console.ResetColor();
                            break;
                        }
                    }
                    if (!encontrado)
                    {
                        Console.WriteLine("estudiante no encontrado.");
                    }
                    break;
                case 3:
                    // opcion para mostrar al estudiante con mas notas
                    if (cantidadEstudiantes == 0)
                    {
                        Console.WriteLine("no hay estudiantes registrados.");
                    }
                    else
                    {
                        int mayornota = 0;
                        for (int i = 1; i < cantidadEstudiantes; i++)
                        {
                            if (estudiante[i].Calificacion > estudiante[mayornota].Calificacion)
                            {
                                mayornota = i;
                            }
                            else if (estudiante[i].Calificacion == estudiante[mayornota].Calificacion)
                            {
                                // si hay empate, se muestran ambos
                                Console.ForegroundColor = (ConsoleColor.Red + i);
                                Console.WriteLine("hay un empate en la calificacion:");
                                Console.WriteLine("nombre: " + estudiante[i].Nombre);
                                Console.WriteLine("edad: " + estudiante[i].edad);
                                Console.WriteLine("calificacion: " + estudiante[i].Calificacion);
                                Console.ResetColor();
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("estudiante con mayor calificacion:");
                        Console.WriteLine("nombre: " + estudiante[mayornota].Nombre);
                        Console.WriteLine("edad: " + estudiante[mayornota].edad);
                        Console.WriteLine("calificacion: " + estudiante[mayornota].Calificacion);
                        Console.ResetColor();
                    }
                    break;
                    case 4:
                    // opcion para mostrar todos los estudiantes
                    if (cantidadEstudiantes == 0)
                    {
                        Console.WriteLine("no hay estudiantes registrados.");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("----- lista de estudiantes -----");
                        for (int i = 0; i < cantidadEstudiantes; i++)
                        {
                            Console.WriteLine("nombre: " + estudiante[i].Nombre);
                            Console.WriteLine("edad: " + estudiante[i].edad);
                            Console.WriteLine("calificacion: " + estudiante[i].Calificacion);
                            Console.WriteLine("-------------------------------");
                        }
                        Console.ResetColor();
                    }
                    break;
                case 0:
                    // opcion para salir del programa
                    Console.WriteLine("saliendo...");
                    break;
                default:
                    // opcion invalida
                    Console.WriteLine("opcion invalida.");
                    break;
            }
            for (int i = 0; i < cantidadEstudiantes - 1; i++)
            {
                for (int j = i + 1; j < cantidadEstudiantes; j++)
                {
                    if (estudiante[i].Nombre.CompareTo(estudiante[j].Nombre) > 0)
                    {
                        aux1 = estudiante[i].Nombre;
                        aux2 = estudiante[i].edad;
                        aux3 = estudiante[i].Calificacion;
                        estudiante[i].Nombre = estudiante[j].Nombre;
                        estudiante[i].edad = estudiante[j].edad;
                        estudiante[i].Calificacion = estudiante[j].Calificacion;
                        estudiante[j].Nombre = aux1;
                        estudiante[j].edad = aux2;
                        estudiante[j].Calificacion = aux3;
                    }
                }
            }
        
        } while (opcion != 0); // repite el menu hasta que el usuario decida salir

    }
}
