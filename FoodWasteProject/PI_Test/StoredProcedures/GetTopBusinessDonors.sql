CREATE PROCEDURE [dbo].[get_top_business_donors]
AS
SELECT count(D.id) AS 'Donation_Amount', B.Business_Name AS 'User_Id',
101.5E5 AS 'Donated_Weight', 0 AS 'Order_Amount',  0 AS 'App_Total_Donations'
FROM Donation D, Business_User B 
WHERE D.DonorId = B.Email
GROUP BY B.Business_Name
ORDER BY count(D.id) DESC
