# Conocimiento Técnico (C#) :purple_square:

## Nivel básico :checkered_flag:

1. **_¿Qué es C# y en que se diferencia de C/C++?_**
    - **_R._** A diferencia de C/C++ que son lenguajes los cuales permiten tener un control más exhaustivo en bajo nivel sobre el hardware y la memoria, añadiendo a C++ la programación orientada a objetos (POO). C# es un lenguaje de alto nivel el orientado a objetos que tiene un recolector de basura para la gestión automatica de memoria y se ejecuta en la plataforma .NET

2. **_Diferencia entre Value Types y Reference Types_**
    - **_R._** En C# la diferencia entre estos dos tipos de valores consta explicitamente en el como se almacenan estos valores y cómo de comportan durante las asignaciones y las llamadas a métodos.
        - **_Value Types._**
            - Almacenamiento de datos: Almacenan sus datos directamente en su propia asignación de memoria. Normalmente se asignan en pila.
            - Asignación: Al asignar una variable de tipo de valor a otra, se crea una copia de los datos. Los cambios en una variable no afectan a la otra.
            - Valor determinado: Los tipos de valor no pueden ser nulos (a menos que se utilicen tipos que aceptan valores nulos). Por lo tanto siempre contienen un valor, incluso si es el valor predeterminado para su tipo.
            - Ejemplos: `int`, `float`, `double`, `bool`, `char`, `struct`, `enums`.

        ```cs
        // EJEMPLO DE "VALUE TYPES" EN C#
        int a = 10;     // Se asigna el valor 10 a la variable "a".
        int b = a;      // Se crea una copia del valor de la variable "a" en la variable "b".

        a = 20;         // "a" cambia a 20, "b" permanece 10

        Console.WriteLine($"a: {a}, b: {b}"); // Salida: a: 20, b: 10
        ```
