-- Member 05: Table-Valued Function for Revenue Reporting
IF OBJECT_ID('dbo.fn_DailyRevenue', 'IF') IS NOT NULL DROP FUNCTION dbo.fn_DailyRevenue;
GO

CREATE FUNCTION dbo.fn_DailyRevenue
    (@StartDate DATE, @EndDate DATE)
RETURNS TABLE
AS RETURN
(
    SELECT 
        CAST(SaleDate AS DATE) AS SaleDate,
        SUM(TotalAmount) AS TotalRevenue,
        COUNT(*) AS Transactions,
        AVG(TotalAmount) AS AvgOrderValue
    FROM dbo.Sales
    WHERE CAST(SaleDate AS DATE) BETWEEN @StartDate AND @EndDate
    GROUP BY CAST(SaleDate AS DATE)
);
GO