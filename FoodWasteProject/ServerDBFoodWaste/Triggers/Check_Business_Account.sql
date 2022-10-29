CREATE TRIGGER Check_Business_Account
ON Business_User
INSTEAD OF INSERT
AS
	IF EXISTS (SELECT _User.Email
			   FROM _User, inserted
			   WHERE _User.Email = inserted.Email
			   AND _User.Role = 'Personal')
		BEGIN
			Print 'Esta email ya esta enlazado a una cuenta personal';
		END
	ELSE
		BEGIN
			INSERT INTO Business_User
			SELECT *
			FROM inserted
		END