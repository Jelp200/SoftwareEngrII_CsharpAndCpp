# CUESTIONARIO TÉCNICO 1 :question:

Este cuestionario evalúa conocimientos esenciales en lenguajes de programación y bases de datos, con enfoque práctico en escenarios comunes del desarrollo de software.

Incluye ejercicios en:

- C#: manejo de hilos (`Thread`), programación asíncrona (`async/await`) y uso de expresiones lambda con delegados.
- C++: manejo de punteros, gestión dinámica de memoria y sobrecarga de operadores.
- SQL: consultas avanzadas con subconsultas correlacionadas, expresiones de tabla comunes recursivas (`CTE`), funciones de ventana y técnicas de pivoteo —todos adaptados para compatibilidad con MySQL.

Los ejemplos están diseñados para reforzar buenas prácticas, claridad del código y portabilidad entre versiones de los motores utilizados.

## :purple_square: C# - Hilos(`Threads`)

Crear un programa que ejcute dos hilos hasta el número 50:

- Primer hilo: Imprimir números pares.
- Segundo hilo: Imprimir números impares.

```cs
using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Thread hiloPares = new Thread(() =>
        {
            for (int i = 0; i <= 50; i += 2)
                Console.WriteLine($"Par: {i}");
        });

        Thread hiloImpares = new Thread(() =>
        {
            for (int i = 1; i <= 50; i += 2)
                Console.WriteLine($"Impar: {i}");
        });

        hiloPares.Start();
        hiloImpares.Start();

        hiloPares.Join();
        hiloImpares.Join();
    }
}
```

## :purple_square: C# - `async`/`await`

Simular una tarea asíncrona que espere 2 segundos y luego devuelva un mensaje:

```cs
using System;
using System.Threading.Tasks;

class Program {
    static async Task Main() {
        string resultado = await TareaAsincrona();
        Console.WriteLine(resultado);
    }

    static async Task<string> TareaAsincrona() {
        await Task.Delay(2000);
        return "Tarea completada después de 2 segundos...";
    }
}
```

## :purple_square: C# - Expresiones Lambda + Delegados

Crear un delegado que reciba dos enteros y devuelva su multiplicación. Usar una expresión lambda.

```cs
using System;

delegate int Operacion(int a, int b);

class Program {
    static void Main() {
        Operacion producto = (x, y) => x * y;
        Console.WriteLine(producto(8, 5));
    }
}
```

## :croissant: C++ - Punteros

Declarar un puntero a entero, asignarle un valor y mostrarlo en consola.

```cpp
#include <iostream>

int main()
{
    int valor = 13;
    int* ptr = &valor;

    std::cout << "Valor: " << valor << std::endl;
    std::cout << "Dirección: " << ptr << std::endl;
    std::cout << "Valor a través del puntero: " << *ptr << std::endl;

    return 0;
}
```

## :croissant: C++ - Manejo de memoria dinámica

Reservar un arreglo dinámico de 5 enteros, asignarles un valor y liberarlo.

```cpp
#include <iostream>

int main()
{
    const int TAM = 5;
    int* arreglo = new int[TAM];

    // Inicializar valores
    for (int i = 0; i < TAM; ++i)
        arreglo[i] = (i + 1) * 10;

    // Mostrar valores
    for (int i = 0; i < TAM; ++i)
        std::cout << "arreglo[" << i << "] = " << arreglo[i] << std::endl;

    // Liberar memoria
    delete[] arreglo;
    arreglo = nullptr; // Buena práctica para evitar punteros colgantes

    return 0;
}
```

## :croissant: C++ - Sobrecarga de operadores

Sobrecargar el operador `+` para sumar dos objetos de una clase `Vector2D`.

```cpp
#include <iostream>

class Vector2D
{
public:
    int x, y;

    Vector2D(int a = 0, int b = 0) : x(a), y(b) {}

    Vector2D operator+(const Vector2D& otro) const
    {
        return Vector2D(x + otro.x, y + otro.y);
    }
};

int main()
{
    Vector2D v1(2, 3), v2(4, 5);
    Vector2D v3 = v1 + v2;

    std::cout << "Resultado: (" << v3.x << ", " << v3.y << ")" << std::endl;
    return 0;
}
```

## :date: SQL - Subconsulta correlacionada

Obtener los empleados cuyo salario es mayor al promedio de su departamento.

```sql
SELECT e.Nombre, e.Salario, e.DepartamentoID
FROM Empleados e
WHERE e.Salario > (
    SELECT AVG(Salario)
    FROM Empleados
    WHERE DepartamentoID = e.DepartamentoID
);
```

## :date: SQL - CTE recursivo

Supongase que se tiene una tabla `Empleados(ID, Nombre, JefeID)`. Obtener la jerarquía de empleados empezando desde el jefe con `ID = 1`.

```sql
WITH RECURSIVE Jerarquia AS (
    -- Ancla: el jefe raíz
    SELECT ID, Nombre, JefeID, 1 AS Nivel
    FROM Empleados
    WHERE ID = 1

    UNION ALL

    -- Recursión: empleados que reportan a alguien en la jerarquía
    SELECT e.ID, e.Nombre, e.JefeID, j.Nivel + 1
    FROM Empleados e
    INNER JOIN Jerarquia j ON e.JefeID = j.ID
)
SELECT * FROM Jerarquia;
```

## :date: SQL - Window Functions

Para cada empleado, mostrar su salario y el salario promedio de su departamento en la misma fila.

```sql
SELECT Nombre, Salario,
       AVG(Salario) OVER (PARTITION BY DepartamentoID) AS PromedioDepto
FROM Empleados;
```

## :date: SQL - Pivot

Se tiene una tabla `Ventas(Empleado, Mes, Monto)`. Mostrar una tabla pivot con columnas por cada mes.

```sql
SELECT 
    Empleado,
    SUM(CASE WHEN Mes = 'Enero'   THEN Monto ELSE 0 END) AS Enero,
    SUM(CASE WHEN Mes = 'Febrero' THEN Monto ELSE 0 END) AS Febrero,
    SUM(CASE WHEN Mes = 'Marzo'   THEN Monto ELSE 0 END) AS Marzo
FROM Ventas
GROUP BY Empleado
ORDER BY Empleado;
```
