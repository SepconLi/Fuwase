CREATE TABLE [dbo].[Notification]
(
	[Id]  INT NOT NULL PRIMARY KEY IDENTITY, 
    [Email] VARCHAR(128) NOT NULL, 
    [NotificationText] VARCHAR(256) NULL, 
    [Link] VARCHAR(64) NOT NULL, 
    [ReadNotification] BIT NULL, 
    [TimeNotification] DATETIME NULL, 
    CONSTRAINT [PK_Notification_To_User] FOREIGN KEY ([Email]) REFERENCES [dbo]._User([Email])
)
