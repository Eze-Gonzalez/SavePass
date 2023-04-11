USE [GESTORPASS]
GO

/****** Object:  Table [dbo].[DatosAccesos]    Script Date: 4/4/2023 11:46:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DatosAccesos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdServicio] [int] NULL,
	[IdUsuario] [int] NULL,
	[Usuario] [varchar](100) NULL,
	[Pass] [varchar](20) NULL,
	[NombreServicio] [varchar](50) NULL,
	[ValidarOtro] [bit] NULL,
 CONSTRAINT [PK_DatosAccesos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[DatosAccesos]  WITH CHECK ADD  CONSTRAINT [FK_DatosAccesos_Servicios] FOREIGN KEY([IdServicio])
REFERENCES [dbo].[Servicios] ([Id])
GO

ALTER TABLE [dbo].[DatosAccesos] CHECK CONSTRAINT [FK_DatosAccesos_Servicios]
GO

ALTER TABLE [dbo].[DatosAccesos]  WITH CHECK ADD  CONSTRAINT [FK_DatosAccesos_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[DatosAccesos] CHECK CONSTRAINT [FK_DatosAccesos_Usuario]
GO

