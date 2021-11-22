CREATE TABLE [dbo].[PropertyImage](
	[IdPropertyImage] [int] IDENTITY(1,1) NOT NULL,
	[IdProperty] [int] NULL,
	[file] [varchar](255) NULL,
	[Enabled] [bit] NULL,
 CONSTRAINT [PK_PropertyImage] PRIMARY KEY CLUSTERED 
(
	[IdPropertyImage] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PropertyImage] ADD  CONSTRAINT [DF_PropertyImage_Enabled]  DEFAULT ((1)) FOR [Enabled]
GO

ALTER TABLE [dbo].[PropertyImage]  WITH CHECK ADD  CONSTRAINT [FK_PropertyImage_Property] FOREIGN KEY([IdProperty])
REFERENCES [dbo].[Property] ([IdProperty])
GO

ALTER TABLE [dbo].[PropertyImage] CHECK CONSTRAINT [FK_PropertyImage_Property]
GO

