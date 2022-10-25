-- Set the Status of a Donation by checking if its products are pending or have already been donated
-- A -> Active/Available: NOT ALL of its products are in a pending order or have already been donated
-- P -> Pending: ALL of its products are in a pending order or have already been donated, but not all have been donated.
-- D -> Complete Donated / Finished: ALL of its products were donated in a complete donation (one unique order).
-- B -> Partial Donated / Finished: ALL of its products were donated in a partial donation (two or more orders).
CREATE PROCEDURE [dbo].[SetDonationStatus] 
	@DonationId int
AS BEGIN
	Declare @TotalQuantity as INT

	SELECT @TotalQuantity = SUM(P.Quantity)
	FROM Product as P JOIN Donation as D ON P.DonationId = D.Id
	WHERE DonationId = @DonationId

	IF(@TotalQuantity > 0) BEGIN
		-- Active/Available
		UPDATE Donation
			SET Status = 'A'
			WHERE Id = @DonationId
	END
	ELSE IF (@TotalQuantity = 0) BEGIN
		DECLARE @AllProductsDonated BIT
		SET @AllProductsDonated = dbo.AreAllProductsDonated(@DonationId)
		-- 0 = true | 1 = false
		IF (@AllProductsDonated = 0) BEGIN
			-- All Products of the Donation has been donated
			-- Determine if the Donation was Complete or Partial
			DECLARE @IsCompleteDonation BIT
			SET @IsCompleteDonation = dbo.IsCompleteDonation(@DonationId)
			-- 0 = true | 1 = false
			IF (@IsCompleteDonation = 0) BEGIN
				-- Complete Donated / Finished
				UPDATE Donation
					SET Status = 'D'
					WHERE Id = @DonationId
			END
			ELSE BEGIN
				-- Partial Donated / Finished
				UPDATE Donation
					SET Status = 'B'
					WHERE Id = @DonationId
			END
		END
		-- NOT all products of the Donation has been donated yet
		ELSE BEGIN
			-- Pending
			UPDATE Donation
				SET Status = 'P'
				WHERE Id = @DonationId
		END
	END
END;
