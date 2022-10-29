CREATE PROCEDURE [dbo].[get_orders_made]
    @Email varchar(128)

AS
DECLARE @return_value int
SELECT @return_value = count(O.id) 
FROM Orders O
WHERE O.RecipientId = @Email AND O.OrderStatus = 'F'
Update Statistic
SET Order_Amount = @return_value
Where User_Id = @Email
