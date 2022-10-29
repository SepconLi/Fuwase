-- Created to use in SetDonationStatus
-- Checks the Status of the Products of a Donation
-- Returns 0 if all the Products of a Donation were "Donated".
-- Returns 1 if not all Products of a Donation are "Donated".
CREATE FUNCTION [dbo].[AreAllProductsDonated] (@DonationId int)
RETURNS BIT
AS BEGIN
	DECLARE @Donated INT
	-- Get quantity of products that are not "Donated"(status) . Products of a Donation in the table OrderProduct
	SELECT @Donated = COUNT(P.Name)
	FROM Product as P 
	JOIN Donation as D 
	ON P.DonationId = D.Id
	JOIN OrderProduct as OP 
	ON P.Id = OP.ProductId
	JOIN Orders as O 
	ON OP.OrderId = O.Id
	WHERE P.DonationId = @DonationId AND O.OrderStatus != 'F' -- Order Finalized / Completed

	DECLARE @AllDonated BIT
	IF(@Donated = 0) BEGIN
		-- All products are Donated
		SET @AllDonated = 0
	END
	ELSE BEGIN
		-- NOT all products are Donated
		SET @AllDonated = 1
	END
	RETURN @AllDonated
END;