CREATE TABLE [dbo].[DiaryWorkingDates] (
    [DiaryWorkingDateId] UNIQUEIDENTIFIER NOT NULL,
    [WorkingDate]        DATETIME2 (7)    NOT NULL,
    [Processed]          BIT              DEFAULT (CONVERT([bit],(0))) NOT NULL,
    CONSTRAINT [PK_DiaryWorkingDates] PRIMARY KEY CLUSTERED ([DiaryWorkingDateId] ASC)
);



