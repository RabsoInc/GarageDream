CREATE TABLE [dbo].[RepairCategories] (
    [RepairCategoryId]          UNIQUEIDENTIFIER NOT NULL,
    [RepairCategoryDescription] NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_RepairCategories] PRIMARY KEY CLUSTERED ([RepairCategoryId] ASC)
);




GO


