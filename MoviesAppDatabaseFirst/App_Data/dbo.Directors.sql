CREATE TABLE [dbo].[Directors] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_dbo.Directors] PRIMARY KEY CLUSTERED ([Id] ASC)
);

