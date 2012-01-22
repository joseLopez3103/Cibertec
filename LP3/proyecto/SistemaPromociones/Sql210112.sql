-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
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
CREATE PROCEDURE sp_new_user
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
		insert into dbo.tb_user(name_user,id_facebook,sexo ,email ) values(@name_user,@id_facebook,@sexo,@email)
END
GO


