CREATE TABLE [dbo].[Produto] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [CreationDate] DATETIME2 (7)   NOT NULL,
    [IsDeleted]    BIT             NOT NULL,
    [Nome]         NVARCHAR (MAX)  NULL,
    [Preco]        DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED ([Id] ASC)
);

