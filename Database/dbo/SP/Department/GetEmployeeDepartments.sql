CREATE PROCEDURE [dbo].[GetEmployeeDepartments]
	@EmployeeId int
AS
	SELECT EmployeeDepartment.Department_Id , Name , Description, StartDate,EndDate,Created,Creator_Id,Active FROM EmployeeDepartment 
	JOIN Department ON Department.Department_Id = EmployeeDepartment.Department_Id 
	WHERE Employee_Id = @EmployeeId AND EndDate IS NULL AND Department.Active=1
	