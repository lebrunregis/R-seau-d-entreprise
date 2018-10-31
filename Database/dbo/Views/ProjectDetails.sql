CREATE VIEW [dbo].[ProjectDetails]
	AS SELECT 
	Project.*,
	Creator.FirstName + ' ' + Creator.LastName + ' ' + Creator.Email AS CreatorIdentifier,
	EmployeeTeamLeader.Employee_Id AS ManagerId,
	Manager.FirstName + ' ' + Manager.LastName + ' ' + Manager.Email AS ManagerIdentifier,
	EmployeeTeamLeader.date,Manager.* 
	FROM Project 
	JOIN Employee AS Creator ON Project.CreatorId = Employee_Id 
	JOIN EmployeeTeamLeader ON Project.Project_Id = EmployeeTeamLeader.Team_Id 
	JOIN Employee AS Manager ON EmployeeTeamLeader.Employee_Id = Manager.Employee_Id 
