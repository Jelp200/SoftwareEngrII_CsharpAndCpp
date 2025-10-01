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
*           Escribir un programa en C# que verifique si una palabra es palíndromo (igual al
*           derecho y al revés).
* #############################################################################################
*/

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Ingrese la cadena que desea verificar:");
        string cadenaVerificar = Console.ReadLine();

        // Verificamos que no sea nula o vacía
        if (string.IsNullOrEmpty(cadenaVerificar))
        {
            Console.WriteLine("La cadena está vacía.");
            return;
        }

        string verificar = new string(cadenaVerificar.Reverse().ToArray());

        if (cadenaVerificar.Equals(verificar, StringComparison.OrdinalIgnoreCase))
            Console.WriteLine($"La cadena '{cadenaVerificar}' es un palíndromo.");
        else
            Console.WriteLine($"La cadena '{cadenaVerificar}' no es un palíndromo.");
    }
}
