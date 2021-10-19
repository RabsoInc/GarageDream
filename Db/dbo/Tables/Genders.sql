CREATE TABLE [dbo].[Genders] (
    [GenderId]          UNIQUEIDENTIFIER NOT NULL,
    [GenderDescription] NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_Genders] PRIMARY KEY CLUSTERED ([GenderId] ASC)
);

