CREATE TABLE [dbo].[District]
(
	[Name] VARCHAR(100) NOT NULL , 
    [PName] VARCHAR(100) NOT NULL, 
    PRIMARY KEY ([Name], [PName]), 
    CONSTRAINT [FK_District_ToProvince] FOREIGN KEY ([PName]) REFERENCES [Province]([Name])
)