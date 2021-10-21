CREATE TABLE [dbo].[RepairInstructions] (
    [RepairInstructionId] UNIQUEIDENTIFIER NOT NULL,
    [RepairHeaderId]      UNIQUEIDENTIFIER NULL,
    [RepairCategoryId]    UNIQUEIDENTIFIER NULL,
    [WorkAreaId]          UNIQUEIDENTIFIER NULL,
    [ScheduledDate]       DATETIME2 (7)    NOT NULL,
    [Comments]            NVARCHAR (100)   NULL,
    [RepairStatusId]      UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_RepairInstructions] PRIMARY KEY CLUSTERED ([RepairInstructionId] ASC),
    CONSTRAINT [FK_RepairInstructions_RepairCategories_RepairCategoryId] FOREIGN KEY ([RepairCategoryId]) REFERENCES [dbo].[RepairCategories] ([RepairCategoryId]),
    CONSTRAINT [FK_RepairInstructions_RepairHeader_RepairHeaderId] FOREIGN KEY ([RepairHeaderId]) REFERENCES [dbo].[RepairHeader] ([RepairHeaderId]),
    CONSTRAINT [FK_RepairInstructions_RepairStatuses_RepairStatusId] FOREIGN KEY ([RepairStatusId]) REFERENCES [dbo].[RepairStatuses] ([RepairStatusId]),
    CONSTRAINT [FK_RepairInstructions_WorkAreas_WorkAreaId] FOREIGN KEY ([WorkAreaId]) REFERENCES [dbo].[WorkAreas] ([WorkAreaId])
);




GO
CREATE NONCLUSTERED INDEX [IX_RepairInstructions_WorkAreaId]
    ON [dbo].[RepairInstructions]([WorkAreaId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RepairInstructions_RepairHeaderId]
    ON [dbo].[RepairInstructions]([RepairHeaderId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RepairInstructions_RepairCategoryId]
    ON [dbo].[RepairInstructions]([RepairCategoryId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RepairInstructions_RepairStatusId]
    ON [dbo].[RepairInstructions]([RepairStatusId] ASC);

