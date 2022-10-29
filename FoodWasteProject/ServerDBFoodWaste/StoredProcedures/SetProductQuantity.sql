CREATE PROCEDURE [dbo].[SetProductQuantity]
	@productId int,
	@quantity INT 
AS
	UPDATE Product
	SET Quantity = @quantity
	WHERE Product.Id = @productId
