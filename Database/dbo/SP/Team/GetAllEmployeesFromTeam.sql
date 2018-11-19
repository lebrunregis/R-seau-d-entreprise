CREATE PROCEDURE [dbo].[GetAllEmployeesFromTeam]
	@Id int
AS
BEGIN
	SELECT e.Employee_Id, e.FirstName, e.LastName, e.Email, e.RegNat, e.[Address], e.Phone
	FROM EmployeeTeam t JOIN Employee e ON t.Employee_Id=e.Employee_Id
	WHERE t.Team_Id=@Id AND t.EndDate IS NOT NULL
END