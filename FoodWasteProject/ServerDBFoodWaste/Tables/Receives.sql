CREATE TABLE [dbo].[Receives]
(
	[CampaignId] INT NOT NULL,
	[DonationId] INT NOT NULL,
    CONSTRAINT Donation_Campaign PRIMARY KEY ([CampaignId],[DonationId]),
    CONSTRAINT [FK_Current_Campaign] FOREIGN KEY ([CampaignId]) REFERENCES [Campaign](Id),
    CONSTRAINT [FK_Received_Donation] FOREIGN KEY ([DonationId]) REFERENCES [Donation](Id)
)
