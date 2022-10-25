GO
CREATE TRIGGER new_user_statistics
ON dbo.Client
AFTER INSERT
AS
DECLARE @Email varchar(128)
BEGIN
    SET NOCOUNT ON;
    select @Email = inserted.Email from inserted
    INSERT INTO Statistic(User_Id, Donation_Amount, Order_Amount, Donated_Weight)
    VALUES (@Email, 0, 0, 0)
END
GO