USE [Podaci]
GO

/****** Object:  Table [dbo].[Podaci]    Script Date: 14.10.2018. 21:50:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Podaci](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [nvarchar](max) NULL,
	[Prezime] [nvarchar](max) NULL,
	[PostanskiBroj] [int] NOT NULL,
	[Grad] [nvarchar](max) NULL,
	[Telefon] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Podacis] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

