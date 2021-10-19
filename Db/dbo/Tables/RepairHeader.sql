CREATE TABLE [dbo].[RepairHeader] (
    [RepairHeaderId] UNIQUEIDENTIFIER NOT NULL,
    [VehicleId]      UNIQUEIDENTIFIER NULL,
    [RepairStatusId] UNIQUEIDENTIFIER NULL,
    [JobBooked]      DATETIME2 (7)    NOT NULL,
    CONSTRAINT [PK_RepairHeader] PRIMARY KEY CLUSTERED ([RepairHeaderId] ASC),
    CONSTRAINT [FK_RepairHeader_RepairStatuses_RepairStatusId] FOREIGN KEY ([RepairStatusId]) REFERENCES [dbo].[RepairStatuses] ([RepairStatusId]),
    CONSTRAINT [FK_RepairHeader_Vehicles_VehicleId] FOREIGN KEY ([VehicleId]) REFERENCES [dbo].[Vehicles] ([VehicleId])
);


GO
CREATE NONCLUSTERED INDEX [IX_RepairHeader_VehicleId]
    ON [dbo].[RepairHeader]([VehicleId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RepairHeader_RepairStatusId]
    ON [dbo].[RepairHeader]([RepairStatusId] ASC);

