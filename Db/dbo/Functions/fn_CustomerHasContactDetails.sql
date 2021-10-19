CREATE FUNCTION fn_CustomerHasContactDetails (@CustomerId UNIQUEIDENTIFIER) RETURNS BIT AS
BEGIN
    RETURN 
        CASE 
            WHEN EXISTS (SELECT TOP 1 1 FROM CustomerContactDetails CD WHERE CD.CustomerId = @CustomerId)
        THEN 1
        ELSE 0
        END
END