CREATE PROCEDURE [dbo].[GetAllEmployeesForTeam]
	@Id int
AS
BEGIN
	SELECT e.Employee_Id, e.FirstName, e.LastName, e.Email, e.RegNat, e.[Address], e.Phone
	FROM EmployeeTeam et JOIN Employee e ON et.Employee_Id=e.Employee_Id
	WHERE et.Team_Id=@Id AND et.EndDate IS NOT NULL
END