CREATE PROCEDURE [dbo].[get_donations_made]
    @Email varchar(128)

AS
DECLARE @return_value int
SELECT @return_value = count(D.id) 
FROM Donation D
WHERE D.DonorId = @Email AND D.Status = 'D'
Update Statistic
SET Donation_Amount = @return_value
Where User_Id = @Email
