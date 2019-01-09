CREATE PROCEDURE [dbo].[GetEmployeeDepartmentsHistory]
	@EmployeeId int
AS
	SELECT Id,EmployeeDepartment.Department_Id AS Department_Id, StartDate,EndDate ,Department.Name FROM EmployeeDepartment 
	JOIN Department ON EmployeeDepartment.Department_Id = Department.Department_Id 
	WHERE Employee_Id = @EmployeeId
	