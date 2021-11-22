/****** Object:  Table [dbo].[Property]    Script Date: 18/11/2021 4:56:54 p. m. ******/
CREATE TABLE [dbo].[Property](
	[IdProperty] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Address] [varchar](255) NULL,
	[Price] [money] NULL,
	[CodeInternational] [varchar](50) NULL,
	[Year] [int] NULL,
	[IdOwner] [int] NULL,
 CONSTRAINT [PK_Property] PRIMARY KEY CLUSTERED 
(
	[IdProperty] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK_Property_Owner] FOREIGN KEY([IdOwner])
REFERENCES [dbo].[Owner] ([IdOwner])
GO

ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK_Property_Owner]
GO

