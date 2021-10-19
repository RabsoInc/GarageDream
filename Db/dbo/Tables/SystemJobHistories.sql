CREATE TABLE [dbo].[SystemJobHistories] (
    [SystemJobHistoryId] UNIQUEIDENTIFIER NOT NULL,
    [SystemJobId]        UNIQUEIDENTIFIER NULL,
    [DateExecuted]       DATETIME2 (7)    NOT NULL,
    [AutoExecuted]       BIT              NOT NULL,
    CONSTRAINT [PK_SystemJobHistories] PRIMARY KEY CLUSTERED ([SystemJobHistoryId] ASC),
    CONSTRAINT [FK_SystemJobHistories_SystemJobs_SystemJobId] FOREIGN KEY ([SystemJobId]) REFERENCES [dbo].[SystemJobs] ([SystemJobId])
);


GO
CREATE NONCLUSTERED INDEX [IX_SystemJobHistories_SystemJobId]
    ON [dbo].[SystemJobHistories]([SystemJobId] ASC);

