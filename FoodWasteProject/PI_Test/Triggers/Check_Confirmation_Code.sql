CREATE TRIGGER Check_Confirmation_Code
ON ConfirmationCode
INSTEAD OF INSERT
AS

	DECLARE @insertedEmail varchar(128)
	SELECT @insertedEmail = inserted.Email
	FROM inserted
	IF EXISTS (SELECT ConfirmationCode.Email
			   FROM ConfirmationCode, inserted
			   WHERE ConfirmationCode.Email = inserted.Email)
		BEGIN
			DELETE FROM ConfirmationCode
			WHERE ConfirmationCode.Email = @insertedEmail;
			INSERT INTO ConfirmationCode
			SELECT *
			FROM inserted;
		END
	ELSE
		BEGIN
			INSERT INTO ConfirmationCode
			SELECT *
			FROM inserted;
		END