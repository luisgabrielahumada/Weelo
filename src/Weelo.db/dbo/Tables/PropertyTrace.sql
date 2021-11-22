CREATE TABLE [dbo].[PropertyTrace](
	[IdPropertyTrace] [int] IDENTITY(1,1) NOT NULL,
	[DateSale] [date] NULL,
	[Name] [varchar](50) NULL,
	[Value] [money] NULL,
	[Tax] [money] NULL,
	[IdProperty] [int] NULL,
 CONSTRAINT [PK_PropertyTrace] PRIMARY KEY CLUSTERED 
(
	[IdPropertyTrace] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PropertyTrace]  WITH CHECK ADD  CONSTRAINT [FK_PropertyTrace_Property] FOREIGN KEY([IdProperty])
REFERENCES [dbo].[Property] ([IdProperty])
GO

ALTER TABLE [dbo].[PropertyTrace] CHECK CONSTRAINT [FK_PropertyTrace_Property]
GO


