CREATE PROCEDURE [dbo].[ChangeHeadOfDepartment]
	@DepId int ,
	@EmpId int
AS
	INSERT INTO EmployeeHeadOfDepartment(Employee_Id,Department_Id) VALUES (@DepId,@EmpId)
SELECT Scope_Identity()
