# Conocimiento Técnico (C#) :purple_square:

## Nivel básico :checkered_flag:

1. **_¿Qué es C# y en que se diferencia de C/C++?_**
    - **_R._** A diferencia de C/C++ que son lenguajes los cuales permiten tener un control más exhaustivo en bajo nivel sobre el hardware y la memoria, añadiendo a C++ la programación orientada a objetos (POO). C# es un lenguaje de alto nivel el orientado a objetos que tiene un recolector de basura para la gestión automatica de memoria y se ejecuta en la plataforma .NET

2. **_Diferencia entre Value Types y Reference Types_**
    - **_R._** En C# la diferencia entre estos dos tipos de valores consta explicitamente en el como se almacenan estos valores y cómo de comportan durante las asignaciones y las llamadas a métodos.
        - **_Value Types._**
            - **Almacenamiento de datos:** Almacenan sus datos directamente en su propia asignación de memoria. Normalmente se asignan en pila.
            - **Asignación:** Al asignar una variable de tipo de valor a otra, se crea una copia de los datos. Los cambios en una variable no afectan a la otra.
            - **Valor determinado:** Los tipos de valor no pueden ser nulos (a menos que se utilicen tipos que aceptan valores nulos). Por lo tanto siempre contienen un valor, incluso si es el valor predeterminado para su tipo.
            - **Ejemplos:** `int`, `float`, `double`, `bool`, `char`, `struct`, `enums`.

        ```cs
        // EJEMPLO DE "VALUE TYPES" EN C#
        int a = 10;     // Se asigna el valor 10 a la variable "a".
        int b = a;      // Se crea una copia del valor de la variable "a" en la variable "b".

        a = 20;         // "a" cambia a 20, "b" permanece 10

        Console.WriteLine($"a: {a}, b: {b}"); // Salida: a: 20, b: 10
        ```

        - **_Reference Types._**
            - **Almacenamiento de datos:** Almacenan una referencia (dirección de memoria) a los datos reales que se almacenan en el montón. El montón es un área de memoria más flexible que se utiliza para datos dinámicos.
            - **Asignación:** Al asignar una variable de tipo de referencia a otra, ambas variables terminan haciendo referencia al mismo objeto en memoria. Los cambios realizados en una variable se reflejarán en la otra.
            - **Valor determinado:** Los tipos de referencia pueden ser nulos, lo que significa que no apuntan a ningún objeto en memoria.
            - **Ejemplos:** `class`, `interface`, `delegate`, `array`, `string`.

        ```cs
        // EJEMPLO DE "REFERENCE TYPES" EN C#
        class MiCalse {
            public int Valor { get; set; }
        }

        MiClase obj1 = new MiClase { Valor = 10 };
        MiClase obj2 = obj1;    // "obj2" ahora hace referencia al mismo objeto que "obj1"
        obj1.Valor = 20;        // Se cambia el valor que "obj1" tenia con anterioridad

        // Salida: obj1.Valor: 20, obj2.Valor: 20
        Console.WriteLine($"obj1.Valor: {obj1.Valor}, obj2.Valor: {obj2.Valor}");
        ```

