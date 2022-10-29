CREATE TABLE [dbo].[Campaign]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [CreatorEmail] VARCHAR(128) NOT NULL,
    [Name] NVARCHAR(50) NOT NULL,
    [Description] NVARCHAR(100) NOT NULL,
    [StartDate] DATE NOT NULL,
    [EndDate] DATE NOT NULL,
    [Goal] INT NULL,
    [Raised] INT NULL,
    [Delivered] INT NULL,
    [Province] VARCHAR(100) NOT NULL,
    [County] VARCHAR(100) NOT NULL,
    [District] VARCHAR(100) NOT NULL,
    [ExactLocation] NVARCHAR(500) NOT NULL,
    [Type] CHAR(1) NOT NULL DEFAULT 'O',
    [Status] CHAR NULL DEFAULT 'A',
    CONSTRAINT [FK_Campaign_ToCompany] FOREIGN KEY ([CreatorEmail]) REFERENCES [Business_User](Email),
    CONSTRAINT [FK_Campaign_ToTown] FOREIGN KEY ([District], [Province], [County]) REFERENCES [Town]([Name], [PName], [DName])
)
