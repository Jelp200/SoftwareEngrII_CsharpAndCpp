/*
* #############################################################################################
*       Archivo: 05 - ManejoMemoriaDinamica.cpp
*       Proyecto: SoftwareEngrII_CsharpAndCpp
*       SO: Windows 11
*       Herramientas:
*           - Visual Studio Code
*       Autor:
*           - Jorge Peña (Jelp200)
*       Descripcion:
*           Reservar un arreglo dinámico de 5 enteros, asignarles un valor y liberarlo.
* #############################################################################################
*/

/* --------------------------------------------------------------------------------------------
--------------------------------------- I N C L U D E S ---------------------------------------
-------------------------------------------------------------------------------------------- */
#include <iostream>


/* --------------------------------------------------------------------------------------------
------------------------------- F U N C I O N  P R I N C I P A L ------------------------------
-------------------------------------------------------------------------------------------- */
int main() {
    const int TAM = 5;
    int* arreglo = new int [TAM];
    
    // Inicialización de valores
    for (int i = 0; i < TAM; ++i)
        arreglo[i] = (i + 1) * 10;
        
    // Mostrar los valores
    for (int i = 0; i < TAM; ++i)
        std::cout << "arreglo[" << i << "] = " << arreglo[i] << std::endl;

    // Liberar memoria
    delete[] arreglo;
    arreglo = nullptr;
    
    return 0;
}