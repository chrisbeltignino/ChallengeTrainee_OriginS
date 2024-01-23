# ATM App

Esta aplicación de cajero automático (ATM) fue desarrollada como parte de un ejercicio técnico para Origin Software. La aplicación está diseñada para simular las operaciones de un cajero automático en una aplicación de Windows Form, incluyendo el ingreso de tarjeta, validación de PIN, consultas de saldo, retiros y más.

## Estructura del Proyecto

El proyecto sigue una arquitectura limpia (Clean Architecture) y está organizado en las siguientes capas:

- **Core**: Contiene las entidades y reglas de negocio.
- **Application**: Lógica de aplicación y casos de uso.
- **Infrastructure**: Implementaciones concretas y detalles de la base de datos.
- **Presentation**: Capa de interfaz de usuario (Windows Forms).

## Planteo del programa

**Home Page**:
- Usuario ingresa el número de tarjeta.
- Se envía una solicitud para verificar la existencia y bloqueo de la tarjeta.

**Ingreso de PIN**:
- Si la tarjeta no está bloqueada, se solicita al usuario que ingrese el PIN.
- Se valida el PIN en la base de datos.

**Operaciones**:
- Si el PIN es correcto, se muestra el formulario de operaciones con opciones como "Balance" o "Retiro".

**Balance**:
- Muestra la información de la tarjeta y cliente.
- Registra una operación de balance en la base de datos.

**Retiro**:
- Usuario ingresa la cantidad a retirar.
- Se valida la cantidad y se realiza el retiro si es posible.
- Se registra la operación de retiro en la base de datos.

**Resultados**:
- Se muestra un formulario con los resultados de la operación.

**Errores**:
- Si hay algún error (PIN incorrecto, tarjeta bloqueada, saldo insuficiente), se muestra un mensaje de error.

## Base de Datos

Se utiliza SQL Server como base de datos, y se han creado tablas para almacenar información sobre clientes, tarjetas y operaciones.

## Diagramas

- **Diagrama de Entidad-Relación (DER)**: (imagen)
- **Diagrama de Flujo de la Aplicación**: (imagen)

## Repositorio y Versionado

El código fuente se encuentra en un repositorio público en GitHub. Se han utilizado las mejores prácticas de control de versiones para mantener un historial claro.

## Instrucciones para Ejecutar la Aplicación

1. Clona este repositorio.
2. Configura la cadena de conexión a la base de datos en la capa de Infrastructure/Persistence/Db_Connection.cs.
3. Ejecuta la aplicación desde la interfaz de usuario (Windows Forms).
