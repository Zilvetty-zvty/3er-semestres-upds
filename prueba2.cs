using System;
using System.Data;
using System.Data.OleDb;
using ClosedXML.Excel;
using System.Linq;

namespace AgendaExcel
{
    using ClosedXML.Excel;


    class Program
    {
    static void EliminarFilasVacias(string ruta, string nombreHoja)
{
    using (var wb = new XLWorkbook(ruta))
    {
        var ws = wb.Worksheet(nombreHoja);

     
        for (int i = ws.LastRowUsed().RowNumber(); i >= 2; i--) // Asumiendo que la fila 1 tiene encabezados
        {
            var fila = ws.Row(i);

            // Verificar si TODAS las celdas están vacías
            if (fila.CellsUsed().All(c => string.IsNullOrWhiteSpace(c.GetString())))
            {
                fila.Delete();
            }
        }

        wb.Save();
    }
}
        static string rutaExcel = @"C:\Users\PC-LAB203-02\Desktop\cristian\prueba\Libro1.xlsx";
        static string conexionExcel =
            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\PC-LAB203-02\Desktop\cristian\prueba\Libro1.xlsx;Extended Properties='Excel 12.0 Xml;HDR=YES';";
        static void Main(string[] args)
        {
            int opcion;
            do
            {
                EliminarFilasVacias(rutaExcel, "Hoja1");
                Console.Clear();
                Console.WriteLine("===== AGENDA EN EXCEL =====");
                Console.WriteLine("1. Ingresar Datos");
                Console.WriteLine("2. Mostrar Datos");
                Console.WriteLine("3. Buscar Persona (por CI)");
                Console.WriteLine("4. Eliminar Persona (por CI)");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)) opcion = 0;

                switch (opcion)
                {
                    case 1: IngresarDatos(); break;
                    case 2: MostrarDatos(); break;
                    case 3: BuscarPersona(); break;
                    case 4: EliminarPersona(); break;
                    case 5: Console.WriteLine("Saliendo..."); break;
                    default: Console.WriteLine("Opción no válida."); break;
                }

                if (opcion != 5)
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 5);
        }

        // --- Opción 1 ---
        static void IngresarDatos()
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("CI: ");
            string ci = Console.ReadLine();

            Console.Write("Dirección: ");
            string direccion = Console.ReadLine();

            Console.Write("Teléfono: ");
            string telefono = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Profesión: ");
            string profesion = Console.ReadLine();

            using (var wb = new XLWorkbook(rutaExcel))
            {
                var ws = wb.Worksheet("Hoja1");
                var lastRow = ws.LastRowUsed()?.RowNumber() ?? 1;
                var newRow = lastRow + 1;

                ws.Cell(newRow, 1).Value = nombre;
                ws.Cell(newRow, 2).Value = ci;
                ws.Cell(newRow, 3).Value = direccion;
                ws.Cell(newRow, 4).Value = telefono;
                ws.Cell(newRow, 5).Value = email;
                ws.Cell(newRow, 6).Value = profesion;

                wb.Save();
                Console.WriteLine("Registro agregado a Excel.");
            }
        }

        // --- Opción 2 ---
        static void MostrarDatos()
        {
            using (var wb = new XLWorkbook(rutaExcel))
            {
                var ws = wb.Worksheet("Hoja1");
                Console.WriteLine("\n=== LISTA DE PERSONAS ===");
                var firstRow = ws.FirstRowUsed().RowNumber();
                var lastRow = ws.LastRowUsed().RowNumber();

                for (int i = firstRow + 1; i <= lastRow; i++)
                {
                    var fila = ws.Row(i);
                    var nombre = fila.Cell(1).GetString();
                    var ci = fila.Cell(2).GetString();
                    var direccion = fila.Cell(3).GetString();
                    var telefono = fila.Cell(4).GetString();
                    var email = fila.Cell(5).GetString();
                    var profesion = fila.Cell(6).GetString();

                    if (!string.IsNullOrWhiteSpace(nombre) ||
                        !string.IsNullOrWhiteSpace(ci) ||
                        !string.IsNullOrWhiteSpace(direccion) ||
                        !string.IsNullOrWhiteSpace(telefono) ||
                        !string.IsNullOrWhiteSpace(email) ||
                        !string.IsNullOrWhiteSpace(profesion))
                    {
                        Console.WriteLine($"Nombre: {nombre}, CI: {ci}, Dirección: {direccion}, Teléfono: {telefono}, Email: {email}, Profesión: {profesion}");
                    }
                }
            }
        }
        static void BuscarPersona()
        {
            Console.Write("Ingrese CI a buscar: ");
            string ci = Console.ReadLine();

            using (var wb = new XLWorkbook(rutaExcel))
            {
                var ws = wb.Worksheet("Hoja1");
                var firstRow = ws.FirstRowUsed().RowNumber();
                var lastRow = ws.LastRowUsed().RowNumber();
                bool encontrado = false;

                for (int i = firstRow + 1; i <= lastRow; i++)
                {
                    var fila = ws.Row(i);
                    if (fila.Cell(2).GetString().Equals(ci, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("\nPersona encontrada:");
                        Console.WriteLine($"Nombre: {fila.Cell(1).GetString()}, Dirección: {fila.Cell(3).GetString()}, Teléfono: {fila.Cell(4).GetString()}, Email: {fila.Cell(5).GetString()}, Profesión: {fila.Cell(6).GetString()}");
                        encontrado = true;
                        break;
                    }
                }
                if (!encontrado)
                {
                    Console.WriteLine("No se encontró persona con ese CI.");
                }
            }
        }

        // --- Opción 4 ---
        static void EliminarPersona()
        {
            Console.Write("Ingrese CI de la persona a eliminar: ");
            string ci = Console.ReadLine();

            using (var wb = new XLWorkbook(rutaExcel))
            {
                var ws = wb.Worksheet("Hoja1");
                var firstRow = ws.FirstRowUsed().RowNumber();
                var lastRow = ws.LastRowUsed().RowNumber();
                bool eliminado = false;

                for (int i = firstRow + 1; i <= lastRow; i++)
                {
                    var fila = ws.Row(i);
                    if (fila.Cell(2).GetString().Equals(ci, StringComparison.OrdinalIgnoreCase))
                    {
                        fila.Delete();
                        eliminado = true;
                        break;
                    }
                }
                wb.Save();
                if (eliminado)
                    Console.WriteLine("Persona eliminada.");
                else
                    Console.WriteLine("No se encontró persona con ese CI.");
            }
        }
    }
}