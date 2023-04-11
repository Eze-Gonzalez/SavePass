USE [GESTORPASS]
GO

/****** Object:  StoredProcedure [dbo].[traerAcceso]    Script Date: 5/4/2023 08:59:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[traerAcceso]
@idSeleccionado int,
@idUsuario int
as
Select D.Id Id, IdUsuario, IdServicio, 
S.Imagen Imagen, Usuario, Pass, NombreServicio, ValidarOtro, UrlCambio  
from DatosAccesos D, Servicios S where IdUsuario = @idUsuario and D.Id = @idSeleccionado and S.Id = IdServicio
GO

