-- User's Module Stored Procedure 2
CREATE PROCEDURE [dbo].[addConfirmationCode]
	@email	VARCHAR(128),
	@code	INT,
	@id		INT
AS
	INSERT INTO ConfirmationCode (Email, Code, Id)
	VALUES(@email, @code, @id)
