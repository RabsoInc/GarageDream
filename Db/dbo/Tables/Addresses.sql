CREATE TABLE [dbo].[Addresses] (
    [AddressId]    UNIQUEIDENTIFIER NOT NULL,
    [AddressLine1] NVARCHAR (150)   NOT NULL,
    [AddressLine2] NVARCHAR (150)   NULL,
    [AddressLine3] NVARCHAR (150)   NULL,
    [AddressLine4] NVARCHAR (150)   NULL,
    [PostCode]     NVARCHAR (10)    NOT NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED ([AddressId] ASC)
);



