CREATE PROCEDURE [dbo].[GetActiveProjectsForManager]
	@Manager_Id int
AS
SELECT
	p.Project_Id ,
	p.Project_Name,
	p.Project_Description,
	p.StartDate,
	p.EndDate,
	p.[CreatorId] ,
	pm.Employee_Id AS ProjectManagerId
	FROM [dbo].Project p
	JOIN ProjectManager pm
	ON pm.Project_Id = p.Project_Id
	JOIN (SELECT Project_Id, max(Date) AS MaxDate FROM ProjectManager GROUP BY project_id) MaxDateTable
	ON p.Project_Id = MaxDateTable.Project_Id
	WHERE (p.EndDate IS NULL OR p.EndDate > CAST(GETDATE() AS datetime2(0)))
	AND pm.Date = MaxDateTable.MaxDate
	AND pm.Employee_Id = @Manager_Id 
