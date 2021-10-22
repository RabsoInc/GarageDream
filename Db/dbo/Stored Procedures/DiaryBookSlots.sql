

CREATE PROCEDURE [dbo].[DiaryBookSlots] (@Units AS INT, @BookedDate AS CHAR(10), @WorkArea AS VARCHAR(100), @RepairInstruction AS UNIQUEIDENTIFIER) AS
BEGIN TRANSACTION
-- UPDATE THE SLOTS
UPDATE DiarySlots SET RepairInstructionId = @RepairInstruction WHERE DiarySlotId IN
(SELECT TOP (@Units) DiarySlotId
FROM DiarySlots DS
	INNER JOIN DiaryWorkingDates DWD 
		ON DS.DiaryWorkingDateId = DWD.DiaryWorkingDateId 
		AND DWD.WorkingDate = convert(date, @BookedDate, 103)
	INNER JOIN WorkAreas WA
		ON DS.WorkAreaId = WA.WorkAreaId AND WA.WorkAreaDescription = @WorkArea
WHERE DS.RepairInstructionId IS NULL
ORDER BY UnitNumber)

-- Update the scheduled date and status
UPDATE RepairInstructions SET ScheduledDate = convert(date, @BookedDate, 103),
	RepairStatusId = (SELECT RepairStatusId FROM RepairStatuses RS WHERE RS.RepairStatusDescription = 'Scheduled')
WHERE RepairInstructionId = @RepairInstruction

COMMIT TRANSACTION