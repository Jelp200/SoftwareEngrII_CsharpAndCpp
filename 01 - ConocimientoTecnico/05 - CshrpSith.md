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
        - **_`[ModificadorDeAcceso]`_**: Define la visibilidad de la clase. Los más comunes son `public` (accesible desde cualquier lugar) e `internal` (accesible solo dentro del mismo ensamblado).
        - **_`class`_**: Es la palabra clave que indica que se está declarando una clase.
        - **_`nombreDeLaClase`_**: Es el identificador único de la clase. La convención de nombres en C# sugiere usar PascalCase (la primera letra de cada palabra en mayúscula).

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

    Mientras que un objeto es una instancia concreta de una clase. Para crear un objeto, se utiliza el operador `new`. Este proceso se llama instanciación. La sintaxis para crear un objeto es:
        - **_`NombreDeLaClase`_**: Es el tipo de dato del objeto.
        - **_`nombreDelObjeto`_**: Es el nombre de la variable que contendrá la referencia al nuevo objeto.
        - **_`new`_**: La palabra clave que asigna memoria para el nuevo objeto e invoca al constructor de la clase.

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

8. **_¿Qué diferencia hay entre `public`, `private`, `protected` e `internal`?_**
    - **_R._** Todos ellos son modificadores de acceso que controlan la visivilidad de tipos (clases, interfaces, etc.) y miembros (campos, métodos, propiedades).
        - **_`public`_**
            - **Alcance:** Como lo dice su nombre, es el acceso público a los miembros y el más permisivo ya que no tiene restricciones.
            - **Visibilidad:** Son accesibles desde cualquier lugar del código, incluso desde otros ensamblados (proyectos).

        ```cs
        public class Coche {
            public string Marca { get; set; } // Accesible desde cualquier lugar
        }
        ```

        - **_`private`_**
            - **Alcance:** El más restrictivo. El acceso está limitado a la clase que lo contiene.
            - **Visibilidad:** No es accesible por código externo, ni siquiera por clases derivadas (herederas).

        ```cs
        public class Coche {
            private decimal _precio; // Solo accesible dentro de la clase Coche
        }
        ```

        - **_`protected`_**
            - **Alcance:** Permite el acceso desde la clase que lo contiene y desde cualquier clase derivada (subclase), independientemente del ensamblado en el que se encuentre.
            - **Visibilidad:** Funciona como `private` para cualquier código que no esté relacionado con la jerarquía de herencia.

        ```cs
        public class Vehiculo {
            protected int NumeroDeRuedas; // Accesible por clases derivadas

            public void MostrarRuedas() {
                Console.WriteLine($"Número de ruedas: {NumeroDeRuedas}");
            }
        }

        public class Bicicleta : Vehiculo {
            public Bicicleta() {
                NumeroDeRuedas = 2; // Acceso permitido
            }
        }
        ```

        - **_`internal`_**
            - **Alcance:** El acceso está limitado al ensamblado actual.
            - **Visibilidad:** Los miembros `internal` son accesibles desde cualquier lugar dentro del mismo proyecto, pero no desde otros proyectos (salvo que se usen atributos especiales).

        ```cs
        // En el proyecto "MiProyecto"
        internal class Helper {
            // ...
        }

        // En otro proyecto que referencia a "MiProyecto"
        // Helper miHelper = new Helper(); // Esto causará un error de compilación
        ```

        | **_Modificador_**    | **_Clase contenedora_** | **_Clase derivada (mismo ensamblado)_** | **_Clase derivada (otro ensamblado)_** | **_Clase no derivada (mismo ensamblado)_** | **_Clase derivada (otro ensamblado)_** |
        |----------------------|-------------------------|-----------------------------------------|----------------------------------------|--------------------------------------------|----------------------------------------|
        | `public`             |            ✅            |                    ✅                    |                    ✅                   |                      ✅                     |                    ✅                   |
        | `private`            |            ✅            |                    ❌                    |                    ❌                   |                      ❌                     |                    ❌                   |
        | `protected`          |            ✅            |                    ✅                    |                    ✅                   |                      ❌                     |                    ❌                   |
        | `internal`           |            ✅            |                    ✅                    |                    ❌                   |                      ✅                     |                    ❌                   |
        | `protected internal` |            ✅            |                    ✅                    |                    ✅                   |                      ✅                     |                    ❌                   |
        | `private protected`  |            ✅            |                    ✅                    |                    ❌                   |                      ❌                     |                    ❌                   |

