CREATE PROCEDURE [dbo].[GetEmployeesForDepartment]
	@Department_Id int
AS
	SELECT e.Employee_Id, e.FirstName, e.LastName, e.Email, e.RegNat, e.[Address], e.Phone
	FROM EmployeeDepartment ed JOIN Employee e ON ed.Employee_Id = e.Employee_Id
	WHERE ed.Department_Id = @Department_Id AND ed.EndDate IS NULL
