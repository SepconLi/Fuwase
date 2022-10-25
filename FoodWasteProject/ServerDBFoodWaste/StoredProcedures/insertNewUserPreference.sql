CREATE PROCEDURE [dbo].[insertNewUserPreference]
	@userEmail NVARCHAR(128),
	@foodRestriction NVARCHAR(30)
AS 
	INSERT INTO UserPreferences VALUES(@userEmail, @foodRestriction)