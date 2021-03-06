USE [PROMOTION]
GO
/****** Object:  Table [dbo].[tb_promotion]    Script Date: 01/21/2012 18:12:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_promotion](
	[cod] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](20) NULL,
	[state] [varchar](20) NULL,
	[date_init] [datetime] NULL,
	[date_end] [datetime] NULL,
	[description] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[cod] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_new_promotion]    Script Date: 01/21/2012 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_new_promotion] 
	-- Add the parameters for the stored procedure here
	--@cod int,
	@name varchar(20),
	@state varchar(20),
	@date_init datetime,
	@date_end datetime,
	@description varchar(255)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into dbo.tb_promotion(name,state,date_init ,date_end ,description ) values(@name,@state,@date_init,@date_end,@description)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_all_promotion]    Script Date: 01/21/2012 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_all_promotion] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from dbo.tb_promotion
END
GO
