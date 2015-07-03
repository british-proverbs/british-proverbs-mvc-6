CREATE TABLE [dbo].[Visits]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[IpAddress] [nvarchar] (300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[CreatedOn] [datetimeoffset] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Visits] ADD CONSTRAINT [PK_Visits] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
