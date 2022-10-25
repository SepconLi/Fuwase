CREATE TABLE [dbo].[Restriction]
(
	[FoodRestriction] VARCHAR(30) NOT NULL,
    [ProductId] INT NOT NULL,

	CONSTRAINT RestrictionKey PRIMARY KEY ([ProductId], [FoodRestriction]), 
    CONSTRAINT [FK_Restriction_ToProduct] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]),
    CONSTRAINT [FK_Restriction_ToAllergen] FOREIGN KEY ([FoodRestriction]) REFERENCES [Allergen]([Name])
)