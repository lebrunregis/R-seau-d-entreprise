CREATE PROCEDURE [dbo].[GetEmployeeDepartments]
	@EmployeeId int
AS
	SELECT EmployeeDepartment.Department_Id , Name FROM EmployeeDepartment 
	JOIN Department ON EmployeeDepartment.Department_Id = EmployeeDepartment.Department_Id 
	WHERE Employee_Id = @EmployeeId AND EndDate IS NULL
	