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
*           Generar los n números de la serie Fibonacci usando un bucle for.
* #############################################################################################
*/

using System;

class Program
{
    static void Main()
    {
        Console.Write("Ingrese la cantidad de números de la serie Fibonacci que desea generar: ");
        string entrada = Console.ReadLine();

        // Validar entrada
        if (!int.TryParse(entrada, out int n) || n <= 0)
        {
            Console.WriteLine("Por favor, ingrese un número entero positivo.");
            return;
        }

        // Casos especiales
        if (n >= 1)
        {
            Console.Write("0");
        }
        if (n >= 2)
        {
            Console.Write(", 1");
        }

        // Si n es 1 o 2
        if (n <= 2)
        {
            Console.WriteLine(); // Salto de línea final
            return;
        }

        // Inicializar los dos primeros valores
        long a = 0, b = 1; // Usamos 'long' para evitar desbordamiento en números grandes

        // Generar del 3º al n-ésimo número
        for (int i = 3; i <= n; i++)
        {
            long c = a + b;
            Console.Write($", {c}");
            a = b;
            b = c;
        }

        Console.WriteLine(); // Salto de línea al final
    }
}
