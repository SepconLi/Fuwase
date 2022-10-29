-- Imborrables: Fabian (Added in SSMS, haven't tested via VS)

CREATE PROCEDURE [dbo].[deleteAllRestrictionsPreferences]
	@userEmail NVARCHAR(128)
AS 
		DELETE FROM UserPreferences WHERE UserPreferences.UserEmail = @userEmail