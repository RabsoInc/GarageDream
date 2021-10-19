CREATE VIEW [dbo].[CustomerIndexView]
AS 
SELECT
C.CustomerId, CONCAT(T.TitleDescription,' ',C.FirstName,' ',C.LastName) AS 'CustomerName', A.AddressLine1, 0 AS 'Balance'
FROM Customers AS C
    INNER JOIN Titles AS T ON C.TitleId = T.TitleId
    LEFT OUTER JOIN Addresses AS A ON C.AddressId = A.AddressId 

