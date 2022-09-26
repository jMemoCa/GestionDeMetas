# GestionDeMetas
Descripción 
- El sistema muestra las listas de actividades que han sido creadas. 
- Cada lista contiene un conjunto de tareas (descritas más adelantes). 
- Por cada lista se muestra su nombre, la fecha de creada, el porciento de cumplimiento, la cantidad de tareas completadas y una barra de avance las tareas.

Tecnologías utilizadas: 
• Net 6
• Entity Framework
• Blazor WebAssembly
• Dase de Datos, SQL Server
• Radzen en el cliente para los controles gráficos
• FluentValidation
• Mapster
 


Para que la aplicación funcione solo requiere de tener configura una base de datos, 

Modificar el archivo contenido en: 

GestionDeMetas.Server
  appsettings.json

Paso 1. Ingresando los datos de conexión correspondientes

 "GestionDeMetas": "Server=localhost;Database=GestionDeMetas;User Id=SA; Password=Temporal12;"


Paso 2. Para generar la estructura de base de datos se puede realizar a trabes de la consola del administrador de paquetes ejecutando sobre el proyecto GestionDeMetas.Bussiness:
update-dabase



Altenativa: en caso prefereir evitar el paso 2 se puede ejecutar el script directamente sobre la base configurada en el archivo appsettings.json

CREATE TABLE [dbo].[Meta]  ( 
	[Id]           	nvarchar(450) NOT NULL,
	[Nombre]       	nvarchar(450) NULL,
	[FechaCreacion]	datetime2 NOT NULL,
	CONSTRAINT [PK_Meta] PRIMARY KEY CLUSTERED([Id])
)
ON [PRIMARY]
	TEXTIMAGE_ON [PRIMARY]
	WITH (DATA_COMPRESSION = NONE)
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Meta_Nombre]
	ON [dbo].[Meta]([Nombre])
	WHERE ([Nombre] IS NOT NULL)
	ON [PRIMARY]
GO




CREATE TABLE [dbo].[Actividad]  ( 
	[Id]           	nvarchar(450) NOT NULL,
	[Nombre]       	nvarchar(450) NULL,
	[FechaCreacion]	datetime2 NOT NULL,
	[Importante]   	bit NOT NULL,
	[Concluida]    	bit NOT NULL,
	[MetaId]       	nvarchar(450) NOT NULL,
	CONSTRAINT [PK_Actividad] PRIMARY KEY CLUSTERED([Id])
)
ON [PRIMARY]
	TEXTIMAGE_ON [PRIMARY]
	WITH (DATA_COMPRESSION = NONE)
GO
ALTER TABLE [dbo].[Actividad]
	ADD CONSTRAINT [FK_Actividad_Meta_MetaId]
	FOREIGN KEY([MetaId])
	REFERENCES [dbo].[Meta]([Id])
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO
CREATE NONCLUSTERED INDEX [IX_Actividad_MetaId]
	ON [dbo].[Actividad]([MetaId])
	ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Actividad_Nombre]
	ON [dbo].[Actividad]([Nombre])
	WHERE ([Nombre] IS NOT NULL)
	ON [PRIMARY]
GO



