CREATE FUNCTION [dbo].[fn_CustomerHasAddress] (@CustomerId UNIQUEIDENTIFIER) RETURNS BIT AS
BEGIN
    RETURN 
        CASE 
            WHEN EXISTS (SELECT TOP 1 1 FROM Customers C WHERE C.AddressId IS NOT NULL AND C.CustomerId = @CustomerId)
        THEN 1
        ELSE 0
        END
END