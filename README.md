# GymWebProject

Aplicación web en **ASP.NET Core MVC** para la gestión de usuarios, planes y compras de un gimnasio.  
El sistema permite registrar planes, gestionar usuarios y verificar compras realizadas.

---

## 🚀 Requisitos previos

- [Visual Studio Community 2022](https://visualstudio.microsoft.com/es/vs/community/) (workload *ASP.NET and web development*).
- SDK de **.NET 6.0** (o la versión que uses en el proyecto).
- **SQL Server** (LocalDB, Express o Developer).
- **Navegador web** (Edge, Chrome, Firefox, etc.).

---

## ⚙️ Configuración del proyecto

### 1. Clonar el repositorio
```bash
git clone https://github.com/Esteban-Arroyave/gymwebproject.git
cd gymwebproject
```

Abre la solución `gymwebproject.sln` en Visual Studio.

---

### 2. Configurar la base de datos
Edita el archivo **appsettings.json** y asegúrate de que la cadena de conexión apunte a tu SQL Server local:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=Gymdb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

### 3. Ejecutar el proyecto
En Visual Studio:

1. Establece **gymwebproject** como *proyecto de inicio*.
2. Pulsa **F5** para ejecutar con depuración, o **Ctrl + F5** para correr sin depuración.
3. La aplicación se abrirá en tu navegador en `https://localhost:5001` o `http://localhost:5000`.

---

## 📂 Estructura del proyecto

- **Controllers/** → Controladores MVC (lógica de negocio).
- **Models/** → Modelos de datos (ej. `compraPmodel`).
- **Repositorio/** → Acceso a datos y consultas SQL.
- **Views/** → Vistas Razor (`Home`, `Login`, `planes`, `payview`, `usuario`).
- **wwwroot/** → Archivos estáticos (CSS, JS, imágenes).
- **appsettings.json** → Configuración del proyecto (conexiones, etc.).
- **Program.cs** → Punto de entrada y configuración de la aplicación.

---

## 👨‍💻 Ejemplo rápido

```bash
git clone https://github.com/Esteban-Arroyave/gymwebproject.git
cd gymwebproject
dotnet restore
dotnet run --project gymwebproject
```

Abrir en el navegador 👉 http://localhost:5000

---

## 🛠️ Tecnologías usadas

- ASP.NET Core MVC (.NET 6)
- SQL Server
- Bootstrap 5
- Entity Framework Core (si se usa con migraciones)

---

