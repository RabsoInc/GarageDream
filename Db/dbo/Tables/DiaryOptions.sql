CREATE TABLE [dbo].[DiaryOptions] (
    [DiaryOptionId]          UNIQUEIDENTIFIER NOT NULL,
    [DiaryNoticeForwardDays] INT              NOT NULL,
    CONSTRAINT [PK_DiaryOptions] PRIMARY KEY CLUSTERED ([DiaryOptionId] ASC)
);

