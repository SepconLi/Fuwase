CREATE PROCEDURE [dbo].[GetProvincesStats]
AS
SELECT P.Name AS 'Name' , count(D.id) AS 'Donations'
FROM Donation D, Province P
WHERE D.Province = P.Name
GROUP BY P.Name
ORDER BY count(D.id) DESC
