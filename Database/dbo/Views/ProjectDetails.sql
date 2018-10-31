CREATE VIEW [dbo].[ProjectDetails]
AS
	SELECT p.Project_Id, p.Project_Name, p.Project_Description, p.StartDate, p.EndDate, p.CreatorId, e.Employee_Id,
	    adm.FirstName + ' ' + adm.LastName  + '(' + adm.Email + ')' AS CreatorIdentifier,
	    manager.FirstName + ' ' + manager.LastName  + '(' + manager.Email + ')' AS ManagerIdentifier
    FROM Project p
	INNER JOIN EmployeeProjectManager e ON p.Project_Id=e.Project_Id
    INNER JOIN 
        (SELECT max(e2.[Date]) maxDate, e2.Project_Id FROM EmployeeProjectManager e2 GROUP BY e2.Project_Id) e3
        ON e.[Date]=e3.maxDate AND e.Project_Id=e3.Project_Id
	INNER JOIN Employee adm ON p.CreatorId=adm.Employee_Id
	INNER JOIN Employee manager ON e.Employee_Id=manager.Employee_Id