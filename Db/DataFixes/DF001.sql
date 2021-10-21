
UPDATE RepairInstructions
SET RepairStatusId =  (SELECT RepairStatusId FROM RepairStatuses WHERE RepairStatusDescription = 'Booked')
WHERE RepairStatusId IS NULL