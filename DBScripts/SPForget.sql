USE [GESTORPASS]
GO

/****** Object:  StoredProcedure [dbo].[Forget]    Script Date: 4/4/2023 11:47:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[Forget]
@email varchar(100),
@nombre varchar(50),
@apellido varchar(50),
@fecha datetime
as
select Id from Usuarios where 
email = @email 
and Nombre = @nombre and Apellido = @apellido
and FechaNacimiento = @fecha
GO

