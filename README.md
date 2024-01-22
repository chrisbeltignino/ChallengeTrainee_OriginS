# ATM App

Esta aplicación de cajero automático (ATM) fue desarrollada como parte de un ejercicio técnico para Origin Software. La aplicación está diseñada para simular las operaciones de un cajero automático, incluyendo el ingreso de tarjeta, validación de PIN, consultas de saldo, retiros y más.

## Estructura del Proyecto

El proyecto sigue una arquitectura limpia (Clean Architecture) y está organizado en las siguientes capas:

- **Core**: Contiene las entidades y reglas de negocio.
- **Application**: Lógica de aplicación y casos de uso.
- **Infrastructure**: Implementaciones concretas y detalles de la base de datos.
- **Presentation**: Capa de interfaz de usuario (Windows Forms).

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
