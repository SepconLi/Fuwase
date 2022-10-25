CREATE TABLE [dbo].[UserPreferences]
(
	[UserEmail] VARCHAR(128) NOT NULL,
	[FoodRestriction] NVARCHAR(30) NOT NULL,

	/* CONSTRAINT UserPreferencesKey PRIMARY KEY ([UserEmail], [FoodRestriction]), 
    CONSTRAINT [FK_Restriction_ToDonation] FOREIGN KEY ([UserEmail]) REFERENCES [User]([Email]) */
)