CREATE TABLE [dbo].[VehicleTypes] (
    [VehicleTypeId]  INT          NOT NULL IDENTITY,
    [TypeName]       VARCHAR (30) NULL,
    [TaxCoefficient] FLOAT (53)   NOT NULL,
    CONSTRAINT [PK_VehicleTypes] PRIMARY KEY CLUSTERED ([VehicleTypeId] ASC)
);

