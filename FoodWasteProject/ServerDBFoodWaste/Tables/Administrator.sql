CREATE TABLE [dbo].[Administrator] (
    [Id]       INT          NULL,
    [Email]    VARCHAR (128) NOT NULL,
    [AdminId] VARCHAR (15) NOT NULL,
    [Name]     VARCHAR (25) NOT NULL,
    [LastName] VARCHAR (25) NOT NULL,
    PRIMARY KEY CLUSTERED ([Email] ASC),
    FOREIGN KEY ([Email]) REFERENCES [dbo].[_User] ([Email])
        ON DELETE CASCADE ON UPDATE CASCADE
);
