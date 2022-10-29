CREATE TRIGGER Expired_Products_Not_Allowed
ON Product
AFTER INSERT
AS
BEGIN
	DECLARE products CURSOR LOCAL FOR 
		(SELECT Name, DonationId, ExpirationDate FROM inserted);
	OPEN products;
	DECLARE @cant int
	SELECT @cant = @@CURSOR_ROWS;

	DECLARE @prod_id NVARCHAR(50), @donation_id int, @exp_date DATE
	DECLARE @today DATE
	SET @today = CAST( GETDATE() AS Date );

	WHILE @cant > 0
	BEGIN
		FETCH NEXT FROM products INTO @prod_id, @donation_id, @exp_date;
		IF @exp_date = @today OR @exp_date < @today
		BEGIN
			DELETE FROM Product
			WHERE Name = @prod_id and DonationId = @donation_id;
		END;
		SET @cant = @cant -1;
	END;
		
	CLOSE products;
	DEALLOCATE products;
END;