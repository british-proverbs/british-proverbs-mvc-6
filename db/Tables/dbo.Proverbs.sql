CREATE TABLE [dbo].[Proverbs]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[UserId] [int] NOT NULL,
[Content] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[IsVisible] [bit] NOT NULL,
[CreatedOn] [datetimeoffset] NOT NULL
) ON [PRIMARY]
ALTER TABLE [dbo].[Proverbs] ADD 
CONSTRAINT [PK_Proverbs] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
ALTER TABLE [dbo].[Proverbs] ADD
CONSTRAINT [FK_Proverbs_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])


GO
