CREATE PROCEDURE [dbo].[GetAllActiveTeams]
AS
	SELECT t.Team_Id, t.Team_Name, t.Team_Created, t.Team_Disbanded, t.[Creator_Id] , e.FirstName AS CreatorFirstName, e.LastName AS CreatorLastName, p.Project_Id, p.Project_Name
	FROM [dbo].Team t JOIN Employee e
	ON t.[Creator_Id] = e.Employee_Id
	JOIN Project p
	ON t.Project_Id = p.Project_Id
	WHERE t.Team_Disbanded IS NULL and (p.EndDate IS NULL OR p.EndDate > GETDATE())