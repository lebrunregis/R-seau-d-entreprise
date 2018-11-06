CREATE FUNCTION [dbo].[FN_EndDateManager] (@Project_Id int, @Date datetime2(7)) 
RETURNS datetime2(7)
AS
BEGIN
DECLARE @EndDate datetime2(7);
SELECT @EndDate=min(EndDate) FROM
(
    SELECT [Date] AS EndDate FROM ProjectManager WHERE Project_Id=@Project_Id AND [Date] > @Date
	UNION
	SELECT EndDate from Project WHERE Project_Id=@Project_Id
) AS EndDates;
RETURN @EndDate;
END