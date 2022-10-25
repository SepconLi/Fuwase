CREATE TABLE [dbo].[Statistic] (
    [User_Id]         VARCHAR (128) NOT NULL,
    [Donation_Amount] INT           DEFAULT 0,
    [Order_Amount]    INT           DEFAULT 0,
    [Donated_Weight]  FLOAT         DEFAULT 0,
    PRIMARY KEY CLUSTERED ([User_Id] ASC),
    CONSTRAINT [FK_User_Id] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[Client] ([Email])
);

