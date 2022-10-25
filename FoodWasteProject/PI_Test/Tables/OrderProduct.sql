CREATE TABLE [dbo].[OrderProduct]
(
    [ProductId] INT NOT NULL,
    [OrderId] INT NOT NULL,
    [Quantity] INT NOT NULL

    CONSTRAINT OrderProductKey PRIMARY KEY ([ProductId], [OrderId]), 
    CONSTRAINT [FK_OrderProduct_ToProduct] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]),
    CONSTRAINT [FK_OrderProduct_ToOrders] FOREIGN KEY ([OrderId]) REFERENCES [Orders]([Id])
)
