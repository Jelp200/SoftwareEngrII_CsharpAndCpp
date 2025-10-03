/*
* #######################################################################################################################################
*       Archivo: TiendaSchema.sql
*       Proyecto: SoftwareEngrII_CsharpAndCpp
*       SO: Windows 11
*       Herramientas:
*           - Visual Studio Code
*           - MySQL Workbench
*       Compilador:
*           - MySQL 8.0
*       Autor:
*           - Jorge Peña (Jelp200)
*       Descripción:
*          Script para la creación de la base de datos y tablas para la gestión productos y stock.
* ######################################################################################################################################
*/

--- ===========================================
--- CREACIÓN DE LA BASE DE DATOS
--- ===========================================
CREATE DATABASE IF NOT EXISTS TiendaDB;
USE TiendaDB;

--- ===========================================
--- CREACIÓN DE LA TABLA PRODUCTOS
--- ===========================================
CREATE TABLE IF NOT EXISTS Productos (
    producto_id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    precio DECIMAL(10, 2) NOT NULL,
    stock INT NOT NULL
);

--- ===========================================
--- CREACIÓN DE LA TABLA EMPLEADOS
--- ===========================================
CREATE TABLE IF NOT EXISTS Empleados (
    empleado_id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    puesto VARCHAR(50) NOT NULL,
    salario INT NOT NULL
);

--- ===========================================
--- CREACIÓN DE LA TABLA CLIENTES
--- ===========================================
CREATE TABLE IF NOT EXISTS Clientes (
    cliente_id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL
);

--- ===========================================
--- CREACIÓN DE LA TABLA VENTAS
--- ===========================================
CREATE TABLE IF NOT EXISTS Ventas (
    venta_id INT AUTO_INCREMENT PRIMARY KEY,
    cliente_id INT NOT NULL,
    monto INT NOT NULL,
    fecha DATE NOT NULL,
    FOREIGN KEY (cliente_id) REFERENCES Clientes(cliente_id) ON DELETE CASCADE
);