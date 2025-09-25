# Conocimiento Técnico (C#) :purple_square:

## Nivel intermedio :boy:

1. **_Explica los cuatro pilares de la POO en C#: abstracción, encapsulación, herencia y polimorfismo._**
    - **_R._** Dentro de C# como en C++ existen cuatro pilares fundamentales para la programación orientada a objetos (POO), los cuales permiten crear código más organizado, flexible, reutilizable y fácil de mantener, estos son:
        1. **_Abstacción._**
        Esta enfocada en mostrar solo los detalles escenciales de un objeto al mundo exterior, mientras oculta los complejos detalles de implementación interna. La idea es simplificar la complejidad del sistema para los usuarios de la clase.

        En C# la abstracción se implementa con:
            - **Clases y métodos abstractos:** Una clase abstracta no puede ser instanciada y sirve como una clase base que define un contrato común. Las clases derivadas deben implementar los métodos abstractos.
            - **Interfaces:** Una interfaz define un contrato que las clases que la implementan deben seguir. Esto permite tratar diferentes objetos de manera uniforme a través de la interfaz, sin conocer los detalles de su implementación.
            - **Ejemplo:** Una clase `Animal` puede tener un método abstracto `HacerSonido()`. Las clases derivadas como `Perro` y `Gato` deben implementar este método de forma específica, pero el código externo solo necesita saber que cualquier `Animal` puede hacer un sonido.
        2. **_Encapsulación._**
        Es el mecanismo de agrupar los datos (campos) y los métodos que operan sobre esos datos en una sola unidad (una clase). Su propósito principal es proteger el estado interno de un objeto, restringiendo el acceso directo para que solo pueda ser modificado a través de una interfaz controlada.

        En C# la encapsulación se implementa con:
            - **Modificadores de acceso:** Se utilizan modificadores como `private`, `protected` y `public` para controlar la visibilidad de los miembros de una clase.
            - **Propiedades:** Las propiedades (`get` y `set`) son la forma preferida de exponer campos privados, ya que permiten añadir lógica de validación o cálculo en el acceso a los datos.
            - **Ejemplo:** Una clase `CuentaBancaria` puede tener un campo `private saldo`. El acceso a este campo se controla a través de métodos `public` como `Depositar()` y `Retirar()`, que pueden incluir lógica de validación para asegurar que el saldo no se vuelva negativo.
        3. **_Herencia._**
        Permite crear una nueva clase (clase derivada) a partir de una clase existente (clase base). Esto promueve la reutilización de código y establece una relación jerárquica de "es un tipo de" entre las clases.

        En C# la herencia se implementa con:
            - **Sintaxis de herencia:** Se utiliza el operador `:` para indicar que una clase deriva de otra.
            - **Jerarquía de clases:** El marco de trabajo de .NET ya utiliza la herencia de forma extensa; por ejemplo, todas las clases en C# heredan implícitamente de `System.Object`.
            - **Ejemplo:** Si una clase `Animal` tiene atributos y métodos comunes, una clase `Perro` puede heredar de `Animal` y reutilizar esa funcionalidad, además de agregar sus propias características específicas, como el método `Ladrar()`.
        4. **_Polimorfismo._**
        Permite que objetos de diferentes clases, que comparten una clase base o interfaz común, puedan ser tratados de manera uniforme, respondiendo a un mismo mensaje de diferentes maneras.

        En C# el polimorfismo se implementa con:
            - **Sobrescritura de métodos (`override`):** Las clases derivadas pueden proporcionar una implementación específica de un método que ya está definido en la clase base. Esto se logra usando las palabras clave `virtual` en la clase base y `override` en la clase derivada.
            - **Sobrecarga de métodos:** Consiste en definir múltiples métodos con el mismo nombre pero con diferentes firmas (parámetros), permitiendo que el compilador elija la versión correcta según los argumentos proporcionados.
            - **Ejemplo:** La clase base `Animal` tiene un método `HacerSonido()`. La clase `Perro` puede sobrescribir este método para que imprima "Guau", mientras que la clase `Gato` lo sobrescribe para que imprima "Miau". Luego, en una lista de objetos `Animal`, se puede llamar al método `HacerSonido()` en cada uno sin saber su tipo específico.

