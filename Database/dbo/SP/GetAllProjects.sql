CREATE PROCEDURE [dbo].[GetAllProjects]
AS
	SELECT Project_Id,Project_Name, Project_Description, StartDate, EndDate, Creator , Employee.FirstName AS CreatorFirstName, Employee.LastName AS CreatorLastName
	FROM [dbo].Project JOIN Employee 
	ON Creator = Employee_Id