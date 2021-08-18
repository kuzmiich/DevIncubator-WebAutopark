CREATE TABLE [dbo].[Orders] (
    [OrderId]   INT NOT NULL IDENTITY,
    [VehicleId] INT NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([OrderId] ASC),
    CONSTRAINT [FK_Orders_OrderDetails] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[OrderDetails] ([OrderDetailId]),
    CONSTRAINT [FK_Orders_Vehicles] FOREIGN KEY ([VehicleId]) REFERENCES [dbo].[Vehicles] ([VehicleId])
);

