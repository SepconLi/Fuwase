CREATE PROCEDURE [dbo].[getCountys]

    @province VARCHAR(100)
AS
BEGIN
    SELECT *
    From District D
    WHERE D.PName = @province
    ORDER BY D.Name
    RETURN;
END;