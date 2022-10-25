CREATE TABLE [dbo].[Statistic] (
    [User_Id]         VARCHAR (128) NOT NULL,
    [Donation_Amount] INT           DEFAULT 0 NULL,
    [Order_Amount]    INT           DEFAULT 0 NULL,
    [Donated_Weight]  FLOAT         DEFAULT 0 NULL,
    [App_Total_Donations] INT       DEFAULT 0 NULL, 
    PRIMARY KEY CLUSTERED ([User_Id] ASC),
    CONSTRAINT [FK_User_Id] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[Client] ([Email])
);