9. **_¿Qué es un constructor y cuántos tipos hay?_**
    - **_R._** Un constructor es un método especial dentro de una clase que se ejecuta automáticamente cuando se crea una nueva instancia de esa clase. Su función principal es inicializar el estado del objeto recién creado, es decir, asignar valores iniciales a sus campos o propiedades. Debe tener las siguientes caracteristicas:
        - Debe tener el **mismo nombre que la clase** a la que pertenece.
        - **No tiene tipo de retorno**, ni siquiera `void`.
        - Puede tener **parámetros o no**, lo que permite diferentes formas de inicializar el objeto.

    Los tipos de constructores que existen son:
        - **Constructor predeterminado (por defecto):** Es un constructor sin parámetros. Si no se define ningún constructor en la clase, el compilador de C# crea automáticamente uno por defecto.
        La función de este tipo de constructor es inicializar los campos de la clase con sus valores por defecto (ej. `0` para tipos numéricos, `null` para tipos de referencia).
        - **Constructor con parámetros:** Acepta uno o más parámetros, lo que permite inicializar un objeto con valores específicos al momento de su creación. Se utiliza para forzar la asignación de datos necesarios al instanciar un objeto.
        - **Constructor privado:** Es un constructor que tiene el modificador de acceso `private`. Se utiliza para evitar que una clase sea instanciada desde fuera de ella misma. Esto es útil para clases que contienen solo miembros estáticos, o para implementar el patrón de diseño Singleton.
        - **Constructor estático:** Es un constructor especial que se declara con el modificador `static`.  Se ejecuta una sola vez, la primera vez que se accede a la clase o a cualquiera de sus miembros estáticos, antes de cualquier otra acción. Se utiliza para inicializar campos estáticos y no puede tener modificadores de acceso ni parámetros.
        - **Constructor de copia:** No es un tipo de constructor incorporado como en otros lenguajes (ej. C++), pero se puede implementar manualmente. Es un constructor que toma como parámetro un objeto de la misma clase para inicializar un nuevo objeto con los mismos valores. Crea una copia de un objeto existente.

10. **_¿Qué es un namespace y por qué se usa?_**
    - **_R._** Es un contenedor lógico que se utiliza para organizar y agrupar tipos de datos relacionados, como clases, interfaces, estructuras, enumeraciones y delegados. Se puede considerar como _una carpeta virtual_ que ayuda a estructurar el código de una manera jerárquica y coherente. Los `namespace` son utilizados para:
        - **Prevenir conflictos de nombres:** Es la razón principal por la cual se utilizan los `namespace`. Los `namespaces` evitan el problema de que diferentes desarrolladores o librerías utilicen el mismo nombre para sus clases al permitir que existan dos clases con el mismo nombre, siempre y cuando estén en espacios de nombres distintos.

        ```cs
        // EJEMPLO DE "NAMESPACES" CON EL MISMO NOMBRE PERO DIFERENTE USO
        // Un 'Logger' para la capa de lógica de negocio
        namespace MiProyecto.Negocio {
            public class Logger {
                // ...
            }
        }

        // Otro 'Logger' para la capa de acceso a datos
        namespace MiProyecto.Datos {
            public class Logger {
                // ...
            }
        }
        ```

        Para utilizar el `Logger` de `MiProyecto.Negocio`, se haría referencia a él como `MiProyecto.Negocio.Logger`, y para usar el otro, se usaría `MiProyecto.Datos.Logger`.
        - **Organizar el código:** Los namespaces proporcionan una forma clara y lógica de organizar el código, lo que facilita su mantenimiento y comprensión.

        - **Mejorar la legibilidad:** El uso de la directiva `using` al principio de un archivo permite utilizar los tipos de un `namespace` sin tener que escribir su nombre completo cada vez. Esto hace que el código sea más limpio y fácil de leer.

        ```cs
        // EJEMPLO DE USO DE "USING" PARA UTILIZAR LOS "NAMESPACE"
        using System:
        using MiProyecto.Negocio;

        public class MiClase {
            public void MiMetodo() {
                // No es necesario escribir System.Console
                Console.WriteLine("Hola");

                // No es necesario escribir MiProyecto.Negocio.Logger
                var logger = new Logger();
            }
        }
        ```

        - **Facilitar la reutilización:** Al empaquetar conjuntos de clases relacionadas en un namespace, se facilita su uso en otros proyectos.

