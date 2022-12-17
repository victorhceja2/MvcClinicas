SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PadresAsociado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdAsociado] [int] NOT NULL,
	[Nombre] [nvarchar](60) NOT NULL,
	[LugarNacimiento] [nvarchar](60) NOT NULL,
	[Escolaridad] [nvarchar](60) NULL,
	[Edad] [int] NULL,
	[Tipo] [nvarchar](10) NULL,
	[Parentesco] [nvarchar](2) NULL,
	[AcidoFolico] [nvarchar](2) NULL,
	[CitasMedicas] [int] NULL,
	[Seguro] [nvarchar](15) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PadresAsociado] ADD  CONSTRAINT [PK_PadresAsociado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[IdAsociado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO