/*
* #############################################################################################
*       Archivo: main.cpp
*       Proyecto: SoftwareEngrII_CsharpAndCpp
*       SO: Windows 11
*       Herramientas:
*           - Visual Studio Code
*       Autor:
*           - Jorge Peña (Jelp200)
*       Descripción:
*           Programa que se conecta a la base de datos TiendaDB mediante ODBC y muestra:
*           - Todos los productos (Nombre, Precio, Stock)
*           - Empleados con salario mayor a $2500 (Nombre, Puesto, Salario)
* #############################################################################################
*/

#include <iostream>
#include <sql.h>
#include <sqlext.h>
#include <iomanip>  // Para std::fixed y std::setprecision

using namespace std;

// Configuración de conexión
#define DSN_NAME      "tiendadb"
#define DB_USER       "root"
#define DB_PASSWORD   "root"

// Función auxiliar para mostrar errores de ODBC
void mostrarError(SQLSMALLINT handleType, SQLHANDLE handle) {
    SQLCHAR sqlState[6], message[SQL_MAX_MESSAGE_LENGTH];
    SQLINTEGER nativeError;
    SQLSMALLINT length;

    SQLGetDiagRec(handleType, handle, 1, sqlState, &nativeError, message, sizeof(message), &length);
    cerr << "[ERROR ODBC] SQLState: " << sqlState << " - Mensaje: " << message << endl;
}

int main() {
    SQLHENV hEnv = SQL_NULL_HENV;
    SQLHDBC hDbc = SQL_NULL_HDBC;
    SQLHSTMT hStmt = SQL_NULL_HSTMT;
    SQLRETURN ret;

    // === 1. Inicializar entorno ODBC ===
    ret = SQLAllocHandle(SQL_HANDLE_ENV, SQL_NULL_HANDLE, &hEnv);
    if (ret != SQL_SUCCESS && ret != SQL_SUCCESS_WITH_INFO) {
        cerr << "Error al crear el entorno ODBC." << endl;
        return 1;
    }

    ret = SQLSetEnvAttr(hEnv, SQL_ATTR_ODBC_VERSION, (void*)SQL_OV_ODBC3, 0);
    if (ret != SQL_SUCCESS && ret != SQL_SUCCESS_WITH_INFO) {
        cerr << "Error al configurar la versión de ODBC." << endl;
        SQLFreeHandle(SQL_HANDLE_ENV, hEnv);
        return 1;
    }

    // === 2. Conectar a la base de datos ===
    ret = SQLAllocHandle(SQL_HANDLE_DBC, hEnv, &hDbc);
    if (ret != SQL_SUCCESS && ret != SQL_SUCCESS_WITH_INFO) {
        cerr << "Error al crear el handle de conexión." << endl;
        SQLFreeHandle(SQL_HANDLE_ENV, hEnv);
        return 1;
    }

    ret = SQLConnect(
        hDbc,
        (SQLCHAR*)DSN_NAME, SQL_NTS,
        (SQLCHAR*)DB_USER, SQL_NTS,
        (SQLCHAR*)DB_PASSWORD, SQL_NTS
    );
    if (ret != SQL_SUCCESS && ret != SQL_SUCCESS_WITH_INFO) {
        cerr << "Error al conectar a la base de datos '" << DSN_NAME << "'." << endl;
        mostrarError(SQL_HANDLE_DBC, hDbc);
        goto cleanup;
    }

    cout << "Conexión exitosa a la base de datos TiendaDB.\n" << endl;

    // === 3. Consultar y mostrar PRODUCTOS ===
    cout << "=== PRODUCTOS EN STOCK ===" << endl;
    cout << "---------------------------------------------" << endl;
    cout << left << setw(20) << "Nombre" << setw(10) << "Precio" << "Stock" << endl;
    cout << "---------------------------------------------" << endl;

    ret = SQLAllocHandle(SQL_HANDLE_STMT, hDbc, &hStmt);
    if (ret != SQL_SUCCESS && ret != SQL_SUCCESS_WITH_INFO) {
        cerr << "Error al crear statement para productos." << endl;
        goto cleanup;
    }

    ret = SQLExecDirect(hStmt, (SQLCHAR*)"SELECT Nombre, Precio, Stock FROM Productos", SQL_NTS);
    if (ret != SQL_SUCCESS && ret != SQL_SUCCESS_WITH_INFO) {
        cerr << "Error al ejecutar consulta de productos." << endl;
        mostrarError(SQL_HANDLE_STMT, hStmt);
        SQLFreeHandle(SQL_HANDLE_STMT, hStmt);
        hStmt = SQL_NULL_HSTMT;
        goto cleanup;
    }

    char nombreProd[100];
    double precio;
    SQLINTEGER stock;

    SQLBindCol(hStmt, 1, SQL_C_CHAR, nombreProd, sizeof(nombreProd), NULL);
    SQLBindCol(hStmt, 2, SQL_C_DOUBLE, &precio, 0, NULL);
    SQLBindCol(hStmt, 3, SQL_C_SLONG, &stock, 0, NULL);

    while (SQLFetch(hStmt) == SQL_SUCCESS || SQLFetch(hStmt) == SQL_SUCCESS_WITH_INFO) {
        cout << left << setw(20) << nombreProd
             << "$" << fixed << setprecision(2) << setw(9) << precio
             << stock << endl;
    }

    SQLFreeHandle(SQL_HANDLE_STMT, hStmt);
    hStmt = SQL_NULL_HSTMT;

    // === 4. Consultar y mostrar EMPLEADOS (salario > 2500) ===
    cout << "\n=== EMPLEADOS CON SALARIO > $2500 ===" << endl;
    cout << "---------------------------------------------" << endl;
    cout << left << setw(20) << "Nombre" << setw(25) << "Puesto" << "Salario" << endl;
    cout << "---------------------------------------------" << endl;

    ret = SQLAllocHandle(SQL_HANDLE_STMT, hDbc, &hStmt);
    if (ret != SQL_SUCCESS && ret != SQL_SUCCESS_WITH_INFO) {
        cerr << "Error al crear statement para empleados." << endl;
        goto cleanup;
    }

    ret = SQLExecDirect(hStmt, (SQLCHAR*)"SELECT Nombre, Puesto, Salario FROM Empleados WHERE Salario > 2500", SQL_NTS);
    if (ret != SQL_SUCCESS && ret != SQL_SUCCESS_WITH_INFO) {
        cerr << "Error al ejecutar consulta de empleados." << endl;
        mostrarError(SQL_HANDLE_STMT, hStmt);
        SQLFreeHandle(SQL_HANDLE_STMT, hStmt);
        hStmt = SQL_NULL_HSTMT;
        goto cleanup;
    }

    char nombreEmp[100];
    char puesto[50];
    double salario;

    SQLBindCol(hStmt, 1, SQL_C_CHAR, nombreEmp, sizeof(nombreEmp), NULL);
    SQLBindCol(hStmt, 2, SQL_C_CHAR, puesto, sizeof(puesto), NULL);
    SQLBindCol(hStmt, 3, SQL_C_DOUBLE, &salario, 0, NULL);

    while (SQLFetch(hStmt) == SQL_SUCCESS || SQLFetch(hStmt) == SQL_SUCCESS_WITH_INFO) {
        cout << left << setw(20) << nombreEmp
             << setw(25) << puesto
             << "$" << fixed << setprecision(2) << salario << endl;
    }

    // === 5. Limpieza ===
cleanup:
    if (hStmt != SQL_NULL_HSTMT) SQLFreeHandle(SQL_HANDLE_STMT, hStmt);
    if (hDbc != SQL_NULL_HDBC) {
        SQLDisconnect(hDbc);
        SQLFreeHandle(SQL_HANDLE_DBC, hDbc);
    }
    if (hEnv != SQL_NULL_HENV) SQLFreeHandle(SQL_HANDLE_ENV, hEnv);

    cout << "\n👋 Programa finalizado." << endl;
    return 0;
}