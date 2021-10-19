CREATE TABLE [dbo].[DiarySlots] (
    [DiarySlotId]               UNIQUEIDENTIFIER NOT NULL,
    [DiaryWorkingDateId]        UNIQUEIDENTIFIER NULL,
    [WorkAreaId]                UNIQUEIDENTIFIER NULL,
    [UnitNumber]                INT              NOT NULL,
    [CustomerJobRepairHeaderId] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_DiarySlots] PRIMARY KEY CLUSTERED ([DiarySlotId] ASC),
    CONSTRAINT [FK_DiarySlots_DiaryWorkingDates_DiaryWorkingDateId] FOREIGN KEY ([DiaryWorkingDateId]) REFERENCES [dbo].[DiaryWorkingDates] ([DiaryWorkingDateId]),
    CONSTRAINT [FK_DiarySlots_RepairHeader_CustomerJobRepairHeaderId] FOREIGN KEY ([CustomerJobRepairHeaderId]) REFERENCES [dbo].[RepairHeader] ([RepairHeaderId]),
    CONSTRAINT [FK_DiarySlots_WorkAreas_WorkAreaId] FOREIGN KEY ([WorkAreaId]) REFERENCES [dbo].[WorkAreas] ([WorkAreaId])
);




GO



GO
CREATE NONCLUSTERED INDEX [IX_DiarySlots_WorkAreaId]
    ON [dbo].[DiarySlots]([WorkAreaId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_DiarySlots_DiaryWorkingDateId]
    ON [dbo].[DiarySlots]([DiaryWorkingDateId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_DiarySlots_CustomerJobRepairHeaderId]
    ON [dbo].[DiarySlots]([CustomerJobRepairHeaderId] ASC);

