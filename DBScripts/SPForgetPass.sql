USE [GESTORPASS]
GO

/****** Object:  StoredProcedure [dbo].[forgetPass]    Script Date: 4/4/2023 11:47:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[forgetPass]
@pass varchar(50),
@email varchar(100)
as
update Usuarios set Pass = @pass where email = @email
GO

