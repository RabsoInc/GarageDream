CREATE TABLE [dbo].[ContactTypes] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Description] NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_ContactTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

