CREATE FUNCTION fn_DiarySlotIndexView(@StartDate AS DATE, @EndDate AS DATE, @WorkArea AS VARCHAR(50))
RETURNS TABLE
AS
RETURN
SELECT CAST(DWD.WorkingDate AS DATE) AS 'WorkingDate', WA.WorkAreaDescription,
	(SELECT COUNT(*) FROM DiarySlots DS2 
		WHERE DS.DiaryWorkingDateId = DS2.DiaryWorkingDateId 
		AND DS.WorkAreaId = DS2.WorkAreaId
		AND DS2.CustomerJobId IS NULL) AS 'AvailableSlots',
	(SELECT COUNT(*) FROM DiarySlots DS2 
		WHERE DS.DiaryWorkingDateId = DS2.DiaryWorkingDateId 
		AND DS.WorkAreaId = DS2.WorkAreaId
		AND DS2.CustomerJobId IS NOT NULL) AS 'BookedSlots'
FROM DiarySlots DS
	INNER JOIN DiaryWorkingDates DWD ON DS.DiaryWorkingDateId = DWD.DiaryWorkingDateId
	INNER JOIN WorkAreas WA ON DS.WorkAreaId = WA.WorkAreaId
WHERE DS.CustomerJobId IS NULL
AND DWD.WorkingDate > GETDATE()
AND
(
	(@WorkArea IS NOT NULL AND WA.WorkAreaDescription = @WorkArea)
OR
	(@WorkArea IS NULL AND WA.WorkAreaDescription IN (SELECT WorkAreaDescription FROM WorkAreas))
)

GROUP BY DWD.WorkingDate, WA.WorkAreaDescription, DS.DiaryWorkingDateId, DS.WorkAreaId
--ORDER BY DWD.WorkingDate, WA.WorkAreaDescription