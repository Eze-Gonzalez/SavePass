USE [GESTORPASS]
GO

/****** Object:  StoredProcedure [dbo].[listarAcceso]    Script Date: 4/4/2023 11:48:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[listarAcceso]
@id int
as
Select D.Id Id, IdUsuario, IdServicio, 
S.Imagen Imagen, Usuario, Pass, NombreServicio, ValidarOtro  
from DatosAccesos D, Servicios S where IdUsuario = @id and S.Id = IdServicio
GO

