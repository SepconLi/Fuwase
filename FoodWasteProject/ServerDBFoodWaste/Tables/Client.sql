CREATE TABLE [dbo].[Client] (
    [Id]       INT          NULL,
    [Email]    VARCHAR (128) NOT NULL,
    [Province] VARCHAR (100) NULL,
    [District] VARCHAR (100) NULL,
    [Town]     VARCHAR (100) NULL,
    [Strikes]  INT          DEFAULT ((0)),
    PRIMARY KEY CLUSTERED ([Email] ASC),
    FOREIGN KEY ([Email]) REFERENCES [dbo].[_User] ([Email])
        ON DELETE CASCADE ON UPDATE CASCADE
);