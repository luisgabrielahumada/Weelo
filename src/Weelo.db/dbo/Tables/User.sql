CREATE TABLE [dbo].[User](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](80) NULL,
	[Login] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



