USE [PROMOTION]
GO
/****** Object:  StoredProcedure [dbo].[sp_new_user]    Script Date: 01/21/2012 21:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
--- set language español
-- =============================================
CREATE PROCEDURE [dbo].[sp_new_user]
	-- Add the parameters for the stored procedure here
	@name_user nvarchar(20),
	@id_facebook nvarchar(50),
	@sexo char(1),
	@email nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		insert into dbo.tb_userfb(name_user,id_facebook,sexo ,email ) values(@name_user,@id_facebook,@sexo,@email)
END
