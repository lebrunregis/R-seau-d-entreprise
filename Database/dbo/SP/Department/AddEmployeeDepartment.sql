CREATE PROCEDURE [dbo].[AddEmployeeDepartment]
	@EmployeeId int,
	@DepartmentId int
AS
	DECLARE @Count int
	SELECT @Count=Count(*) FROM EmployeeDepartment WHERE Employee_Id = @EmployeeId AND Department_Id = @DepartmentId AND EndDate IS NULL
	IF @Count = 0
		INSERT INTO EmployeeDepartment (Employee_Id,Department_Id) VALUES(@EmployeeId,@DepartmentId);
RETURN 0
