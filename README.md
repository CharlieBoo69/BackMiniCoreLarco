# Backend - Sistema de Gestión de Gastos

## Descripción
Este es el **backend** del sistema de gestión de gastos, implementado en **.NET Core** y desplegado en **Azure**. El backend proporciona un API REST para filtrar gastos por rango de fechas y calcular los totales agrupados por departamento.

---

## Características
- API REST para consultar gastos filtrados por fechas.
- Cálculo de totales agrupados por departamento.
- Configuración de CORS para integración con el frontend.
- Base de datos alojada en **Azure SQL Database**.

---

## Tecnologías Utilizadas
- **.NET Core 7.0**: Framework para el desarrollo del backend.
- **Entity Framework Core**: ORM para la gestión de la base de datos.
- **SQL Server**: Base de datos en la nube de Azure.
- **Swagger**: Documentación interactiva de la API.

---

## Configuración Inicial

### 1. Clonar el Repositorio
Clona el repositorio del backend en tu máquina local.

### 2. Configurar la Cadena de Conexión
Actualiza el archivo `appsettings.json` con la cadena de conexión de tu base de datos en Azure SQL:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=tcp:tu-servidor.database.windows.net,1433;Initial Catalog=GastosDB;Persist Security Info=False;User ID=tu-usuario;Password=tu-contraseña;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  }
}
```

### 3. Restaurar Dependencias
Ejecuta el siguiente comando para restaurar las dependencias:
```bash
dotnet restore
```

### 4. Aplicar Migraciones
Ejecuta el siguiente comando para aplicar las migraciones a la base de datos:
```bash
dotnet ef database update
```

### 5. Ejecutar la Aplicación
Ejecuta el siguiente comando para iniciar el backend:
```bash
dotnet run
```
Esto iniciará el servidor en `http://localhost:5153`.

---

## Endpoints de la API

### 1. Filtrar Gastos por Fechas
- **URL**: `/api/gastos/filtrar`
- **Método**: GET
- **Parámetros**:
  - `fechaInicio`: Fecha de inicio del rango.
  - `fechaFin`: Fecha de fin del rango.
- **Ejemplo**:
```
GET https://coregastos20250105182941.azurewebsites.net/api/gastos/filtrar?fechaInicio=2025-01-01&fechaFin=2025-01-31
```
- **Respuesta**:
```json
[
  {
    "Departamento": "IT",
    "Total": 1200.50
  },
  {
    "Departamento": "Marketing",
    "Total": 800.00
  }
]
```

---

## Estructura del Proyecto
```
|-- Controllers
    |-- GastosController.cs    # Controlador principal
|-- Data
    |-- AppDbContext.cs        # Configuración de Entity Framework
|-- Models
    |-- Gasto.cs               # Modelo de datos para Gastos
    |-- Departamento.cs        # Modelo de datos para Departamentos
    |-- Empleado.cs            # Modelo de datos para Empleados
```

---

## Despliegue en Azure

### 1. Crear un App Service en Azure
1. Accede al portal de Azure.
2. Crea un nuevo recurso de App Service.
3. Configura el App Service con una SKU básica.

### 2. Publicar desde Visual Studio
1. Abre el proyecto en Visual Studio.
2. Haz clic derecho en el proyecto y selecciona `Publicar`.
3. Selecciona Azure como destino y sigue los pasos.

### 3. Verificar el Despliegue
Accede a la URL del App Service una vez desplegado, por ejemplo:
```
https://coregastos20250105182941.azurewebsites.net/
```

---

## Notas
- Asegúrate de que la configuración de CORS permita el dominio del frontend.
- Utiliza Swagger para probar los endpoints directamente desde el navegador.

---

## Contacto
Correo: carlos.larco.escobar@udla.edu.ec
Telefono: 0969424932




