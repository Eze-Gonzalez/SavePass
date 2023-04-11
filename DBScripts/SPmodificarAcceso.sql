USE [GESTORPASS]
GO

/****** Object:  StoredProcedure [dbo].[modificarAcceso]    Script Date: 4/4/2023 11:48:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[modificarAcceso]
    @idServicio int,
    @idUsuario int,
    @usuario varchar(100),
    @pass varchar(20),
    @nombreServicio varchar(50),
    @validarOtro bit,
    @id int
AS
BEGIN
    UPDATE DatosAccesos 
    SET IdServicio = @idServicio, 
        IdUsuario = @idUsuario, 
        Usuario = @usuario,
        Pass = @pass, 
        NombreServicio = @nombreServicio, 
        ValidarOtro = @validarOtro 
    WHERE Id = @id
END
GO

