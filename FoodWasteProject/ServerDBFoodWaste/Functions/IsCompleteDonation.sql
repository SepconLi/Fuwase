-- Created to use in SetDonationStatus
-- Checks if the products of a Donation are taken in just one Order or not
-- If CompleteDonation is 0, then the Donation is Complete
-- If CompleteDonation is 1, then the Donation is Partial
CREATE FUNCTION [dbo].[IsCompleteDonation] (@DonationId int)
RETURNS BIT
AS BEGIN
	-- Quantity of orders that take products from this donation
	DECLARE @QuantityOrdersFromDonation INT
	
	SELECT @QuantityOrdersFromDonation = COUNT(OP.ProductId)
	FROM OrderProduct as OP
	JOIN Product as P
	ON P.Id = OP.ProductId
	JOIN Donation as D
	ON P.DonationId = D.Id
	WHERE P.DonationId = @DonationId

	DECLARE @CompleteDonation BIT
	IF(@QuantityOrdersFromDonation = 1) BEGIN
		-- Is complete donation
		SET @CompleteDonation = 0
	END
	ELSE BEGIN
		IF(@QuantityOrdersFromDonation > 1) BEGIN
			-- Is Partial Donation
			SET @CompleteDonation = 1
		END
	END
	RETURN @CompleteDonation
END;