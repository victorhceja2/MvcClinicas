SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PadAsoComun](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPadresAsociado] [int] NOT NULL,
	[IdAsociado] [int] NOT NULL,
	[Adicciones] [nvarchar](100) NULL,
	[HijosDTN] [nvarchar](2) NULL,
	[FamiliaresDTN] [nvarchar](2) NULL,
	[ExposicionToxinas] [nvarchar](2) NULL,
	[DescripcionToxinas] [nvarchar](100) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PadAsoComun] ADD  CONSTRAINT [PK_PadAsoComun] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[IdPadresAsociado] ASC,
	[IdAsociado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
