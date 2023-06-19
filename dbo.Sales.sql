CREATE TABLE [dbo].[Sales] (
    [MachineID]  INT        NOT NULL,
    [SaleID]     INT        IDENTITY (1, 1) NOT NULL,
    [ProductID]  INT        NOT NULL,
    [SalesPrice] SMALLMONEY NOT NULL,
    [QOH]        TINYINT    NOT NULL,
    [Slot]       TINYINT    NOT NULL,
    [QFS]        TINYINT    NOT NULL,
    [DateTime]   DATETIME   NOT NULL,
    PRIMARY KEY CLUSTERED ([MachineID] ASC)
);

