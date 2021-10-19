--365

CREATE PROCEDURE [dbo].[PopulateDiary] AS

DROP TABLE IF EXISTS #DiaryDates

CREATE TABLE #DiaryDates 
(
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    WorkingDate DATE NOT NULL
)

DECLARE @DaysForward INT = ISNULL((SELECT D.DiaryNoticeForwardDays FROM DiaryOptions AS D),90)
DECLARE @StartDate AS DATE = ISNULL((SELECT DATEADD(DD,1,MAX(WorkingDate)) FROM DiaryWorkingDates),GETDATE())
DECLARE @CounterDate AS DATE = @StartDate

WHILE DATEDIFF(DD,GETDATE(),@CounterDate) < @DaysForward
BEGIN
    IF(DATENAME(DW,@CounterDate ) = 'Saturday' OR  DATENAME(DW,@CounterDate) = 'Sunday' )
        BEGIN 
            SET @CounterDate = DATEADD(DD,1,@CounterDate)
        END
    ELSE   
        BEGIN
                INSERT INTO #DiaryDates (Id, WorkingDate) VALUES (NEWID(), @CounterDate)
                SET @CounterDate = DATEADD(DD,1,@CounterDate)
        END
END 

INSERT INTO DiaryWorkingDates (DiaryWorkingDateId, WorkingDate, Processed)
SELECT NEWID(), WorkingDate, 0 FROM #DiaryDates ORDER BY WorkingDate

DROP TABLE IF EXISTS #DiaryDates