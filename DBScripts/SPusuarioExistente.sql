USE [GESTORPASS]
GO

/****** Object:  StoredProcedure [dbo].[usuarioExistente]    Script Date: 5/4/2023 08:58:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[usuarioExistente]
@nServicio varchar(50),
@nUsuario varchar(100),
@idUsuario int
as
Select Id from DatosAccesos where 
IdUsuario = @idUsuario and NombreServicio = @nServicio and Usuario = @nUsuario 
GO

