
CREATE TABLE [dbo].[Person](
	[Personid] [int] IDENTITY(1,1) NOT NULL,
	[ForeNames] [varchar](50) NOT NULL,
	[SurName] [varchar](50) NOT NULL,
	[DateOfBirth] [datetime2](7) NULL,
	[Gender] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Personid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


CREATE TABLE [dbo].[PersonNumber](
	[PersonId] [int] NULL,
	[Number] [varchar](50) NULL,
	[Type] [varchar](50) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[PersonNumber]  WITH CHECK ADD  CONSTRAINT [FK_PersonNumber_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Personid])
GO

ALTER TABLE [dbo].[PersonNumber] CHECK CONSTRAINT [FK_PersonNumber_Person]
GO