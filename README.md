CrudMVCApp

Aplicación web ASP.NET Core Razor Pages para la gestión de productos.

 Características

- Listado de productos con tabla interactiva.
  
- Alta, edición, consulta y eliminación de productos.
  
- Validaciones de datos en el modelo y en la interfaz.
  
- Interfaz responsiva con Bootstrap.
  
- Arquitectura basada en Entity Framework Core y patrón MVC.
  

 Tecnologías utilizadas

- .NET 8

- ASP.NET Core Razor Pages
  
- Entity Framework Core (SQL Server)
  
- Bootstrap 5
  
- C# 12
  

 Instalación

1. Clona el repositorio:


2. Abre la solución en Visual Studio 2022 o superior.
   
4. Configura la cadena de conexión a tu base de datos en appsettings.json.
   
5. Ejecuta las migraciones de Entity Framework Core:
   
   dotnet ef database update

6. Ejecuta el proyecto (F5 o dotnet run).
    

 Uso

- Accede a la página principal para ver el listado de productos.
  
- Utiliza los botones para crear, editar, ver detalles o eliminar productos.
  
- Todas las operaciones son seguras y requieren confirmación para eliminar.
  

 Estructura principal

- **Controllers/ProductosController.cs**: Lógica de negocio y endpoints CRUD.
  
- **Views/Productos/**: Vistas Razor para cada operación.
  
- **Models/Producto.cs**: Modelo de datos con validaciones.
  
- **Data/AppDbContext.cs**: Contexto de base de datos.



Desarrollado por Sofia Isaia en la catedra Programación III
