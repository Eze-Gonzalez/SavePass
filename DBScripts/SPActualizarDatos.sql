USE [GESTORPASS]
GO

/****** Object:  StoredProcedure [dbo].[ActualizarDatos]    Script Date: 4/4/2023 11:46:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[ActualizarDatos]
@nombre varchar(50),
@apellido varchar(50),
@email varchar(100),
@pass varchar(50),
@idImagen int,
@id int
as
Update Usuarios set 
Nombre = @nombre,
Apellido = @apellido,
Email = @email,
Pass = @pass,
IdImagen = @idImagen
where
Id = @id
GO

