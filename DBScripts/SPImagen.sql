USE [GESTORPASS]
GO

/****** Object:  StoredProcedure [dbo].[Imagen]    Script Date: 4/4/2023 11:47:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[Imagen]
@id Int
as
Select Imagen from Servicios where id = @id
GO

