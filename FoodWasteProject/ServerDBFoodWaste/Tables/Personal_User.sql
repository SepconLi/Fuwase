CREATE TABLE [dbo].[Personal_User] (
    [Id]       INT          NULL,
    [Email]    VARCHAR (128) NOT NULL,
    [IdNumber] VARCHAR (12) NOT NULL,
    [Name]     VARCHAR (25) NOT NULL,
    [LastName] VARCHAR (25) NOT NULL,
    PRIMARY KEY CLUSTERED ([Email] ASC),
    FOREIGN KEY ([Email]) REFERENCES [dbo].[Client] ([Email])
        ON DELETE CASCADE ON UPDATE CASCADE
);