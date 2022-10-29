CREATE TABLE [dbo].[Messages]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Date_Message] DATETIME NULL, 
    [Text] VARCHAR(256) NULL, 
    [SenderId] VARCHAR(128) NULL, 
    [OrderId] INT NOT NULL

)
