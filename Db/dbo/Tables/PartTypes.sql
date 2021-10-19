CREATE TABLE [dbo].[PartTypes] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Description] NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_PartTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

