CREATE PROCEDURE [dbo].[getDistricts]

    @province VARCHAR(100),
    @county VARCHAR(100)
AS
BEGIN
    SELECT *
    FROM Town T
    WHERE T.PName = @province
    AND T.DName = @county
    ORDER BY T.Name
    RETURN;
END;