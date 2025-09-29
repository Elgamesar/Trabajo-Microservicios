Este repositorio es una solución **.NET (net8.0)** orientada a microservicios para un caso de tienda/e‑commerce (Customers, Orders, Products). La solución contiene múltiples proyectos por cada microservicio organizados siguiendo una **arquitectura limpia / por capas** (Application, Domain, Infra) y APIs separadas para cada bounded context. Hay un proyecto cliente web (`WebClient`) y un fichero de solución (`Trabajo-Microservicios.sln`).

---

* Hay **13 proyectos** .NET dentro de la solución (APICustomers, APIOrders, APIProducts, MS*Application, MS*Domain, MS*Infra por cada microservicio, WebClient, etc.).
* La **versión objetivo** de los proyectos es **net8.0** (aplica a los proyectos API y a los módulos MS).
* Se utiliza **Entity Framework Core** para persistencia (presencia de paquetes EF Core y carpetas/archivos de Migrations en los proyectos de Infra).
* El proveedor observado por paquetes es **SQL Server** (paquetes relacionados con SqlClient / EF Core SQL Server). Se esperan `ConnectionStrings` en `appsettings.json` para las APIs.
* Las APIs exponen **Swagger / Swashbuckle** (documentación de API) en los proyectos API.
* Estructura por microservicio: cada dominio tiene al menos los proyectos **Domain**, **Application** y **Infra** (separación típica de responsabilidades).
* Hay indicios de archivos de infraestructura y scripts SQL / migraciones para inicializar bases.
* Hay presencia de **WebClient** (frontend). No se detectó con certeza si es Blazor, React o Angular a partir del escaneo de paquetes; probablemente es un proyecto de cliente web dentro de la solución.
* Se detectaron `Dockerfile` / docker-compose o ficheros relacionados (posible soporte para contenerizar y orquestar localmente).

---

* **Lenguaje / Plataforma:** .NET 8 (C#)
* **Arquitectura:** Microservicios + Clean Architecture (Domain / Application / Infra)
* **ORM / Persistencia:** Entity Framework Core (migrations presentes)
* **BD / Proveedor:** SQL Server (Microsoft.Data.SqlClient / EF Core SQL Server)
* **Documentación de API:** Swagger / Swashbuckle
* **Proyectos de Frontend:** `WebClient`
* **Estructura de solución:** `Trabajo-Microservicios.sln` con todos los proyectos referenciados

---

* `APICustomers` — API pública para Customer. (net8.0) — **Swagger**, **EntityFrameworkCore / SQL Server**.
* `APIOrders` — API pública para Orders. (net8.0) — **Swagger**, **EntityFrameworkCore / SQL Server**.
* `APIProducts` — API pública para Products. (net8.0) — **Swagger**, **EntityFrameworkCore / SQL Server**.
* `MSCustomerApplication` — Capa Application del microservicio Customer. (net8.0)
* `MSCustomerDomain` — Capa Domain del microservicio Customer. (net8.0)
* `MSCustomerInfra` — Infraestructura del microservicio Customer (repositorio, EF Core). (net8.0) — **EntityFrameworkCore / SQL Server**.
* `MSOrderApplication` — Application para Orders. (net8.0)
* `MSOrderDomain` — Domain para Orders. (net8.0)
* `MSOrderInfra` — Infraestructura de Orders (repositorios, EF Core). (net8.0)
* `MSProductApplication` — Application para Products. (net8.0)
* `MSProductDomain` — Domain para Products. (net8.0)
* `MSProductInfra` — Infraestructura de Products (repositorios, EF Core). (net8.0)
* `WebClient` — Cliente web integrado en la solución. Revisar carpeta para identificar framework exacto.

---

* `Trabajo-Microservicios.sln` — solución principal
* Varios `*.csproj` para cada microservicio y capas
* `appsettings*.json` en proyectos API (connection strings y configuración)
* Carpetas `Migrations` en proyectos Infra (migraciones de EF Core)
