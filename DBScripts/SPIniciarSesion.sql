USE [GESTORPASS]
GO

/****** Object:  StoredProcedure [dbo].[IniciarSesion]    Script Date: 4/4/2023 11:48:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[IniciarSesion]
@email varchar(100),
@pass varchar(20)
as
Select Id, Email, Pass, Nombre, Apellido, IdImagen, FechaNacimiento, ServiciosTotales
from Usuarios where Email = @email and Pass = @pass
GO

