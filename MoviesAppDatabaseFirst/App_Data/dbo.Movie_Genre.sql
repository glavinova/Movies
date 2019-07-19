CREATE TABLE [dbo].[Movie_Genre] (
    [Id]      INT IDENTITY (1, 1) NOT NULL,
    [MovieId] INT NULL,
    [GenreId] INT NULL,
    CONSTRAINT [PK_dbo.Movie_Genre] PRIMARY KEY CLUSTERED ([Id] ASC)
);

