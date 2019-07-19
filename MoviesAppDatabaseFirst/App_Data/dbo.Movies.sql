CREATE TABLE [dbo].[Movies] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX)  NOT NULL,
    [Desctiption]  NVARCHAR (MAX)  NULL,
    [Duration]     INT             NOT NULL,
    [totalRaiting] DECIMAL (18, 2) NOT NULL,
    [imgUrl]       NVARCHAR (MAX)  NOT NULL,
    [Director_Id]  INT             NOT NULL,
    [genre_Id]     INT             NOT NULL,
    CONSTRAINT [PK_dbo.Movies] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Movies_dbo.Directors_Director_Id] FOREIGN KEY ([Director_Id]) REFERENCES [dbo].[Directors] ([Id]),
    CONSTRAINT [FK_dbo.Movies_dbo.Genres_genre_Id] FOREIGN KEY ([genre_Id]) REFERENCES [dbo].[Genres] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Director_Id]
    ON [dbo].[Movies]([Director_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_genre_Id]
    ON [dbo].[Movies]([genre_Id] ASC);

