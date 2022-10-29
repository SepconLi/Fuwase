/*
	Use to Update the quantity for a product when the order is rejected
*/
CREATE PROCEDURE [dbo].[UpdateQuantityForRejectOrder] 
	@OrderIdp int
AS BEGIN
	DECLARE @Id as INT, @Name as NVARCHAR(50), @FoodType as NVARCHAR(30), @ProductType as NVARCHAR(30), 
		@Quantity as INT, @Weight as FLOAT,
		@ExpirationDate as DATE, @Status CHAR(1), @Image as VARBINARY(MAX), @Brand as NVARCHAR(30),
		@DonationId as INT, @OrderId as INT
	-- Cursor to iterate the products of an order
	DECLARE cursorProduct CURSOR FOR
		SELECT P.Id, P.Name, P.FoodType,P.ProductType, P.Quantity, P.Weight,
		P.ExpirationDate, P.Status, P.Image, P.Brand, P.DonationId, P.OrderId
		FROM Product as P
		JOIN OrderProduct as OP 
		ON P.Id = OP.ProductId 
		JOIN Orders as O
		ON OP.OrderId = O.Id
		WHERE O.Id = @OrderIdp
	OPEN cursorProduct
	FETCH NEXT FROM cursorProduct INTO @Id, @Name, @FoodType, @ProductType, @Quantity, @Weight,
		@ExpirationDate, @Status, @Image, @Brand, @DonationId, @OrderId
	WHILE @@FETCH_STATUS = 0 BEGIN		
		DECLARE @TotalQuantity as INT
		-- Get current quantity of the product plus the quantity in the order 
		-- (available quantity + quantity pending in order)
		SELECT @TotalQuantity = @Quantity + OP.Quantity
		FROM OrderProduct as OP 
		JOIN Product 
		ON @Id = OP.ProductId
		JOIN Orders as O ON O.Id = @OrderIdp
		-- UPDATE Quantity in Product
		UPDATE Product
			SET Quantity = @TotalQuantity
			WHERE Id = @Id

		FETCH NEXT FROM cursorProduct INTO @Id, @Name, @FoodType, @ProductType, @Quantity, @Weight,
			@ExpirationDate, @Status, @Image, @Brand, @DonationId, @OrderId
	END
	CLOSE cursorProduct
	DEALLOCATE cursorProduct
	-- Set all order products quantity to zero (0)
	UPDATE OrderProduct
		SET Quantity = 0
		WHERE OrderProduct.OrderId = @OrderIdp
END;
