CREATE PROCEDURE [dbo].[ClearProductsFromDonation]
	@donationID INT
AS 
	DELETE FROM Product
	WHERE Product.DonationId = @donationID
