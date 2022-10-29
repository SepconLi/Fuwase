CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [OrderStatus] NCHAR(1) NULL, 
    [DonorId] VARCHAR(128) NOT NULL, 
    [RecipientId] VARCHAR(128) NOT NULL
)
