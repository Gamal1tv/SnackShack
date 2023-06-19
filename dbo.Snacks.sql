CREATE TABLE [dbo].[Snacks] (
    [ProductID]     INT           IDENTITY (1, 1) NOT NULL,
    [SnackName]     NVARCHAR (20) NOT NULL,
    [PurchasePrice] SMALLMONEY    NOT NULL,
    [SalePrice]     SMALLMONEY    NOT NULL,
    [QOH]           TINYINT       NOT NULL,
    [Slot]          TINYINT       NOT NULL,
    [QFS]           TINYINT       NOT NULL,
    [ImagePath]     TEXT          NOT NULL,
    PRIMARY KEY CLUSTERED ([ProductID] ASC)
);

