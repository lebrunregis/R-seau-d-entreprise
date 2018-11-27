CREATE PROCEDURE [dbo].[AddEmployeeDepartment]
	@EmployeeId int,
	@DepartmentId int,
	@User int
AS
IF (dbo.FN_IsAdmin(@User)=1 OR dbo.FN_GetHeadOfDepartmentId(@DepartmentId)=@User)
AND EXISTS (SELECT * FROM Employee WHERE Employee_Id=@EmployeeId AND Active=1)
AND EXISTS (SELECT * FROM Department WHERE Department_Id=@DepartmentId AND Active=1)
	DECLARE @Count int
	SELECT @Count=Count(*) FROM EmployeeDepartment WHERE Employee_Id = @EmployeeId AND Department_Id = @DepartmentId AND EndDate IS NULL
	IF @Count = 0
		INSERT INTO EmployeeDepartment (Employee_Id,Department_Id) VALUES(@EmployeeId,@DepartmentId);