USE [GESTORPASS]
GO

/****** Object:  StoredProcedure [dbo].[agregarAcceso]    Script Date: 4/4/2023 11:47:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[agregarAcceso]
@idServicio int,
@idUsuario int,
@usuario varchar(100),
@pass varchar(20),
@nombreServicio varchar(50),
@validarOtro bit
as
insert into DatosAccesos (IdServicio, IdUsuario, Usuario, Pass, NombreServicio, ValidarOtro)
values (@idServicio, @idUsuario, @usuario, @pass, @nombreServicio, @validarOtro)
GO

