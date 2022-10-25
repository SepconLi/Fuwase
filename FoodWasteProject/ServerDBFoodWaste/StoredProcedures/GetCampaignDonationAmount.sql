CREATE PROCEDURE [dbo].[GetCampaignDonationAmount]
    @campaignId INT
AS
BEGIN
    SELECT COUNT(Id)
    From Donation D
    --WHERE D.CampaignId = @campaignId
    RETURN;
END;