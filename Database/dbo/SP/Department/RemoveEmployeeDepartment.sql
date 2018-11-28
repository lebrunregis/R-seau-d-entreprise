CREATE PROCEDURE [dbo].[RemoveEmployeeDepartment]
	@EmployeeId int,
	@DepartmentId int,
	@User int
AS
IF (dbo.FN_IsAdmin(@User)=1 OR dbo.FN_GetHeadOfDepartmentId(@DepartmentId)=@User)
AND EXISTS (SELECT * FROM Department WHERE Department_Id=@DepartmentId AND Active=1)
	DELETE FROM EmployeeDepartment WHERE Employee_Id =  @EmployeeId AND Department_Id = @DepartmentId AND EndDate IS NULL ;