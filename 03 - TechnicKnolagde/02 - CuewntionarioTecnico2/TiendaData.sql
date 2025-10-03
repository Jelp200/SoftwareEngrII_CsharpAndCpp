/*
* #######################################################################################################################################
*       Archivo: TiendaData.sql
*       Proyecto: SoftwareEngrII_CsharpAndCpp
*       SO: Windows 11
*       Herramientas:
*           - Visual Studio Code
*           - MySQL Workbench
*      Compilador:
*           - MySQL 8.0
*      Autor:
*           - Jorge Peña (Jelp200)
*      Descripción:
*          Script que permite insertar:
*               - Nombre, Precio y Stock de productos de una tienda electronica.
*               - Nombre, Puesto y Salario de empleados de una tienda electronica.
*               - Nombre de clientes de una tienda electronica.
*               - Cliente_ID, Monto y Fecha de ventas realizadas en una tienda electronica.
* ######################################################################################################################################
*/

--- ===========================================
--- USAR LA BASE DE DATOS
--- ===========================================
USE TiendaDB;

--- ===========================================
--- INSERCIÓN DE DATOS EN LA TABLA PRODUCTOS
--- ===========================================
INSERT INTO Productos (Nombre, Precio, Stock) VALUES
('2N2222A', 1.07, 50),
('STM32F103C8T6', 64.00, 15),
('LM324N', 8.00, 30),
('PC817', 5.00, 40),
('7805', 2.50, 25),
('1N4007', 0.50, 100),
('ATmega328P', 75.00, 10),
('74HC595', 12.00, 20),
('CD4011BE', 6.00, 35),
('LDR', 3.00, 60);

--- ===========================================
--- INSERCIÓN DE DATOS EN LA TABLA EMPLEADOS
--- ===========================================
INSERT INTO Empleados (Nombre, Puesto, Salario) VALUES
('Ana Gómez', 'Gerente de Tienda', 3500),
('Luis Martínez', 'Vendedor', 2500),
('Marta Rodríguez', 'Cajera', 2200),
('Carlos Sánchez', 'Encargado de Inventario', 2800),
('Sofía López', 'Asistente de Ventas', 2400);

--- ===========================================
--- INSERCIÓN DE DATOS EN LA TABLA CLIENTES
--- ===========================================
INSERT INTO Clientes (Nombre) VALUES
('José Sánchez'),
('Fidelfa Huerta'),
('Delfino Gómez'),
('Diego Rivera'),
('Emiliano Villa');

--- ===========================================
--- INSERCIÓN DE DATOS EN LA TABLA VENTAS
--- ===========================================
INSERT INTO Ventas (Cliente_ID, Monto, Fecha) VALUES
(5, 25000, '2025-01-16'),
(4, 30000, '2025-02-15'),
(2, 15000, '2025-04-14'),
(3, 80000, '2025-06-13'),
(1, 5000, '2025-09-12');