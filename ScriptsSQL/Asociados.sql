SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asociado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FolioCredencial] [nvarchar](10) NOT NULL,
	[Nombre] [nvarchar](60) NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[Sexo] [text] NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[Edad] [int] NOT NULL,
	[NombrePadre] [nvarchar](60) NULL,
	[NombreMadre] [nvarchar](60) NULL,
	[Direccion] [nvarchar](100) NULL,
	[Ciudad] [nvarchar](100) NULL,
	[Estado] [nvarchar](100) NULL,
	[Pais] [nvarchar](100) NULL,
	[Cp] [nvarchar](15) NULL,
	[Telefono1] [nvarchar](50) NULL,
	[Telefono2] [nvarchar](50) NULL,
	[Telefono3] [nvarchar](50) NULL,
	[Telefono4] [nvarchar](50) NULL,
	[CorreoElectronico] [nvarchar](max) NULL,
	[Emergencias] [nvarchar](max) NULL,
	[Activo] [int] NOT NULL,
	[ImageName] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Asociado] ADD  CONSTRAINT [PK_Asociado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO