CREATE PROCEDURE [dbo].[GetAllAssociedProjects]
	@EmployeeId int
AS
	SELECT Project_Id,Project_Name, Project_Description, StartDate, EndDate, [CreatorId] , Employee.FirstName AS CreatorFirstName, Employee.LastName AS CreatorLastName
	FROM [dbo].Project 
	JOIN Employee 
	ON [CreatorId] = Employee_Id 
	WHERE [CreatorId] = @EmployeeId --OR

	--Not finished,user must only see it's associed projects,here it only sees projects it has been created