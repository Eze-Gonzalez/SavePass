USE [GESTORPASS]
GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 4/4/2023 11:45:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](100) NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[ServiciosTotales] [int] NULL,
	[FechaNacimiento] [datetime] NULL,
	[Pass] [varchar](50) NULL,
	[IdImagen] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Imagenes_Usuarios] FOREIGN KEY([IdImagen])
REFERENCES [dbo].[Imagenes] ([Id])
GO

ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Imagenes_Usuarios]
GO

