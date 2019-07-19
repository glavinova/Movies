CREATE TABLE [dbo].[Projections] (
    [Id]            INT      IDENTITY (1, 1) NOT NULL,
    [dateTime]      DATETIME NOT NULL,
    [AvailableSits] INT      NOT NULL,
    [hall_Id]       INT      NOT NULL,
    [MovieId]       INT      NOT NULL,
    CONSTRAINT [PK_dbo.Projections] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Projections_dbo.Halls_hall_Id] FOREIGN KEY ([hall_Id]) REFERENCES [dbo].[Halls] ([Id]),
    CONSTRAINT [FK_dbo.Projections_dbo.Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movies] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_hall_Id]
    ON [dbo].[Projections]([hall_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_MovieId]
    ON [dbo].[Projections]([MovieId] ASC);

