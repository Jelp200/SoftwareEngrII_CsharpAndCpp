/*
* #############################################################################################
*       Archivo: Program.cs
*       Proyecto: SoftwareEngrII_CsharpAndCpp
*       SO: Windows 11
*       Herramientas:
*           - Visual Studio Code
*       Autor:
*           - Jorge Peña (Jelp200)
*       Descripción:
*           Programa que ejecuta un programa en C++ (Backend) como proceso externo y captura su
*           salida.
* #############################################################################################
*/

using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        ProcessStartInfo psi = new ProcessStartInfo("Simulacion.exe")
        {
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        Process p = Process.Start(psi);
        string salida = p.StandardOutput.ReadToEnd();
        p.WaitForExit();

        Console.WriteLine("Resultado desde C++: " + salida);
    }
}
