CREATE FUNCTION [dbo].[fn_GetDiarySlots] (@WorkArea VARCHAR(100),  @RequiredSlots INT)
RETURNS TABLE AS
RETURN
WITH DateList AS (
SELECT DWD.WorkingDate, COUNT(DS.UnitNumber) AS 'SlotsAvailable'
FROM DiarySlots DS
	INNER JOIN WorkAreas WA ON DS.WorkAreaId = WA.WorkAreaId AND WA.WorkAreaDescription = @WorkArea
	INNER JOIN DiaryWorkingDates DWD ON DS.DiaryWorkingDateId = DWD.DiaryWorkingDateId AND DWD.Processed = 1 AND DWD.WorkingDate > GETDATE()
WHERE DS.RepairInstructionId IS NULL
GROUP BY DWD.WorkingDate
)

SELECT TOP 10 CAST(WorkingDate AS DATE) AS 'WorkingDate'
FROM DateList DL
WHERE DL.SlotsAvailable >= @RequiredSlots
ORDER BY DL.WorkingDate