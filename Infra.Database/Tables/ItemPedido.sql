CREATE TABLE [dbo].[ItemPedido] (
    [PedidoId]   INT NOT NULL,
    [ProdutoId]  INT NOT NULL,
    [Quantidade] INT NOT NULL,
    CONSTRAINT [PK_ItemPedido] PRIMARY KEY CLUSTERED ([PedidoId] ASC, [ProdutoId] ASC),
    CONSTRAINT [FK_ItemPedido_Pedido_PedidoId] FOREIGN KEY ([PedidoId]) REFERENCES [dbo].[Pedido] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ItemPedido_Produto_ProdutoId] FOREIGN KEY ([ProdutoId]) REFERENCES [dbo].[Produto] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ItemPedido_ProdutoId]
    ON [dbo].[ItemPedido]([ProdutoId] ASC);

