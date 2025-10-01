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
*           Crear un método que devuelva una lista de primos hasta un número N dado por el
*           usuario.
* #############################################################################################
*/

using System;
using System.Collections.Generic;

class Program
{
    // Método que devuelve una lista de números primos desde 2 hasta n (inclusive)
    static List<int> ObtenerPrimosHasta(int n)
    {
        List<int> primos = new List<int>();

        for (int numero = 2; numero <= n; numero++)
        {
            if (EsPrimo(numero))
            {
                primos.Add(numero);
            }
        }

        return primos;
    }

    // Método auxiliar que verifica si un número es primo
    static bool EsPrimo(int num)
    {
        if (num < 2) return false;
        if (num == 2) return true;
        if (num % 2 == 0) return false;

        for (int i = 3; i * i <= num; i += 2)
        {
            if (num % i == 0)
                return false;
        }

        return true;
    }

    // PUNTO DE ENTRADA DEL PROGRAMA
    static void Main()
    {
        Console.WriteLine("Ingrese hasta qué número desea verificar:");
        string entrada = Console.ReadLine();

        if (!int.TryParse(entrada, out int n) || n < 0)
        {
            Console.WriteLine("Por favor, ingrese un número entero no negativo.");
            return;
        }

        List<int> primos = ObtenerPrimosHasta(n);

        if (primos.Count == 0)
        {
            Console.WriteLine($"No hay números primos menores o iguales a {n}.");
        }
        else
        {
            Console.WriteLine($"Números primos hasta {n}:");
            Console.WriteLine(string.Join(", ", primos));
        }
    }
}
