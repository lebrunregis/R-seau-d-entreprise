CREATE PROCEDURE [dbo].[GetEmployeeProjectManagerHistory]
	@Employee_Id int
AS
    DECLARE @now datetime2 = GETTIME();
    SELECT * FROM
	    (SELECT p.Project_Id, p.Project_Name, pm.[Date] AS StartDate, dbo.FN_EndDateManager(p.Project_Id, pm.[Date]) AS EndDate
	    FROM Project p INNER JOIN ProjectManager pm ON p.Project_Id=pm.Project_Id
	    WHERE pm.Employee_Id=@Employee_Id) AS History
	ORDER BY ISNULL(EndDate, @now) DESC, StartDate DESC