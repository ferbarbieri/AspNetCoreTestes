CREATE TABLE [dbo].[Pedido] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [ClienteId]    INT           NULL,
    [CreationDate] DATETIME2 (7) NOT NULL,
    [IsDeleted]    BIT           NOT NULL,
    CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Pedido_Cliente_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [dbo].[Cliente] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Pedido_ClienteId]
    ON [dbo].[Pedido]([ClienteId] ASC);

