CREATE PROCEDURE [dbo].[GetProductsFromOrder]
	@orderID int
AS
	SELECT P.Id, P.Name, P.FoodType,P.ProductType, OrderProduct.Quantity, P.Weight,
	P.ExpirationDate, P.Status, P.Image, P.Brand, P.DonationId, P.OrderId 
	FROM Product AS P
	JOIN OrderProduct 
		ON P.Id = OrderProduct.ProductId
	JOIN Orders ON OrderProduct.OrderId = Orders.Id
	WHERE Orders.Id = @orderID