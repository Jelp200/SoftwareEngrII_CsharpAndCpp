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
*           Escribe un programa en C# el cual ejecute dos hilos hasta el número 50.
*               - Primer hilo: Imprimir números pares.
*               - Segundo hilo: Imprimir números impares.
* #############################################################################################
*/

using System;
using System.Threading;

class Program
{
    static void Main()
    {
        // Hilo para imprimir numeros pares
        Thread hiloPares = new Thread(() =>
        {
            for (int i = 0; i <= 50; i += 2)
                Console.WriteLine($"Par: {i}");
        });
        // Hilo para imprimir numeros impares
        Thread hiloImpares = new Thread(() =>
        {
            for (int i = 1; i <= 50; i += 2)
                Console.WriteLine($"Impar: {i}");
        });
        
        // Iniciar ambos hilos
        hiloPares.Start();
        hiloImpares.Start();

        // Esperar a que ambos hilos terminen
        hiloPares.Join();
        hiloImpares.Join();
    }
}