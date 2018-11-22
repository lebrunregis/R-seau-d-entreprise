CREATE FUNCTION [dbo].[FN_EndDateTeamLeader] (@Team_Id int, @Date datetime2(7)) 
RETURNS datetime2(7)
AS
BEGIN
DECLARE @Project_Id int;
SELECT @Project_Id=Project_Id FROM Team WHERE Team_Id=@Team_Id;
DECLARE @EndDate datetime2(7);
SELECT @EndDate=min(EndDate) FROM
(
    SELECT TOP 1 [date] AS EndDate FROM EmployeeTeamLeader WHERE Team_Id=@Team_Id AND [date] > @Date ORDER BY [date] DESC
	UNION
	SELECT Team_Disbanded from Team WHERE Team_Id=@Team_Id
	UNION
	SELECT EndDate from Project WHERE Project_Id=@Project_Id
) AS EndDates;
RETURN @EndDate;
END