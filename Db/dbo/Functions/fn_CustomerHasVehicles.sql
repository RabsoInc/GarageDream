CREATE FUNCTION [dbo].[fn_CustomerHasVehicles] (@CustomerId UNIQUEIDENTIFIER) RETURNS BIT AS
BEGIN
    RETURN 
        CASE 
            WHEN EXISTS (SELECT TOP 1 1 FROM Vehicles V WHERE V.CustomerId = @CustomerId)
        THEN 1
        ELSE 0
        END
END