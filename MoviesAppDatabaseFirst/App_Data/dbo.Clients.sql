CREATE TABLE [dbo].[Clients] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX) NOT NULL,
    [Surname]      NVARCHAR (MAX) NOT NULL,
    [birthDate]    DATETIME       NOT NULL,
    [email]        NVARCHAR (MAX) NOT NULL,
    [Username]     NVARCHAR (MAX) NOT NULL,
    [Password]     NVARCHAR (MAX) NOT NULL,
    [ClubCardCode] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Clients] PRIMARY KEY CLUSTERED ([Id] ASC)
);

