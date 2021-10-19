CREATE TABLE [dbo].[WorkAreas] (
    [WorkAreaId]          UNIQUEIDENTIFIER NOT NULL,
    [WorkAreaDescription] NVARCHAR (MAX)   DEFAULT (N'') NOT NULL,
    [DefaultUnits]        INT              DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_WorkAreas] PRIMARY KEY CLUSTERED ([WorkAreaId] ASC)
);



