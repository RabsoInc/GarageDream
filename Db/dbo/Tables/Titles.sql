CREATE TABLE [dbo].[Titles] (
    [TitleId]          UNIQUEIDENTIFIER NOT NULL,
    [TitleDescription] NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_Titles] PRIMARY KEY CLUSTERED ([TitleId] ASC)
);

