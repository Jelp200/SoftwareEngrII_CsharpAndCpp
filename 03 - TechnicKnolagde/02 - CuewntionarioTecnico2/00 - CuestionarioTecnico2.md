# CUESTIONARIO TÉCNICO 2 :question:

## :star2: [Reto 1 - C# + SQL)](./Reto%201/)

Se desea crear una tabla llamada `Productos` con los siguientes campos `Producto_ID`, `Nombre`, `Precio` y `Stock`.

Crear un script en SQL el cual cree la tabla, uno que inserte al menos 10 productos con `Stock` diferente, y un programa en C# el cual consulte los productos con `Stock > 20` y los muestre en consola.

En primera instancia se crea la base de datos `TiendaDB` y la tabla `Productos` con la cual se trabajara.

```sql
CREATE DATABASE IF NOT EXISTS TiendaDB;
USE TiendaDB;

CREATE TABLE IF NOT EXISTS Productos(
    producto_id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    precio DECIMAL(10, 2) NOT NULL,
    stock INT NOT NULL
);
```

Se insertan los datos requeridos para trabajar.

```sql
USE TiendaDB;

INSERT INTO Productos (nombre, precio, stock) VALUES
('2N2222A', 1.07, 50),
('STM32F103C8T6', 64.00, 15),
('LM324N', 8.00, 30),
('PC817', 5.00, 40),
('7805', 2.50, 25),
('1N4007', 0.50, 100),
('ATmega328P', 75.00, 10),
('74HC595', 12.00, 20),
('CD4011BE', 6.00, 35),
('LDR', 3.00, 60);
```

| ***producto_id*** | ***nombre***  | ***precio*** | ***stock*** |
|-------------------|---------------|--------------|-------------|
|       **1**       | 2N2222A       | 1.07         | 50          |
|       **2**       | STM32F103C8T6 | 64.00        | 15          |
|       **3**       | LM324N        | 8.00         | 30          |
|       **4**       | PC817         | 5.00         | 40          |
|       **5**       | 7805          | 2.50         | 25          |
|       **6**       | 1N4007        | .50          | 100         |
|       **7**       | ATMEGA328P    | 75.00        | 10          |
|       **8**       | 74HC595       | 12.00        | 20          |
|       **9**       | CD4011BE      | 6.00         | 35          |
|       **10**      | LDR           | 3.00         | 60          |

Una vez ya que se tiene la tabla con la cual se estara trabajando, se codifica el programa en C# el cual permite consultar los productos con `Stock > 20`.

```cs
using System;
using System.Data.SqlClient;

class Program
{
    static voiud Main()
    {
        string connStr = "Server=localhost;Database=Tienda;Trusted_Connection=True;";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            string query = "SELECT Nombre, Stock FROM Productos WHERE Stock > 20";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Nombre"]} - Stock: {reader["Stock"]}");
            }
        }
    }
}
```

Siendo la consulta SQL utilizada.

```sql
USE Nombre, Stock FROM Productos WHERE Stock > 20;
```

## :star2: [Reto 2 - C++ + SQL](./Reto%202/)

Un sistema en C++ necesita consultar en la base de datos `Empleados(Nombre, Puesto, Salario)`. Escribir un pseudocódigo que se conecte vía ODBC y muestre a los empleados con `salario > 2500`.

```sql
CREATE DATABASE IF NOT EXISTS TiendaDB;
USE TiendaDB;

CREATE TABLE IF NOT EXISTS Empleados (
    empleado_id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    puesto VARCHAR(50) NOT NULL,
    salario INT NOT NULL
);
```

Se insertan los datos requeridos para trabajar.

```sql
USE TiendaDB;

INSERT INTO Empleados (Nombre, Puesto, Salario) VALUES
('Ana Gómez', 'Gerente de Tienda', 3500),
('Luis Martínez', 'Vendedor', 2500),
('Marta Rodríguez', 'Cajera', 2200),
('Carlos Sánchez', 'Encargado de Inventario', 2800),
('Sofía López', 'Asistente de Ventas', 2400);
```

Se realiza el Un sistema en C++ necesita consultar en la base de datos `Empleados(Nombre, Puesto, Salario)`. Escribir un pseudocódigo que se conecte vía ODBC y muestre a los empleados con `salario > 2500`.

