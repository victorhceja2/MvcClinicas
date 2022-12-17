SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PadecimientoAsociado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdAsociado] [int] NOT NULL,
	[Padecimiento] [nvarchar](100) NULL,
	[Hospital] [nvarchar](60) NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[Valvula] [nvarchar](2) NULL,
	[Sangre] [nvarchar](10) NULL,
	[Notas] [nvarchar](100) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PadecimientoAsociado] ADD  CONSTRAINT [PK_PadecimientoAsociado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[IdAsociado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
