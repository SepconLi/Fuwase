CREATE TABLE [dbo].[Business_User] (
    [Id]                INT          NULL,
    [Email]             VARCHAR (128) NOT NULL,
    [Business_Name]     VARCHAR (128)    NOT NULL,
    [Legal_Document]    CHAR (10) NOT NULL, --X-XXX-XXXXXX
    [Alliance_Start]     DATE NULL,
    [Person_In_Charge]  VARCHAR (128) NULL,
    PRIMARY KEY CLUSTERED ([Email] ASC),
    FOREIGN KEY ([Email]) REFERENCES [dbo].[Client] ([Email])
        ON DELETE CASCADE ON UPDATE CASCADE
);
