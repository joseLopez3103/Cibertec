USE [PROMOTION]
GO
/****** Object:  Table [dbo].[tb_userfb]    Script Date: 02/11/2012 18:23:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_userfb](
	[cod] [int] IDENTITY(1,1) NOT NULL,
	[name_user] [nvarchar](20) NULL,
	[id_facebook] [nvarchar](50) NULL,
	[sexo] [char](1) NULL,
	[email] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_userfb] PRIMARY KEY CLUSTERED 
(
	[cod] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_promotion]    Script Date: 02/11/2012 18:23:40 ******/
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
	[url_img] [varchar](100) NULL,
	[path] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[cod] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_participation]    Script Date: 02/11/2012 18:23:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_participation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cod_user] [int] NOT NULL,
	[fecha] [nvarchar](50) NULL,
	[ip] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tb_participation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_access]    Script Date: 02/11/2012 18:23:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_access](
	[cod] [int] IDENTITY(1,1) NOT NULL,
	[usr] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_access] PRIMARY KEY CLUSTERED 
(
	[cod] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_validate_user]    Script Date: 02/11/2012 18:23:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_validate_user]
	-- Add the parameters for the stored procedure here
	@id_facebook nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from dbo.tb_userfb where dbo.tb_userfb.id_facebook=@id_facebook
END
GO
/****** Object:  StoredProcedure [dbo].[sp_validate_admin]    Script Date: 02/11/2012 18:23:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_validate_admin] 
	-- Add the parameters for the stored procedure here
	@usr nvarchar(50) ,
	@password nvarchar(50) 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from dbo.tb_access where dbo.tb_access.usr=@usr AND 
	dbo.tb_access.password=@password
END
GO
/****** Object:  StoredProcedure [dbo].[sp_save_url_promotion]    Script Date: 02/11/2012 18:23:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_save_url_promotion] 
	-- Add the parameters for the stored procedure here
	@cod int,
	@nfolder varchar(100),
	@file varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update  dbo.tb_promotion set url_img=@nfolder,path=@file
	 WHERE  cod= @cod
END
GO
/****** Object:  StoredProcedure [dbo].[sp_new_user]    Script Date: 02/11/2012 18:23:38 ******/
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
GO
/****** Object:  StoredProcedure [dbo].[sp_new_promotion]    Script Date: 02/11/2012 18:23:38 ******/
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
	SELECT SCOPE_IDENTITY() 

END
GO
/****** Object:  StoredProcedure [dbo].[sp_get_promotionByCod]    Script Date: 02/11/2012 18:23:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_get_promotionByCod] 
	@cod int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from dbo.tb_promotion where    cod= @cod
END
GO
/****** Object:  StoredProcedure [dbo].[sp_all_promotion]    Script Date: 02/11/2012 18:23:38 ******/
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
