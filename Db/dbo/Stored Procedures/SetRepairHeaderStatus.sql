
CREATE PROCEDURE [dbo].[SetRepairHeaderStatus] (@RepairHeaderId UNIQUEIDENTIFIER) AS
BEGIN
UPDATE RepairHeader 
SET RepairStatusId = 
(
	SELECT TOP 1 RS.RepairStatusId FROM RepairInstructions RI
		INNER JOIN RepairStatuses RS ON RI.RepairStatusId = RS.RepairStatusId
	WHERE RepairHeaderId = @RepairHeaderId
	ORDER BY RS.PrecedenceOrder
)
WHERE RepairHeaderId = @RepairHeaderId
END