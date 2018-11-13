CREATE PROCEDURE [dbo].[AddEmployeeDepartment]
	@EmployeeId int,
	@DepartmentId int
AS
	INSERT INTO EmployeeDepartment (Employee_Id,Department_Id) VALUES(@EmployeeId,@DepartmentId);
RETURN 0
