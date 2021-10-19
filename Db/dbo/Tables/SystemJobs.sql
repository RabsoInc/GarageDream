CREATE TABLE [dbo].[SystemJobs] (
    [SystemJobId]          UNIQUEIDENTIFIER NOT NULL,
    [SystemJobDescription] NVARCHAR (150)   NOT NULL,
    [AutoRunOnStartUp]     BIT              NOT NULL,
    [ProcedureName]        NVARCHAR (150)   NOT NULL,
    CONSTRAINT [PK_SystemJobs] PRIMARY KEY CLUSTERED ([SystemJobId] ASC)
);

