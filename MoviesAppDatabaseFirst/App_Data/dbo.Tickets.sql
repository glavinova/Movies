CREATE TABLE [dbo].[Tickets] (
    [Id]            INT        IDENTITY (1, 1) NOT NULL,
    [numOfPeople]   INT        NOT NULL,
    [ticketType]    INT        NOT NULL,
    [price]         FLOAT (53) NOT NULL,
    [client_Id]     INT        NOT NULL,
    [projection_Id] INT        NOT NULL,
    CONSTRAINT [PK_dbo.Tickets] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Tickets_dbo.Clients_client_Id] FOREIGN KEY ([client_Id]) REFERENCES [dbo].[Clients] ([Id]),
    CONSTRAINT [FK_dbo.Tickets_dbo.Projections_projection_Id] FOREIGN KEY ([projection_Id]) REFERENCES [dbo].[Projections] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_client_Id]
    ON [dbo].[Tickets]([client_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_projection_Id]
    ON [dbo].[Tickets]([projection_Id] ASC);

