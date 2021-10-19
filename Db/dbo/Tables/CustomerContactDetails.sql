CREATE TABLE [dbo].[CustomerContactDetails] (
    [CustomerContactDetailId] UNIQUEIDENTIFIER NOT NULL,
    [CustomerId]              UNIQUEIDENTIFIER NULL,
    [ContactMethodTypeId]     UNIQUEIDENTIFIER NULL,
    [Value]                   NVARCHAR (100)   NOT NULL,
    [Comments]                NVARCHAR (250)   NULL,
    CONSTRAINT [PK_CustomerContactDetails] PRIMARY KEY CLUSTERED ([CustomerContactDetailId] ASC),
    CONSTRAINT [FK_CustomerContactDetails_ContactMethodTypes_ContactMethodTypeId] FOREIGN KEY ([ContactMethodTypeId]) REFERENCES [dbo].[ContactMethodTypes] ([ContactMethodTypeId])
);




GO
CREATE NONCLUSTERED INDEX [IX_CustomerContactDetails_CustomerId]
    ON [dbo].[CustomerContactDetails]([CustomerId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CustomerContactDetails_ContactMethodTypeId]
    ON [dbo].[CustomerContactDetails]([ContactMethodTypeId] ASC);

