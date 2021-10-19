CREATE TABLE [dbo].[Customers] (
    [CustomerId] UNIQUEIDENTIFIER NOT NULL,
    [TitleId]    UNIQUEIDENTIFIER NULL,
    [FirstName]  NVARCHAR (100)   NOT NULL,
    [LastName]   NVARCHAR (100)   NOT NULL,
    [GenderId]   UNIQUEIDENTIFIER NULL,
    [AddressId]  UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([CustomerId] ASC),
    CONSTRAINT [FK_Customers_Addresses_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([AddressId])
);




GO
CREATE NONCLUSTERED INDEX [IX_Customers_AddressId]
    ON [dbo].[Customers]([AddressId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Customers_TitleId]
    ON [dbo].[Customers]([TitleId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Customers_GenderId]
    ON [dbo].[Customers]([GenderId] ASC);

