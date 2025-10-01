/*
* #############################################################################################
*       Archivo: SumaDeArreglo.cpp
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
#include <limits>

/* --------------------------------------------------------------------------------------------
------------------------------------- N A M E  S P A C E S ------------------------------------
-------------------------------------------------------------------------------------------- */
using namespace std;

/* --------------------------------------------------------------------------------------------
------------------------------- F U N C I O N  P R I N C I P A L ------------------------------
-------------------------------------------------------------------------------------------- */
int main() {
    int tamano = 0;
    
    // Pedir y validar el tamaño del arreglo
    cout << "Ingrese el tamaño del arreglo: ";
    while (!(cin >> tamano) || tamano <= 0) {
        cout << "Entrada inválida. Por favor, ingrese un número entero positivo: ";
        cin.clear(); // Limpiar banderas de error
        cin.ignore(numeric_limits<streamsize>::max(), '\n'); // Vaciar el buffer
    }
    
    // Crear arreglo dinámico
    int* arreglo = new int[tamano];

    // Leer los elementos del arreglo
    cout << "Ingrese " << tamano << " números enteros:" << endl;
    for (int i = 0; i < tamano; i++) {
        cout << "Número " << (i + 1) << ": ";
        while (!(cin >> arreglo[i])) {
            cout << "Entrada inválida. Ingrese un número entero: ";
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n');
        }
    }

    // Calcular la suma
    long long suma = 0; // Usamos long long para evitar desbordamiento en sumas grandes
    for (int i = 0; i < tamano; i++) {
        suma += arreglo[i];
    }

    // Mostrar resultado
    cout << "\nLa suma de los " << tamano << " números es: " << suma << endl;

    // Liberar memoria
    delete[] arreglo;
    return 0;
}