3. **_Diferencia entre `const` y `readonly`_**
    - **_R._** Tanto `const` como `readonly` permiten asignar o definir valores los cuales no pueden ser modificados después de su inicialización, pero su principal diferencia se da al momento de asignar el valor a cada una.
        - **_`const`_**
            - **Tiempo de asignación:** Se asigna en tiempo de compilación y debe ser inicializado para declararlo.
            - **Tipos de datos:** Funciona con tipos de datos básicos y primitivos, tales como números, `string` y `enums`.
            - **Almacenamiento:** Son almacenados en los metadatos del ensamblado y se incrustan directamente en el código de lenguaje intermedio (IL).
            - **Ejemplos:** Cuando el valor es verdaderamente constante y nunca cambiará, como una constante matemática (`Math.PI`) o un valor de configuración que no cambiará entre versiones.

        ```cs
        // EJEMPLO DE "CONST"
        public class EjemploConst {
            public const double PI = 3.1416;
            public const double MesesAno = 12;

            public void MostrarEjemplo() {
                // Salida: Pi es: 3.1416
                Console.WriteLine($"Pi es: {PI}");
            }
        }
        ```

        - **_`readonly`_**
            - **Tiempo de asignación:** Se puede asignar en tiempo de declaración o en el constructor de la clase, lo que permite la asignación en tiempo de ejecución.
            - **Tipos de datos:** Puede usarse con cualquier tipo de dato, incluidos tipos de referencia complejos como objetos, listas y arreglos.
            - **Almacenamiento:** Se almacenan en el heap (montón) de memoria y se cargan en tiempo de ejecución.
            - **Ejemplos:** Cuando el valor no se conoce en tiempo de compilación y debe ser asignado en el constructor, por ejemplo, basándose en la lógica del programa o los parámetros de entrada.

        ```cs
        // EJEMPLO DE "READONLY"
        public class EjemploReadonly {
            public readonly string NombreServidor;

            public EjemploReadonly(string servidor) {
                // Se puede asignar un valor en el constructor
                this.NombreServidor = servidor;
            }

            public void MostrarEjemplo() {
                // No se puede asignar un valor nuevo después del constructor
                // NombreServidor = "otro_servidor"; // Error de compilación
                Console.WriteLine($"El servidor es: {NombreServidor}");
            }
        }
        ```

4. **_¿Qué es el CLR y cuál es su función?_**
    - **_R._** CRL o Common Language Runtime, es el componente de máquina virtual del entorno .NET de Microsoft. Su función principal es gestionar la ejecución de los programas escritos en cualquiera de los lenguajes de programación compatibles con .NET, como C#, F# o Visual Basic.

5. **_¿Qué son las propiedades `get` y `set`, y para qué sirven?_**
    - **_R._** Son miembros de una clase las cuales permiten tener un mecanismo flexible para leer, escribir o calcular el campo de un valor privado.
        - **_`get`:_** Es utilizado para obtener el valor de una propiedad. Cuando se accede a la propiedad, se ejecuta el código dentro del bloque `get`. Permite implementar validaciones o cálculos antes de devolver el valor.

        ```cs
        // EJEMPLO DE CALCULO DINAMICO CON "GET"
        public class Rectangulo {
            public int Ancho { get; set; }
            public int Alto { get; set; }

            // Propiedad de solo lectura que calcula su valor
            public int MostrarArea() {
                get { return Ancho * Alto; }
            }
        }
        ```

        - **_`set`:_** Es utilizado para asignar un valor de una propiedad. Cuando se le asigna un nuevo valor a la propiedad, se ejecuta el código dentro del bloque `set`. La palabra clave `value` representa el valor que se está intentando asignar.

        ```cs
        // EJEMPLO DE VALIDACIÓN CON "SET"
        public class Producto {
            private decimal _precio; // Campo privado

            // Propiedad pública
            public decimal MostrarPrecio() {
                get { return _precio; }
                set {
                    if (value < 0) {
                        throw new ArgumentException("El precio no puede ser negativo.");
                    }
                    _precio = value;
                }
            }
        }
        ```

6. **_¿Qué diferencia hay entre `==` y `Equals()`?_**
    - **_R._** La diferencia entre el operador `==` y el método `Equals()` depende netamente del tipo de dato el cual se esté comparando: Value o Reference Type.

    | **_Característica_**           | **_Operador `==`_**                                               | **_Método `Equals()`_**                                                                                      |
    |--------------------------------|-------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------|
    | **Comportamiento por defecto** | Compara la referencia en tipos de referencia.                     | Compara la referencia en tipos de referencia.                                                                |
    | **Tipos de valor**             | Compara el valor.                                                 | Compara el valor.                                                                                            |
    | **Tipos de referencia**        | Por defecto compara la referencia, a menos que esté sobrecargado. | Por defecto compara la referencia, pero se puede anular para comparar el valor.                              |
    | **Strings**                    | Compara el valor (comportamiento sobrecargado).                   | Compara el valor (comportamiento anulado).                                                                   |
    | **Anulación/Sobrecarga**       | Puede ser sobrecargado para tipos personalizados.                 | Puede ser anulado (`override`) en clases personalizadas.                                                     |
    | **Null**                       | Es seguro comparar con `null` (`myObjeto == null`).               | Lanzará una `NullReferenceException` si el objeto sobre el que se llama es `null` (`myObjeto.Equals(null)`). |

    ```cs
    // EJEMPLO DE OPERADOR Y MÉTODO
    string str1 = "Honeywell";
    string str2 = "Honeywell";
    string str3 = new string (new char[] {'H', 'o', 'n', 'e', 'y', 'w', 'e', 'l', 'l'});

    /* Ambas comparaciones devuelven "true" porque el contenido es identico,
    aunque str1 & str3 sean objetos diferentes en la memoria. */
    bool Op = (str1 == str2);
    bool Met = str1.Equals(str3);
    ```

