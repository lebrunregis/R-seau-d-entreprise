CREATE PROCEDURE [dbo].[ChangeHeadOfDepartment]
	@DepId int,
	@EmpId int,
	@User int
AS
    IF dbo.FN_IsAdmin(@User) = 1
	AND EXISTS(SELECT * FROM Employee WHERE Employee_Id=@EmpId AND Active=1)
	AND EXISTS(SELECT * FROM Department WHERE Department_Id=@DepId AND Active=1)
	AND (dbo.FN_GetHeadOfDepartmentId(@DepId) != @EmpId OR dbo.FN_GetHeadOfDepartmentId(@DepId) IS NULL)
	    INSERT INTO EmployeeHeadOfDepartment(Employee_Id,Department_Id) VALUES (@EmpId, @DepId)
