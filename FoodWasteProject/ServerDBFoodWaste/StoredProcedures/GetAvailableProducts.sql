CREATE PROCEDURE [dbo].[GetAvailableProducts]
AS
	SELECT *
	FROM Product
	WHERE OrderId IS NULL
