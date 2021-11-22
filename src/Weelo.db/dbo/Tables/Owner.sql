CREATE TABLE [dbo].[Owner](
	[IdOwner] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Address] [varchar](255) NULL,
	[Photo] [varchar](255) NULL,
	[Birthday] [date] NULL,
 CONSTRAINT [PK_Owner] PRIMARY KEY CLUSTERED 
(
	[IdOwner] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
