USE [GESTORPASS]
GO

/****** Object:  Table [dbo].[Validacion]    Script Date: 4/4/2023 11:46:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Validacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](8) NULL,
	[EmailUsuario] [varchar](100) NULL,
	[FechaCreacion] [datetime] NULL,
 CONSTRAINT [PK_Validacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Validacion]  WITH CHECK ADD  CONSTRAINT [FK_Validacion_Usuarios] FOREIGN KEY([Id])
REFERENCES [dbo].[Validacion] ([Id])
GO

ALTER TABLE [dbo].[Validacion] CHECK CONSTRAINT [FK_Validacion_Usuarios]
GO

