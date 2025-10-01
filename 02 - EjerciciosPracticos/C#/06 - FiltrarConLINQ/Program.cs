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
*           Dada una lista de enteros, obtener solo los pares ordenados de mayor a menor.
* #############################################################################################
*/

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] nEnteros = { 56, 85, 10, 6, 8, 22, 100, 63, 888, 444 };

        var paresOrdenados = nEnteros
            .Where(n => n % 2 == 0)                 // Filtar por numeros pares
            .OrderByDescending(n => n);             // Ordenar de mayor a menor

        Console.WriteLine(string.Join(", ", paresOrdenados));
    }
}
