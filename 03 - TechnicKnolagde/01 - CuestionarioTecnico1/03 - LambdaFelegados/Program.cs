/*
* #############################################################################################
*       Archivo: LambdaDelegados.cs
*       Proyecto: SoftwareEngrII_CsharpAndCpp
*       SO: Windows 11
*       Herramientas:
*           - Visual Studio Code
*      Autor:
*           - Jorge Peña (Jelp200)
*       Descripción:
*           Crear un delegado que reciba dos enteros y devuelva su multiplicación. Usar una
*           expresión lambda.
* #############################################################################################
*/

using System;

delegate int Operacion(int a, int b);

class Program
{
    public static void Main(string[] args)
    {
        Operacion multiplicar = (x, y) => x * y;
        Console.WriteLine(multiplicar(8, 5));
    }
}