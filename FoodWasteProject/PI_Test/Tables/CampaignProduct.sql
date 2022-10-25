CREATE TABLE [dbo].[CampaignProduct]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [CampaignId] INT NOT NULL,
    [Name] NVARCHAR(50) NOT NULL,
    [FoodType] NVARCHAR(30) NOT NULL,
    [ProductType] NVARCHAR(30) NOT NULL,
    [Quantity] INT NOT NULL DEFAULT 0,
    [Weight] FLOAT NOT NULL DEFAULT 0,
    [Goal] INT NOT NULL DEFAULT 0,
    [Raised] INT NOT NULL DEFAULT 0,
    CONSTRAINT [FK_Asociated_Campaign] FOREIGN KEY ([CampaignId]) REFERENCES [Campaign](Id)--,
    -- CONSTRAINT [FK_CampaignProduct_ToFoodType] FOREIGN KEY (FoodType) REFERENCES [FoodType](Name),
    -- CONSTRAINT [FK_CampaignProduct_ToProductType] FOREIGN KEY (ProductType) REFERENCES [ProductType](Name)
)
