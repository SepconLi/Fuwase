CREATE TRIGGER Check_Personal_Account
ON Personal_User
INSTEAD OF INSERT
AS
	IF EXISTS (SELECT _User.Email
			   FROM _User, inserted
			   WHERE _User.Email = inserted.Email
			   AND _User.Role = 'Business')
		BEGIN
			Print 'Esta email ya esta enlazado a una cuenta empresarial';
		END
	ELSE
		BEGIN
			INSERT INTO Personal_User
			SELECT *
			FROM inserted
		END
