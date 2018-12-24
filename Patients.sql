

/****** Object:  Table [dbo].[PersonData]    Script Date: 12/13/2018 20:08:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE  TABLE [dbo].[Patients](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GUIID] NVARCHAR(50) NOT NULL UNIQUE,
	[PersonXML] [varchar](1000) NOT NULL,
	
) ON [PRIMARY]
GO

