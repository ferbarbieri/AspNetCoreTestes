CREATE TABLE [dbo].[Usuario] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [CreationDate] DATETIME2 (7)  NOT NULL,
    [IsDeleted]    BIT            NOT NULL,
    [Nome]         NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED ([Id] ASC)
);

