CREATE TABLE [dbo].[ContactMethodTypes] (
    [ContactMethodTypeId]          UNIQUEIDENTIFIER NOT NULL,
    [ContactMethodTypeDescription] NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_ContactMethodTypes] PRIMARY KEY CLUSTERED ([ContactMethodTypeId] ASC)
);

