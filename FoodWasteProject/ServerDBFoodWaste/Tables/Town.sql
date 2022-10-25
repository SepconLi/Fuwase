CREATE TABLE [dbo].[Town]
(
	[Name] VARCHAR(100) NOT NULL ,
    [DName] VARCHAR(100) NOT NULL, 
    [PName] VARCHAR(100) NOT NULL, 
    PRIMARY KEY ([Name], [PName], [DName]),  
    CONSTRAINT [FK_Town_ToDistrict] FOREIGN KEY ([DName], [PName]) REFERENCES [District]([Name], [PName])
)
