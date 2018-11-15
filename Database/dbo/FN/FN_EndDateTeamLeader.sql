CREATE FUNCTION [dbo].[FN_EndDateTeamLeader] (@Team_Id int, @Date datetime2(7)) 
RETURNS datetime2(7)
AS
BEGIN
DECLARE @Project_Id int;
SELECT @Project_Id=Project_Id FROM Team WHERE Team_Id=@Team_Id;
DECLARE @EndDate datetime2(7);
SELECT @EndDate=min(EndDate) FROM
(
    SELECT TOP 1 [Date] AS EndDate FROM EmployeeTeamLeader WHERE Team_Id=@Team_Id AND [Date] > @Date ORDER BY [Date] DESC
	UNION
	SELECT Team_Disbanded from Team WHERE Team_Id=@Team_Id
	UNION
	SELECT EndDate from Project WHERE Project_Id=@Project_Id
) AS EndDates;
RETURN @EndDate;
END