2. **_Diferencia entre `interface` y `abstract class`._**
    - **_R._** Dentro de C# `interface` y `abstract class` permiten definir un contrato que otras clases deben seguir, pero con diferencias clave en sus capacidades y propósitos.

    | **_Característica_**          | **_`interface`_**                                                                                                                                                                                | **_`abtract class`_**                                                                                                                       |
    |-------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------|
    | **Implementación de métodos** | No puede tener implementación de métodos (antes de C# 8). A partir de C# 8, pueden tener una implementación por defecto para métodos                                                             | Puede tener tanto métodos abstractos (sin implementación) como métodos concretos (con implementación).                                      |
    | **Herencia**                  | Una clase puede implementar múltiples interfaces. Esto simula la herencia múltiple de comportamiento.                                                                                            | Una clase solo puede heredar de una única clase abstracta.                                                                                  |
    | **Miembros**                  | Contiene solo declaraciones de métodos, propiedades, eventos e indexadores. Antes de C# 8, no podía contener campos. A partir de C# 8, puede tener campos estáticos, pero no de instancia.       | Puede contener cualquier miembro de una clase normal, incluyendo campos, propiedades, métodos, constructores, etc.                          |
    | **Constructores**             | No puede tener constructores.                                                                                                                                                                    | Puede tener constructores, que son llamados por el constructor de las clases derivadas.                                                     |
    | **Finalidad**                 | Define un contrato o comportamiento que puede ser adoptado por clases no relacionadas. Es una descripción de "lo que" hace una clase.                                                            | Define una plantilla o una clase base común para clases estrechamente relacionadas. Es una descripción de "lo que es" una clase.            |
    | **Nivel de relación**         | Se usa para tipos que comparten un comportamiento, pero que no están relacionados por jerarquía (por ejemplo, una clase `Coche` y una `Persona` pueden implementar una interfaz `IDesplazable`). | Se usa para tipos que están fuertemente relacionados y comparten una jerarquía común (por ejemplo, `Coche` y `Moto` heredan de `Vehiculo`). |

    ```cs
    // IMPLEMENTACIÓN DE "INTERFACE"
    public interface IMovable {
        void Mover(int distancia);
    }

    public class Coche : IMovable {
        public void Mover(int distancia) {
            Console.WriteLine($"El coche se mueve {distancia} metros.");
        }
    }

    public class Persona : IMovable {
        public void Mover(int distancia) {
            Console.WriteLine($"La persona camina {distancia} metros.");
        }
    }

    // ----------------------------------------------------------------------------------

    // IMPLEMENTACIÓN DE "CLASE ABSTRACTA"
    public abstract class Animal {
        public string Nombre { get; set; }

        // Método concreto con implementación 
        public void Dormir() {
            Console.WriteLine("El animal está durmiendo.");
        }

        public abstract void HacerSonido(); // Método abstracto sin implementación
    }

    public class Perro : Animal {
        public override void HacerSonido() {
            Console.WriteLine("Guau!");
        }
    }
    ```

3. **_¿Qué son los delegados y qué relación tienen con los eventos?_**
    - **_R._** Un delegado es un tipo que define una referencia a un método. En C#, se puede pensar en él como un "puntero a función con seguridad de tipos". Permite encapsular un método y pasarlo como parámetro a otro método, lo que habilita la programación de devolución de llamada (callbacks). **Los delegados son la base sobre la cual se construyen los eventos**.
    Un evento es una notificación enviada por un objeto para señalar que ha ocurrido una acción. Se basa en el modelo de delegado para establecer una comunicación entre un objeto que produce un evento (editor) y uno o más objetos que lo manejan (suscriptores).
        - **_Ejemplo_**
        Imaginese que se tiene una clase `Boton` que notifica a otras clases cuando se hace click.
            1. **Declaración del delegado:** `ButtonClickHandler` define un contrato para métodos que toman un object y un EventArgs como parámetros, y no devuelven nada.
            2. **Definición del evento en la clase `Boton`**
            3. **Suscripción y manejo del evento**

            ```cs
            // 1.
            public delegate void ButtonClickHandler(object sender, EventArgs e);

            // 2.
            public class Boton {
                // El evento `Click` está basado en el delegado `ButtonClickHandler`
                public event ButtonClickHandler Click;

                // Método que dispara el evento
                protected virtual void OnClick(EventArgs e) {
                    // Invoca a todos los métodos suscritos al evento
                    Click?.Invoke(this, e);
                }
            }

            //3.
            public class InterfazDeUsuario {
                public void SuscribirseAlBoton(Boton boton) {
                    // Se suscribe el método 'ManejarClick' al evento 'Click'
                    boton.Click += ManejarClick;
                }

                private void ManejarClick(object sender, EventArgs e) {
                    Console.WriteLine("El botón ha sido clickeado.");
                }
            }
            ```

> [:link:](./00%20-%20Inicio.md) _Click aquí para regresar al inicio._
> [:link:](./01%20-%20CshrpBasic.md) _Click aquí para el nivel anterior._
> [:link:](./03%20-%20CshrpAdv.md) _Click aquí para el siguiente nivel._
