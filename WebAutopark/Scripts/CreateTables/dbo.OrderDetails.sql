CREATE TABLE [dbo].[OrderDetails] (
    [OrderDetailId] INT NOT NULL IDENTITY,
    [OrderId]       INT NOT NULL,
    [DetailId]      INT NOT NULL,
    [DetailAmount]  INT NOT NULL,
    CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED ([OrderDetailId] ASC),
    CONSTRAINT [FK_OrderDetails_Details] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Details] ([DetailId])
);

