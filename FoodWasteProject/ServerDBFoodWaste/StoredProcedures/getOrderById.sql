--Special Thanks to Fabian (Imborrables)

GO
		CREATE PROCEDURE GetProductsFromOrder(@orderID AS INT) AS 
			BEGIN
				SELECT *
				FROM Product
				WHERE OrderId = @orderID
			END;
	GO