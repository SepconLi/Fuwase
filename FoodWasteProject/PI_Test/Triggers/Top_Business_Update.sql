GO
CREATE TRIGGER top_businesses_update
ON dbo.statistic
AFTER Update
AS
BEGIN
    SET NOCOUNT ON;
    EXEC get_top_business_donors
END
GO