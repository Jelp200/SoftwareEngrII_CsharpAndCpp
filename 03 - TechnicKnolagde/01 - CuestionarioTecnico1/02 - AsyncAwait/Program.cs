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
*           Escribir un programa el cual simule una tarea asíncrona que espere 2 segundos y
*           luego devuelva un mensaje.
* #############################################################################################
*/

using System;
using System.Threading.Tasks;

class Program
{
    // Método que simula una tarea asíncrona
    static async Task Main()
    {
        string resultado = await TareaAsincrona();
        Console.WriteLine(resultado);
    }

    // Método que espera 2 segundos y devuelve un mensaje
    static async Task<string> TareaAsincrona()
    {
        await Task.Delay(2000);
        return "Tarea completada después de 2 segundos...";
    }
}
