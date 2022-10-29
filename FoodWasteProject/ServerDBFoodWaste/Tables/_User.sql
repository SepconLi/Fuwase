CREATE TABLE [dbo].[_User] (
    [Id]                INT             NULL,
    [Email]             VARCHAR (128)    NOT NULL,
    [UserName]          VARCHAR (100)    NOT NULL,
    [Password]          VARCHAR (127)   NOT NULL,
    [PhoneNumber]       INT             NULL,
    [Profile_Picture]   VARCHAR(MAX) NULL,
    [Status]            INT NOT NULL DEFAULT 1,
    [Role]              VARCHAR (20) NULL,
    [Anom_Preference]   BIT NOT NULL DEFAULT 0,
    [HashedEmail]       VARCHAR (450) NULL,
    PRIMARY KEY CLUSTERED ([Email] ASC),
    CONSTRAINT [chk_phn] CHECK ([PhoneNumber]>=(10000000) AND [PhoneNumber]<=(99999999)),
    CONSTRAINT [chk_role] CHECK ([Role] = 'Personal' OR [Role] = 'Business' OR [Role] = 'Admin'),
    CONSTRAINT [chk_status] CHECK ([Status]<=4 AND  [Status]>0)
);