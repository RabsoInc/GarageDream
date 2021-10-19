CREATE TABLE [dbo].[VehicleModels] (
    [VehicleModelId]          UNIQUEIDENTIFIER NOT NULL,
    [VehicleMakeId]           UNIQUEIDENTIFIER NULL,
    [VehicleModelDescription] NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_VehicleModels] PRIMARY KEY CLUSTERED ([VehicleModelId] ASC),
    CONSTRAINT [FK_VehicleModels_VehicleMakes_VehicleMakeId] FOREIGN KEY ([VehicleMakeId]) REFERENCES [dbo].[VehicleMakes] ([VehicleMakeId])
);


GO
CREATE NONCLUSTERED INDEX [IX_VehicleModels_VehicleMakeId]
    ON [dbo].[VehicleModels]([VehicleMakeId] ASC);

