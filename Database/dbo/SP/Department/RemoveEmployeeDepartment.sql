CREATE PROCEDURE [dbo].[RemoveEmployeeDepartment]
	@EmployeeId int,
	@DepartmentId int
AS
	DELETE FROM EmployeeDepartment WHERE Employee_Id =  @EmployeeId AND Department_Id = @DepartmentId AND EndDate IS NULL ;
RETURN 0