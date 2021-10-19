CREATE TABLE [dbo].[VehicleMakes] (
    [VehicleMakeId]          UNIQUEIDENTIFIER NOT NULL,
    [VehicleMakeDescription] NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_VehicleMakes] PRIMARY KEY CLUSTERED ([VehicleMakeId] ASC)
);

