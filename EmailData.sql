USE [POC]
GO

/****** Object:  Table [dbo].[Email]    Script Date: 05-05-2023 21:37:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Email](
	[To] [varchar](50) NULL,
	[From] [varchar](50) NULL,
	[Subject] [varchar](500) NULL,
	[Body] [varchar](500) NULL,
	[SentTime] [datetime] NULL
) ON [PRIMARY]
GO

