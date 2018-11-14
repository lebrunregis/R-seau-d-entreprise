CREATE VIEW [dbo].[ProjectHistory]
	AS SELECT 
	Project.Project_Id,
	Project.Project_Description,
	Project.StartDate AS ProjectStartDate,
	Project.EndDate AS ProjectEndDate,
	Project.CreatorId,
	Creator.FirstName + ' ' + Creator.LastName + ' (' + Creator.Email + ')' AS CreatorIdentifier,
	EmployeeTeamLeader.Employee_Id AS TeamLeaderId,
	Manager.FirstName + ' ' + Manager.LastName + ' (' + Manager.Email + ')' AS TeamLeaderIdentifier,
	EmployeeTeamLeader.date AS ManagerStartDate,
	Team.Team_Name,
	Team.Team_Created AS TeamStartDate,
	Team.Team_Disbanded AS TeamEndDate
	FROM Project 
	JOIN Employee AS Creator ON Project.CreatorId = Employee_Id 
	JOIN EmployeeTeamLeader ON Project.Project_Id = EmployeeTeamLeader.Team_Id 
	JOIN Employee AS Manager ON EmployeeTeamLeader.Employee_Id = Manager.Employee_Id
	JOIN Team ON Team.Project_Id = Project.Project_Id
	