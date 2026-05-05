CREATE FUNCTION fn_DailyRevenue (@StartDate DATE, @EndDate DATE)
RETURNS TABLE
AS RETURN (
    SELECT 
        CAST(SaleDate AS DATE) AS SaleDate,
        SUM(TotalAmount) AS TotalRevenue,
        COUNT(*) AS Transactions,
        AVG(TotalAmount) AS AvgOrderValue
    FROM Sales
    WHERE SaleDate BETWEEN @StartDate AND @EndDate
    GROUP BY CAST(SaleDate AS DATE)
);