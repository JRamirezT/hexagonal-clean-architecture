
# **Hexagonal Clean Architecture**

## Contexto

Este es un proyecto que he decidido crear como base para las personas que puedan sacar provecho de él, donde cuyo objetivo es ilustrar el trabajo de Clean Architecture junto con la Arquitectura Hexagonal, recordando que Clean Architecture es un enfoque de diseño de software en el cual su principal razón es la separación del dominio de la infraestructura y la arquitectura Hexagonal (también conocida como Puertos y Adaptadores) es en la que nos apalancamos para lograr el objetivo de tener tu lógica de negocio completamente aislado del mundo exterior.

Cuando hablamos de Infraestructura nos estamos refiriendo a conexiones externas como por ejemplo la creación de un archivo de texto hasta conexiones de bases de datos, servicios de mensajería o servicios Web de Terceros.

## **Autor.**

- [Jhon Alexis Ramirez Triana](www.linkedin.com/in/jaramirezt)

### **Stack Tecnologico.**

.Net 6.

PostgreSQL  

#### **Atributos de Calidad**

- Interoperatividad

- Escalabilidad

- Rendimiento

## **Capas de solución**

![Imagen](Imagenes/EstructuraProyecto.png)

#### **Api**

Capa en la que encontraremos los Controladores, Program, Filtro de Excepciones y appsettings del proyecto por ambiente.

#### **Aplicacion**

Capa encargada de distribuir la responsabiliad a las capas de negocio o infraestructura para enviar mensaje o comunicación de Api's todo depende de la responsabilidad del servicio.

#### **Dominio**

Capa en la que reposara toda la logica del negocio, validaciones etc. En esta capa **NO** se deben tener conexiones a Bases de datos, servicios Web o ApiRest, la idea es que la comunicación se realice mediante la capa de infraestructura.

Notese como en la Capa de Dominio no cuenta con referencias a ningun proyecto o paquete Nuget.

Recuerda, el dominio no conoce a Nadie es el solo e independiente.

![Imagen](Imagenes/EstructuraDominio.png)

#### **Infraestructura**

Capa en la que encontraremos las conexiones a Base de Datos, Conexiones externas y/o librerias externas que deseemos usar, como por ejemplo Servicios de Mensajeria o librerias de creación de archivos Pdf's o Excel.
## **Recursos:**

A continuación relaciono los recursos en los cuales me he basado para la construcción del proyecto.

#### **Manejo de MediaTR para comandos y Querys**
- [MediaTR](https://github.com/jbogard/MediatR)

#### **Filtro de Excepciones**
- [ExceptionFilter](https://nwb.one/blog/exception-filter-attribute-dotnet)

#### **Entity Framework, PostgreSQL**
- [Entity Framework](https://www.npgsql.org/efcore/)

#### **Repositorio generico**
- [GenericRepository](https://learn.microsoft.com/es-es/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application#create-a-generic-repository)

#### **Personalización tabla de migración**
- [Migratión](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/history-table)

#### **Entendimiento del Tacking de una entidad**

Este apartado me parece importante incluirlo para que puedan entender porque se configura el tracking en las entidades de la Base de datos
- [Tracking](https://learn.microsoft.com/en-us/ef/core/querying/tracking)

#### **Actualización de Fechas para postgresql**
- [Fechas en postgresql](https://www.npgsql.org/doc/types/datetime.html)

## **Importante:**

La Fase I del proyecto corresponde a la creación base del proyecto con la que tendremos un CRUD de una entidad conectada a PostgreSQL.

Fecha inicio fase I - 4 Abril 2023

Fecha fin fase I - 23 de Abril 2023

La idea es continuar con Fases posteriores las cuales contemplaran, pruebas unitarias, pruebas de Integración, conexiónes a Azure o Aws (Aun esta pendiente la decisión)