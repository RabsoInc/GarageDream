CREATE TABLE [dbo].[FuelTypes] (
    [FuelTypeId]          UNIQUEIDENTIFIER NOT NULL,
    [FuelTypeDescription] NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_FuelTypes] PRIMARY KEY CLUSTERED ([FuelTypeId] ASC)
);

