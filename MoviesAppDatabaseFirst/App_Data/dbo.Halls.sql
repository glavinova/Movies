CREATE TABLE [dbo].[Halls] (
    [Id]          INT IDENTITY (1, 1) NOT NULL,
    [NumOfSits]   INT NULL,
    [isAvailable] BIT NULL,
    CONSTRAINT [PK_dbo.Halls] PRIMARY KEY CLUSTERED ([Id] ASC)
);