7. **_¿Cómo se declara una clase y un objeto en C#?_**
    - **_R._** Una clase en C# es una plantilla que permite definir las caracteristicas (atributos o campos) y comportamientos (métodos) de un tipo de objeto.
    La sintaxis básica para poder declarar una clase en C# es:
        - **_´[ModificadorDeAcceso]´_**: Define la visibilidad de la clase. Los más comunes son ´public´ (accesible desde cualquier lugar) e ´internal´ (accesible solo dentro del mismo ensamblado).
        - **_´class´_**: Es la palabra clave que indica que se está declarando una clase.
        - **_´nombreDeLaClase´_**: Es el identificador único de la clase. La convención de nombres en C# sugiere usar PascalCase (la primera letra de cada palabra en mayúscula).

    ```cs
    // SINTAXIS BÁSICA DE UNA CLASE EN C#
    [ModificadorDeAcceso] class NombreDeLaClase {
        /* MIEMBROS DE LA CLASE
        - Campos
        - Propiedades
        - Métodos
        ...
        - Etc.
        */
    }

    // ----------------------------------------------------------------------------------

    // DECLARACIÓN DE UNA CLASE EN C#
    public class Coche {
        //* MIEMBROS DE LA CLASE
        // Atributos (Campos)
        public string Color;
        public string Marca;
        public int VelocidadActual;

        // Comportamiento (Métodos)
        public void Acelerar() {
            VelocidadActual += 10;
            Console.WriteLine($"El coche acelera. Velocidad actual: {VelocidadActual}");
        }

        public void Frenar() {
            VelocidadActual -= 10;
            Console.WriteLine($"El coche frena. Velocidad actual: {VelocidadActual}");
        }
    }
    ```

    Mientras que un objeto es una instancia concreta de una clase. Para crear un objeto, se utiliza el operador ´new´. Este proceso se llama instanciación. La sintaxis para crear un objeto es:
        - **_´NombreDeLaClase´_**: Es el tipo de dato del objeto..
        - **_´nombreDelObjeto´_**: Es el nombre de la variable que contendrá la referencia al nuevo objeto.
        - **_´new´_**: La palabra clave que asigna memoria para el nuevo objeto e invoca al constructor de la clase.

    ```cs
    // SINTAXIS BÁSICA DE UN OBJETO EN C#
    NombreDeLaClase nombreDelObjeto = new NombreDeLaClase();

    // ----------------------------------------------------------------------------------

    // DECLARACIÓN DE UNA OBJETO EN C# Y USO DE SUS MIEMBROS
    // Función principal en C#
    public static void Main(string[] args) {
        // Se declara y se instancia un objeto de la clase Coche
        Coche miCoche = new Coche();

        // Se accede a los atributos y se les asignan valores
        miCoche.Marca = "Toyota";
        miCoche.Color = "Rojo";

        // Se llama a los métodos del objeto
        miCoche.Acelerar(); // Muestra: "El coche acelera. Velocidad actual: 10"
        miCoche.Acelerar(); // Muestra: "El coche acelera. Velocidad actual: 20"
        miCoche.Frenar();   // Muestra: "El coche frena. Velocidad actual: 10"
    }
    ```
