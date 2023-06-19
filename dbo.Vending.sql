CREATE TABLE [dbo].[Vending] (
    [ProductID] INT        NOT NULL,
    [SalePrice] SMALLMONEY NOT NULL,
    [QFS]       TINYINT    NOT NULL,
    [MachineID] INT        NOT NULL,
    [NumSlots]  TINYINT    NOT NULL,
    [QOH]		TINYINT    NOT NULL, 
    PRIMARY KEY CLUSTERED ([ProductID] ASC)
);

