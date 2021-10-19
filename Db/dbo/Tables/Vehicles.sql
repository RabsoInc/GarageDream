CREATE TABLE [dbo].[Vehicles] (
    [VehicleId]          UNIQUEIDENTIFIER NOT NULL,
    [RegistrationNumber] NVARCHAR (10)    NOT NULL,
    [CustomerId]         UNIQUEIDENTIFIER NULL,
    [VehicleMakeId]      UNIQUEIDENTIFIER NULL,
    [VehicleModelId]     UNIQUEIDENTIFIER NULL,
    [FuelTypeId]         UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED ([VehicleId] ASC),
    CONSTRAINT [FK_Vehicles_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([CustomerId]),
    CONSTRAINT [FK_Vehicles_FuelTypes_FuelTypeId] FOREIGN KEY ([FuelTypeId]) REFERENCES [dbo].[FuelTypes] ([FuelTypeId]),
    CONSTRAINT [FK_Vehicles_VehicleMakes_VehicleMakeId] FOREIGN KEY ([VehicleMakeId]) REFERENCES [dbo].[VehicleMakes] ([VehicleMakeId]),
    CONSTRAINT [FK_Vehicles_VehicleModels_VehicleModelId] FOREIGN KEY ([VehicleModelId]) REFERENCES [dbo].[VehicleModels] ([VehicleModelId])
);






GO
CREATE NONCLUSTERED INDEX [IX_Vehicles_CustomerId]
    ON [dbo].[Vehicles]([CustomerId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Vehicles_VehicleModelId]
    ON [dbo].[Vehicles]([VehicleModelId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Vehicles_VehicleMakeId]
    ON [dbo].[Vehicles]([VehicleMakeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Vehicles_FuelTypeId]
    ON [dbo].[Vehicles]([FuelTypeId] ASC);

