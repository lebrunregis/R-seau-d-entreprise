CREATE PROCEDURE [dbo].[GetTeam]
	@Id int
AS
	SELECT Team_Id, Team_Name, Team_Created, Team_Disbanded, Creator_Id, Team.Project_Id,
	Employee.FirstName AS CreatorFirstName, Employee.LastName AS CreatorLastName,
	Project.Project_Name
	FROM [dbo].Team JOIN Employee 
	ON Creator_Id = Employee_Id
	JOIN Project
	ON Team.Project_Id = Project.Project_Id 
	WHERE Team_Id = @Id