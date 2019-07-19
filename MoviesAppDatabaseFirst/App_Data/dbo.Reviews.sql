CREATE TABLE [dbo].[Reviews] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [raiting]   INT            NOT NULL,
    [comment]   NVARCHAR (MAX) NOT NULL,
    [dateTime]  DATETIME       NOT NULL,
    [client_Id] INT            NOT NULL,
    [Movie_Id]  INT            NOT NULL,
    CONSTRAINT [PK_dbo.Reviews] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Reviews_dbo.Clients_client_Id] FOREIGN KEY ([client_Id]) REFERENCES [dbo].[Clients] ([Id]),
    CONSTRAINT [FK_dbo.Reviews_dbo.Movies_Movie_Id] FOREIGN KEY ([Movie_Id]) REFERENCES [dbo].[Movies] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_client_Id]
    ON [dbo].[Reviews]([client_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Movie_Id]
    ON [dbo].[Reviews]([Movie_Id] ASC);

