CREATE TABLE [dbo].[Belongs_to]
(
	[ProductId] INT NOT NULL,
	[CampaignId] INT NOT NULL,
	[Amount] INT DEFAULT 0,
	CONSTRAINT BelongsKey PRIMARY KEY ([ProductId], [CampaignId]),
    CONSTRAINT [FK_Belongs_ToProduct] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]),
    CONSTRAINT [FK_Belongs_ToCampaign] FOREIGN KEY ([CampaignId]) REFERENCES [Campaign](Id)
)
