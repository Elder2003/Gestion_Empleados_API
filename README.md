Sistema de Gestión de Recursos Humanos (API RESTful)

Este repositorio contiene el backend de una aplicación para la administración de personal, desarrollado para demostrar la implementación de servicios REST utilizando el ecosistema de Microsoft .NET.

El objetivo principal del proyecto es proveer una interfaz programable (API) segura y escalable para realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre registros de empleados, cargos y nóminas.

Descripción Técnica

La arquitectura del sistema sigue principios de diseño limpio, separando la lógica de negocio del acceso a datos.

Arquitectura: API RESTful basada en controladores.
ORM: Entity Framework Core (Code-First) para la gestión de la base de datos.
Documentación: Swagger UI integrado para pruebas de endpoints.
Seguridad: Validación de datos y manejo de excepciones centralizado.

Stack Tecnológico

Lenguaje: C# 12
Framework: .NET 8 (ASP.NET Core Web API)
Base de Datos: SQL Server
Herramientas: Entity Framework Core, Swagger/OpenAPI.

Instalación y Ejecución

Para ejecutar este proyecto en un entorno local:

Clonar el repositorio:
    ```bash
    git clone [https://github.com/Elder2003/Gestion_Empleados_API.git](https://github.com/Elder2003/Gestion_Empleados_API.git)
    ```

Configurar Base de Datos:
    Asegúrese de tener una instancia de SQL Server activa. Actualice la cadena de conexión en el archivo `appsettings.json`:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=GestionEmpleadosDB;Trusted_Connection=True;TrustServerCertificate=True;"
    }
    ```

Aplicar Migraciones:
    ```bash
    dotnet ef database update
    ```

Iniciar la aplicación:
    ```bash
    dotnet run
    ```
    La documentación de la API estará disponible en: `http://localhost:5000/swagger`

---
