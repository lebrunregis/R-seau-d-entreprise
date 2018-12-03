CREATE PROCEDURE [dbo].[GetEmployeesForTask]
	@TaskId int
AS
	SELECT Employee.Employee_Id AS Employee_Id, LastName, FirstName, Email, RegNat, [Address], Phone 
	FROM EmployeeTask 
	JOIN Employee on Employee.Employee_Id = EmployeeTask.Employee_Id
	WHERE Task_Id = @TaskId
RETURN 0
