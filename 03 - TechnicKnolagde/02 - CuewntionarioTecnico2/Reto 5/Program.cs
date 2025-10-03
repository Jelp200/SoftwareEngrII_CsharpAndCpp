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
*           Ejecuta Sensores.exe, lee temperatura y humedad, y guarda los datos en MySQL.
* #############################################################################################
*/

using System;
using System.Diagnostics;
using MySqlConnector;

class Program
{
    static void Main()
    {
        try
        {
            // Ejecutar el programa en C++
            ProcessStartInfo psi = new ProcessStartInfo("Sensores.exe")
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process p = Process.Start(psi))
            {
                string salida = p.StandardOutput.ReadToEnd().Trim();
                p.WaitForExit();

                if (string.IsNullOrWhiteSpace(salida))
                {
                    Console.WriteLine("Error: El programa Sensores.exe no devolvió datos.");
                    return;
                }

                // Parsear datos: espera formato como "Temp=23.5;Hum=60.2"
                var partes = salida.Split(';');
                if (partes.Length < 2)
                {
                    Console.WriteLine("Error: Formato de salida inválido.");
                    return;
                }

                double temp = double.Parse(partes[0].Split('=')[1]);
                double hum = double.Parse(partes[1].Split('=')[1]);

                // Guardar en MySQL
                string connStr = "Server=localhost;Port=3306;Database=CabinasDB;Uid=root;Pwd=root;";

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "INSERT INTO Lecturas (Fecha, Temperatura, Humedad) VALUES (NOW(), @t, @h)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@t", temp);
                        cmd.Parameters.AddWithValue("@h", hum);
                        cmd.ExecuteNonQuery();
                    }
                }

                Console.WriteLine($"Datos guardados: Temp={temp}°C, Hum={hum}%");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
