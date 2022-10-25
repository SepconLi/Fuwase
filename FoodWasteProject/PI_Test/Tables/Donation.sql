CREATE TABLE [dbo].[Donation]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CreationDate] DATE NOT NULL, 
    [Status] CHAR(1) NOT NULL DEFAULT 'A', 
    [Province] VARCHAR(100) NOT NULL , 
    [County] VARCHAR(100) NOT NULL ,
    [District] VARCHAR(100) NOT NULL, 
    [ExactLocation] NVARCHAR(500) NOT NULL,
	[Description] NVARCHAR(50) NULL,
    [DonorId] VARCHAR(128) NOT NULL,
    CONSTRAINT [FK_Donation_ToDonor] FOREIGN KEY ([DonorId]) REFERENCES [Client](Email),
    CONSTRAINT [FK_Donation_ToTown] FOREIGN KEY ([District], [Province], [County]) REFERENCES [Town]([Name], [PName], [DName])
)