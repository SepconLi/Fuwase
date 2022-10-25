CREATE PROCEDURE [dbo].[ClearDonation]
	@donationID INT
AS 
	DELETE FROM Donation
	WHERE Donation.Id = @donationID
