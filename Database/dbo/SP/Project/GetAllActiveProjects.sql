CREATE PROCEDURE [dbo].[GetAllActiveProjects]
AS
	SELECT Project_Id,Project_Name, Project_Description, StartDate, EndDate, [CreatorId] , Employee.FirstName AS CreatorFirstName, Employee.LastName AS CreatorLastName
	FROM [dbo].Project JOIN Employee 
	ON [CreatorId] = Employee_Id 
	WHERE EndDate IS NULL