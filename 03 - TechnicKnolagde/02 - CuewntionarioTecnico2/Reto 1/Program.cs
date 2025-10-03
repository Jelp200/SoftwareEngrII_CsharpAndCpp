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
*           Consultar de una tabla Productos los productos con Stock > 20
* #############################################################################################
*/

using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        // Cadena de conexión a la base de datos
        string connStr = "Server=localhost;Database=Tienda;Trusted_Connection=True;";

        // Consulta SQL para obtener productos con Stock > 20
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            // Abrir conexion
            conn.Open();
            // Consulta SQL
            string query = "SELECT Nombre, Stock FROM Productos WHERE Stock > 20";

            // Ejecutar consulta
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            // Mostrar resultados
            while (reader.Read())
            {
                Console.WriteLine($"{reader["Nombre"]} - Stock: {reader["Stock"]}");
            }
        }
    }
}