11. **_¿Cómo se manejan las excepciones en C#? `try`, `catch` y `finally`_**
    - **_R._** El manejo de excepciones se da gracias a los bloques `try`, `catch` y `finally` los cuales permiten manejar errores en tiempo de ejecución de forma controlada, evitando así que la aplicación se bloquee.
        - **_`try`_**
            - **Proposito:** Encapsular un bloque de código que se sospecha que puede lanzar una o más excepciones.
            - **Funcionamiento:** Si no ocurre ninguna excepción dentro del bloque `try`, la ejecución continúa normalmente, y los bloques `catch` se ignoran.
        - **_`catch`_**
            - **Proposito:** Contiene el código que se ejecutará si se produce una excepción en el bloque `try`.
            - **Manejo de excepciones específicas:** Puedes tener múltiples bloques `catch` para manejar diferentes tipos de excepciones de manera específica. El CLR busca el primer bloque catch que coincida con el tipo de excepción lanzada, y solo se ejecuta ese bloque.
        - **_`finally`_**
            - **Proposito:** Contiene el código que siempre se ejecutará, ya sea que se haya producido o no una excepción.
            - **Uso común:** Ideal para liberar recursos que se hayan asignado en el bloque `try`, como cerrar archivos, conexiones de base de datos o streams.
            - **Uso común:** Se ejecuta incluso si hay una instrucción return en el bloque `try` o `catch`.

    ```cs
    // SINTAXIS GENERAL PARA EL MANEJO DE EXCEPCIONES
    // Bloque "try"
    try {
        // Código que puede generar una excepción
    } catch (TipoDeExcepción1 ex) {
        // Código para manejar la excepción del TipoDeExcepción1
    } catch (TipoDeExcepción2 ex) {
        // Código para manejar la excepción del TipoDeExcepción2
    } finally {
        // Código que siempre se ejecuta, haya o no una excepción
    }

    // ----------------------------------------------------------------------------------

    // USO DE "TRY", "CATCH" Y "FINALLY"
    FileStream file = null;

    try {
        file = new FileStream("archivo.txt", FileMode.Open);
        // Realizar operaciones con el archivo...
    }
    catch (FileNotFoundException ex) {
        Console.WriteLine("Error: Archivo no encontrado.");
    }
    finally {
        // Esto se ejecuta siempre, asegurando que el archivo se cierra
        if (file != null) {
            file.Close();
            Console.WriteLine("Archivo cerrado en el bloque finally.");
        }
    }
    ```

12. **_¿Qué es el boxing y unboxing en C#?_**
    - **_R._** Son procesos los cuales permiten convertir datos entre Value Types y Reference Types.
        - **Boxing:** El boxing es la conversión implícita de un tipo de valor (como `int`, `char`, `bool` o una `struct`) a un tipo de referencia (`object` o cualquier interfaz que implemente el tipo de valor).
        Pero ¿Qué es lo que sucede en memoria?
            - Cuando se hace boxing, el Common Language Runtime (CLR) asigna memoria en el montón (heap) para crear una nueva instancia de un objeto.
            - El valor del tipo de valor original se copia de la pila al objeto recién creado en el montón.

        ```cs
        // EJEMPLO DE BOXING
        int numero = 123;
        object obj = numero;    // Boxing: se crea un objeto en el montón y se copia el valor 123
        ```

        - **Unboxing:** El unboxing es la conversión explícita de un tipo de referencia (como `object`) a un tipo de valor. Es el proceso inverso al boxing y debe hacerse de forma manual (mediante un cast).
        ¿Qué es lo que sucede en memoria?
            - Se verifica que el `object` que se está desempaquetando sea una referencia a un objeto que fue creado originalmente mediante boxing a ese tipo de valor.
            - Si la verificación es exitosa, se copia el valor del objeto del montón a una nueva variable de tipo de valor en la pila.

        ```cs
        // EJEMPLO DE "UNBOXING"
        int numero = 123;           // Tipo de valor en la pila
        object obj = numero;        // Boxing
        int otroNumero = (int)obj;  // Unboxing: se copia el valor del objeto a la nueva variable
        ```

        El boxing y el unboxing tienen una penalización significativa en el rendimiento y deben evitarse en código donde el rendimiento es crítico.

13. **_¿Qué diferencia hay entre `String` y `StringBuilder`?_**
    - **_R._** La diferencia entre `String` y `StringBuilder` radica totalmente en la inmutabilidad del primero frente a la mutabilidad del segundo.

    | **_Característica_**   | **_`String`_**                                                                    | **_`StringBuilder`_**                                               |
    |------------------------|-----------------------------------------------------------------------------------|---------------------------------------------------------------------|
    | **Mutabilidad**        | Inmutable. Las modificaciones crean nuevas instancias                             | Mutable. Las modificaciones se realizan sobre la misma instancia.   |
    | **Rendimiento**        | Más lento en manipulaciones frecuentes, debido a la creación constante de objetos | Más rápido y eficiente en bucles o manipulaciones repetitivas       |
    | **Consumo de memoría** | Consume más memoria, ya que los objetos antiguos se convierten en "basura"        | Consume menos memoria, ya que reutiliza el mismo espacio de memoria |
    | **Uso**                | Cadenas pequeñas, estáticas o que se modifican raramente                          | Operaciones intensivas de concatenación o modificación de texto     |
    | **Seguridad de hilos** | Seguro para hilos                                                                 | No es seguro para hilos por defecto                                 |

[:link:](./00%20-%20Inicio.md) _Click aquí para regresar al inicio._
