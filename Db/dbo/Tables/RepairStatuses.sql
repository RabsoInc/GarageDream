CREATE TABLE [dbo].[RepairStatuses] (
    [RepairStatusId]          UNIQUEIDENTIFIER NOT NULL,
    [PrecedenceOrder]         INT              NOT NULL,
    [RepairStatusDescription] NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_RepairStatuses] PRIMARY KEY CLUSTERED ([RepairStatusId] ASC)
);

