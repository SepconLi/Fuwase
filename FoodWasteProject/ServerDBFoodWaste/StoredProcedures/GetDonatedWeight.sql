CREATE PROCEDURE [dbo].[get_donated_weight]
    @Email varchar(128)

AS
DECLARE @return_value float
    select @return_value = sum(Donation_weight)/1000 from
    (
        select P.Weight * OP.Quantity As 'Donation_weight' from Product P 
        JOIN Donation D ON D.Status = 'D' AND P.DonationId = D.Id
        AND D.DonorId = @Email
        JOIN Orders O ON O.DonorId = @Email AND O.OrderStatus = 'F'
        JOIN OrderProduct OP ON P.Id = OP.ProductId
        GROUP BY D.Id, P.Id, P.Weight, OP.Quantity 
    )  Donation_weight
    Update Statistic
    SET Donated_Weight = ISNULL(@return_value, 0)
    Where User_Id = @Email
