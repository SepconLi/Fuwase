-- User's Module Stored Procedure 1
CREATE PROCEDURE [dbo].[getConfirmationCode]
	@email VARCHAR(128)
AS
	BEGIN
		SELECT *
		FROM ConfirmationCode CC
		WHERE CC.Email = @email
	END
