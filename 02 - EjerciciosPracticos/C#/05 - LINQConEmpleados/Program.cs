/*
* #############################################################################################
*       Archivo: Program.cs
*       Proyecto: SoftwareEngrII_CsharpAndCpp
*       SO: Windows 11
*       Herramientas:
*           - Visual Studio Code
*      Autor:
*           - Jorge Peña (Jelp200)
*       Descripción:
*           Dada una lista de empleados, obtener los nombres y montos de quienes ganan más de
*           50000, ordenados por salario descendente.
* #############################################################################################
*/

using System;
using System.Collections.Generic;
using System.Linq;

class Empleado
{
    public string Nombre { get; set; }
    public int Salario { get; set; }
}

class Program
{
    static void Main()
    {
        var empleados = new List<Empleado>
        {
            new Empleado { Nombre = "Jorge", Salario = 35000 },
            new Empleado { Nombre = "Sofia", Salario = 40000 },
            new Empleado { Nombre = "Diana", Salario = 50000 },
            new Empleado { Nombre = "Xochitl", Salario = 75000 },
            new Empleado { Nombre = "Juan", Salario = 10000 }
        };

        Console.Write("Ingrese el monto mínimo de salario a filtrar (solo se mostrarán salarios mayores que este valor): ");
        string entrada = Console.ReadLine();

        // Validar entrada
        if (!int.TryParse(entrada, out int montoMinimo))
        {
            Console.WriteLine("Entrada inválida. Se usará el valor predeterminado de 50000.");
            montoMinimo = 50000;
        }

        // Filtrar: SOLO quienes ganan MÁS que el monto mínimo (no igual)
        var resultado = empleados
            .Where(e => e.Salario > montoMinimo)
            .OrderByDescending(e => e.Salario)
            .Select(e => $"{e.Nombre} ({e.Salario:N0})");

        var listaResultado = resultado.ToList();

        if (listaResultado.Count == 0)
        {
            Console.WriteLine($"No hay empleados con salario mayor a {montoMinimo:N0}.");
        }
        else
        {
            Console.WriteLine("Empleados con salario mayor al monto especificado:");
            Console.WriteLine(string.Join(", ", listaResultado));
        }
    }
}
