CREATE TABLE [dbo].[ConfirmationCode]
(
	[Id] INT NULL, 
    [Email] VARCHAR(128) NOT NULL, 
    [Code] INT NOT NULL,
    PRIMARY KEY ([Email]),
    FOREIGN KEY ([Email]) REFERENCES [dbo].[_User] ([Email])
)
