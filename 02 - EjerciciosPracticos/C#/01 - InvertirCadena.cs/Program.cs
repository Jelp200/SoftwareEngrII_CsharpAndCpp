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
*           Escribe un programa en C# que invierta un string dado por el usuario sin usar
*           funciones integradas como Array.Reverse.
* #############################################################################################
*/

using System;

class Program
{
    static void Main()
    {
        Console.Write("Ingrese la cadena que desea invertir: ");
        string cadenaInvertir = Console.ReadLine() ?? string.Empty;

        // Verificamos que no sea nula o vacía
        if (string.IsNullOrEmpty(cadenaInvertir))
        {
            Console.WriteLine("La cadena está vacía.");
            return;
        }

        char[] invertido = new char[cadenaInvertir.Length];

        for (int i = 0; i < cadenaInvertir.Length; i++)
        {
            invertido[i] = cadenaInvertir[cadenaInvertir.Length - 1 - i];
        }

        Console.WriteLine("Cadena invertida: " + new string(invertido));
    }
}
