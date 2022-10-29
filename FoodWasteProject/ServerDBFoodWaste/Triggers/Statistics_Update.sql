GO
CREATE TRIGGER statistics_update
ON dbo.donation
AFTER Update
AS
DECLARE @Email varchar(128)
BEGIN
    SET NOCOUNT ON;
    select @Email = inserted.DonorId from inserted
    EXEC get_donations_made @Email
    EXEC get_donated_weight @Email
    EXEC get_orders_made @Email
    EXEC get_total_app_donations
END
GO