CREATE PROCEDURE [dbo].[get_total_app_donations]
AS
SELECT count(id)  AS  'App_Total_Donations', '' AS 'User_Id',
101.5E5 AS 'Donated_Weight', 0 AS 'Order_Amount', 0 AS 'Donation_Amount'
FROM Donation
