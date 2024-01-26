# ATM App

Esta aplicación de cajero automático (ATM) fue desarrollada como parte de un ejercicio técnico para Origin Software. La aplicación está diseñada para simular las operaciones de un cajero automático en una aplicación de Windows Form, incluyendo el ingreso de tarjeta, validación de PIN, consultas de saldo, retiros y más.

## Características Principales

- **Entity Framework**: Utiliza Entity Framework para la gestión de la capa de acceso a datos, facilitando la interacción con la base de datos SQL Server.
  
- **Capa de Negocio y Datos**: Se ha implementado una arquitectura de tres capas que separa claramente las responsabilidades entre la capa de presentación, la capa de negocio y la capa de acceso a datos.

- **Interfaces, Repositorios y Servicios**: La lógica de negocio se organiza a través de interfaces, repositorios y servicios, proporcionando una estructura modular y fácilmente mantenible.

- **Interfaz Gráfica de Usuario (GUI)**: Se han desarrollado formularios para la interfaz de usuario que permiten a los usuarios interactuar con la aplicación de manera intuitiva.

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
- Muestra la información de la **Tarjeta** y **Cliente**.
- Registra una operación de balance en la base de datos.

**Retiro**:
- Usuario ingresa la cantidad a retirar.
- Se valida la cantidad y se realiza el **Retiro** si es posible.
- Se registra la operación de **Retiro** en la base de datos.

**Reporte**:
- Se muestra un formulario con los datos de la tarjeta y los resultados de la operación.

**Errores**:
- Si hay algún error (PIN incorrecto, tarjeta bloqueada, saldo insuficiente), se muestra un mensaje de error.

## Base de Datos

La aplicación utiliza SQL Server como sistema de gestión de bases de datos. La estructura de la base de datos ha sido generada mediante un script manual, el cual se encuentra en el archivo `Creacion_BD_ORIGINS.sql`. Este script incluye la creación de tablas para almacenar información clave relacionada con clientes, tarjetas y operaciones. Y ademas informacion precargada para realizar pruebas y testeos.

Adicionalmente, para facilitar la reproducción del entorno de base de datos en otros sistemas, se ha exportado el esquema y los datos resultantes de la ejecución del script mencionado. El archivo resultante de esta exportación se denomina `BD_ORIGIN_S_SCRIPT.sql`.

Por favor, asegúrese de ejecutar el script de creación y, si es necesario, el script de exportación para establecer el entorno de base de datos adecuado para la aplicación.

## DER y Diagrama de Flujo de la Aplicación

![Diagrama de Flujo ATM](https://github.com/chrisbeltignino/ChallengeTrainee_OriginS/assets/51706356/3539798f-2653-4c0c-9ffe-5f98e518071f)

## Funcionalidades extras

- Se agrego una nueva Entidad llamada Cliente que cada uno esta asociado a su **Tarjeta**.
- Se agrego la funcionalidad de que la tarjeta una vez este bloqueada esta misma se desbloquee despues de 40seg dentro del programa.
- Al momento de realizar la operacion de balance se muestra parte de la informacion del **Cliente** asociado.

## Instrucciones para Ejecutar la Aplicación

1. Clona este repositorio.
2. Configura la cadena de conexión a la base de datos en la capa de `Infrastructure/Persistence/DbConfig.cs`.
3. Ejecuta la aplicación desde la interfaz de usuario (Windows Forms).
