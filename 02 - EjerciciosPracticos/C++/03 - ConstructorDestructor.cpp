/*
* #############################################################################################
*       Archivo: 03 - ConstructorDestructor.cpp
*       Proyecto: SoftwareEngrII_CsharpAndCpp
*       SO: Windows 11
*       Herramientas:
*           - Visual Studio Code
*      Autor:
*           - Jorge Peña (Jelp200)
* #############################################################################################
*/

/* --------------------------------------------------------------------------------------------
--------------------------------------- I N C L U D E S ---------------------------------------
-------------------------------------------------------------------------------------------- */
#include <iostream>
#include <string>
#include <limits>

/* --------------------------------------------------------------------------------------------
------------------------------------- N A M E  S P A C E S ------------------------------------
-------------------------------------------------------------------------------------------- */
using namespace std;

/* --------------------------------------------------------------------------------------------
------------------------------------------ C L A S E S ----------------------------------------
-------------------------------------------------------------------------------------------- */
class Persona {
    string nombre;
    int edad = 0;
public:
    // Constructor
    Persona(string n, int e) : nombre(n), edad(e) {
        cout << "Constructor: " << nombre << ", Edad: " << edad << endl;
    }
    // Destructor
    ~Persona() {
        cout << "Destructor: " << nombre << endl;
    }
    // Método
    void Saludar() {
        cout << "Hola, soy " << nombre << " y tengo " << edad << " años." << endl;
    }
};
/* --------------------------------------------------------------------------------------------
------------------------------- F U N C I O N  P R I N C I P A L ------------------------------
-------------------------------------------------------------------------------------------- */
int main() {
    string nombreUsuario;
    int edadUsuario;

    // Leer el nombre (admite espacios)
    cout << "Ingrese su nombre: "; getline(cin, nombreUsuario);

    // Leer la edad con validación
    cout << "Ingrese su edad: ";
    while (!(cin >> edadUsuario) || edadUsuario < 0) {
        cout << "Edad inválida. Por favor, ingrese un número entero no negativo: ";
        cin.clear(); // Limpiar estado de error
        cin.ignore(numeric_limits<streamsize>::max(), '\n'); // Vaciar el buffer
    }

    // Crear objeto dinámico con los datos del usuario
    Persona* p1 = new Persona(nombreUsuario, edadUsuario);
    p1->Saludar();
    delete p1; // Llama al destructor y libera memoria

    return 0;
}