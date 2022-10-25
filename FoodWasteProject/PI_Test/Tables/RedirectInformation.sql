CREATE TABLE [dbo].[RedirectInformation]
(
    [Hash] NVARCHAR(200) PRIMARY KEY,
    [Email] VARCHAR(128) NOT NULL,
    [Route] NVARCHAR(100) NOT NULL,
    [Param] NVARCHAR(150) NOT NULL,
    [Key] NVARCHAR(8) NOT NULL,
    [Expiration] DATE NOT NULL
    FOREIGN KEY ([Email]) REFERENCES [dbo].[_User] ([Email])
        ON DELETE CASCADE ON UPDATE CASCADE
)