```cpp
#include <iostream>
#include <sql.h>
#include <sqlext.h>

using namespace std;

int main() {
    // Conexion ODCB
    SQLHENV hEnv;
    SQLHDBC hDbc;
    SQLAllocHandle(SQL_HANDLE_ENV, SQL_NULL_HANDLE, &hEnv);
    SQLSetEnvAttr(hEnv, SQL_ATTR_ODBC_VERSION, (void*)SQL_OV_ODBC3, 0);
    SQLAllocHandle(SQL_HANDLE_DBC, hEnv, &hDbc);

    SQLConnect(hDbc, (SQLCHAR*)"Tienda", SQL_NTS,
               (SQLCHAR*)"user", SQL_NTS,
               (SQLCHAR*)"password", SQL_NTS);

    // Consulta
    SQLHSTMT hStmt;
    SQLAllocHandle(SQL_HANDLE_STMT, hDbc, &hStmt);
    SQLExecDirect(hStmt, (SQLCHAR*)"SELECT Nombre, Puesto, Salario FROM Empleados WHERE Salario > 2500", SQL_NTS);

    char nombre[50];
    double salario;
    SQLBindCol(hStmt, 1, SQL_C_CHAR, nombre, sizeof(nombre), NULL);
    SQLBindCol(hStmt, 2, SQL_C_DOUBLE, &salario, 0, NULL);

    while (SQLFetch(hStmt) == SQL_SUCCESS) {
        cout << nombre << " - $" << salario << endl;
    }

    // Liberar
    SQLFreeHandle(SQL_HANDLE_STMT, hStmt);
    SQLDisconnect(hDbc);
    SQLFreeHandle(SQL_HANDLE_DBC, hDbc);
    SQLFreeHandle(SQL_HANDLE_ENV, hEnv);
}
```

## :star2: [Reto 3 - C# + C++](./Reto%203/)

Un sistema tiene un backend en C++ que calcula datos pesados (ej. simulación física).

Se necesita de un programa en C# que ejecute el programa en C++ como proceso externo y capture su salida.

```cpp
#include <iostream>

using namespace std;

int main() {
    cout << "Simulación terminada con éxito. Resultado = 42";
    return 0;
}
```

```cs
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
```

## :star2: [Reto 4 - SQL + Logica](./Reto%204/)

Se tienen las siguientes tablas.

- `Clientes`

```sql
CREATE DATABASE IF NOT EXISTS TiendaDB;
USE TiendaDB;

CREATE TABLE IF NOT EXISTS Clientes (
    cliente_id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL
);

INSERT INTO Clientes (nombre) VALUES
('José Sánchez'),
('Fidelfa Huerta'),
('Delfino Gómez'),
('Diego Rivera'),
('Emiliano Villa');
```

| ***cliente_id*** | ***nombre***   |
|------------------|----------------|
|       **1**      | José Sánchez   |
|       **2**      | Fidelfa Huerta |
|       **3**      | Delfino Gómez  |
|       **4**      | Diego Rivera   |
|       **5**      | Emiliano Villa |

- `Ventas`

```sql
CREATE DATABASE IF NOT EXISTS TiendaDB;
USE TiendaDB;

CREATE TABLE IF NOT EXISTS Ventas (
    venta_id INT AUTO_INCREMENT PRIMARY KEY,
    cliente_id INT NOT NULL,
    monto INT NOT NULL,
    fecha DATE NOT NULL,
    FOREIGN KEY (cliente_id) REFERENCES Clientes(cliente_id)
);

INSERT INTO Ventas (cliente_id, monto, fecha) VALUES
(5, 25000, '2025-01-16'),
(4, 30000, '2025-02-15'),
(2, 15000, '2025-04-14'),
(3, 80000, '2025-06-13'),
(1, 5000, '2025-09-12');
```

| ***venta_id*** | ***cliente_id*** | ***monto*** | ***fecha*** |
|----------------|------------------|-------------|-------------|
|      **1**     | 5                | 25000       | 2025-01-16  |
|      **2**     | 4                | 30000       | 2025-02-15  |
|      **3**     | 2                | 15000       | 2025-04-14  |
|      **4**     | 3                | 80000       | 2025-06-13  |
|      **5**     | 1                | 5000        | 2025-09-12  |

Obtener el mayor gasto total en 2025.

- Consulta basica (Solo el gasto).

```sql
SELECT MAX(monto) AS MayorGasto2025
FROM Ventas
WHERE YEAR(fecha) = 2025;
```

| ***MayorGasto2025*** |
|----------------------|
| 80000                |

- Consulta avanzada (Gasto y nombre).

```sql
SELECT
    c.nombre AS Cliente,
    v.monto AS MayorGasto2025
FROM Ventas v
JOIN Clientes c ON c.cliente_id = c.cliente_id
WHERE YEAR (v.fecha) = 2025
ORDER BY v.monto DESC
LIMIT 1;
```

| ***Cliente*** | ***nombre*** |
|---------------|--------------|
|  José Sánchez | 80000        |

## :star2: [Reto 5 - Caso Full Stack](./Reto%205/)

Un sistema de control necesita.

1. C++: Enviar datos de sensores por consola (`temperatura`, `humedad`).
2. C#: Leer el output del programa en C++ y guardarlo en MySQL.
3. SQL: Consultar para obtener el promedio de la temperatura del dia.

[`Sensores.cpp`](./Reto%205/Sensores.cpp)

```cpp
#include <iostream>

int main() {
    std::cout << "Temperatura=25.4;Humedad=60.2" << std::endl;
    return 0;
}
```

[`Program.cs`](./Reto%205/Program.cs)

```cpp
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
```

Siendo la consulta en SQL la siguiente:

```sql
SELECT AVG(Temperatura) AS PromedioHoy
FROM Lecturas
WHERE CAST(Fecha AS DATE) = CAST(GETDATE() AS DATE);
```

Regresar al menu anterior [click aqui](../00%20-%20Inicio.md)
Regresar al menu de inicio [click aqui](../../README.md)
