USE [GESTORPASS]
GO

/****** Object:  StoredProcedure [dbo].[Registro]    Script Date: 4/4/2023 11:48:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Registro]
@email varchar(100),
@pass varchar(50),
@nombre varchar(50),
@apellido varchar(50),
@fecha datetime
as
insert into Usuarios (Email, Pass, Nombre, Apellido, FechaNacimiento, IdImagen) 
output inserted.Id values (@email, @pass, @nombre, @apellido, @fecha, 1)
GO

