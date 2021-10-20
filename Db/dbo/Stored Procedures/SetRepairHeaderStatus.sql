CREATE PROCEDURE [dbo].[SetRepairHeaderStatus] (@RepairHeaderId UNIQUEIDENTIFIER) AS
BEGIN
	DECLARE @Status AS UNIQUEIDENTIFIER = (SELECT RepairStatusId FROM RepairStatuses WHERE RepairStatusDescription = 'Booked')
	UPDATE RepairHeader SET RepairStatusId = @Status WHERE RepairStatusId = @RepairHeaderId
END